using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.Common;
using System.Windows.Forms;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT
{
    class MMainLogic
    {
        //private delegate void TOUI();
        //private delegate void TOUIARG(object[] args);

        private static MMainLogic instance;
        private List<MGameProfile> saves = new List<MGameProfile>();
        private MGameProfile currentProfile = null;
        private bool paused = false;
        private bool combat = false;
        private bool victory = false;
        private bool defeated = false;
        private bool isInGame = false;
        private bool isGameOver = false;
        private bool keyboardInput = false;
        private Keys keyboardData;
        private string defeatedEnemy;
        private Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
        private DateTime playTime;
        public static MMainLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MMainLogic();
                    return instance;
                }
                else
                    return instance;
            }
        }
        public List<MGameProfile> Saves { get { return saves; } set { saves = value; } }
        public MGameProfile CurrentProfile { get { return currentProfile; } set { currentProfile = value; } }
        public bool Paused { get { return paused; } set { paused = value; } }
        public bool Combat { get { return combat; } set { combat = value; } }
        public bool Victory { get { return victory; } set { victory = value; } }
        public bool Defeated { get { return defeated; } set { defeated = value; } }
        public bool IsInGame { get { return isInGame; } set { isInGame = value; } }
        public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }
        public bool KeyboardInput { get { return keyboardInput; } set { keyboardInput = value; } }
        public Keys KeyboardData { get { return keyboardData; } set { keyboardData = value; } }
        public string DefeatedEnemy { get { return defeatedEnemy; } set { defeatedEnemy = value; } }
        public Dictionary<string, List<string>> Data { get { return data; } }
        public DateTime PlayTime { get { return playTime; } set { playTime = value; } }

        public MMainLogic()
        {
        }

        public void GameInit()
        {
            Shell.WriteLine("游戏初始化...", ConsoleColor.Black);
            // 加载所有存档文件到Saves
            BinaryFormatter bf = new BinaryFormatter();
            string dir = @"..\..\Saves";
            if (!Directory.Exists(dir)) return;
            string[] files = Directory.GetFiles(dir, @"*.save");
            FileStream fs;
            foreach(string file in files)
            {
                fs = new FileStream(file, FileMode.Open);
                Saves.Add((MGameProfile)bf.Deserialize(fs));
            }
            // 读取数据文件
            List<string> Characters = new List<string>();
            List<string> Items = new List<string>();
            List<string> Skills = new List<string>();
            string path = @"..\..\Data\";
            string[] names = { "Characters.csv", "Items.csv", "Skills.csv" };
            StreamReader sr;
            foreach (var s in names)
            {
                sr = new StreamReader(path + s,Encoding.GetEncoding("gb2312"));
                while (!sr.EndOfStream)
                    switch (s)
                    {
                        case "Characters.csv":
                            Characters.Add(sr.ReadLine());
                            break;
                        case "Items.csv":
                            Items.Add(sr.ReadLine());
                            break;
                        case "Skills.csv":
                            Skills.Add(sr.ReadLine());
                            break;
                    }
                sr.Close();
            }
            Data.Add("Character", Characters);
            Data.Add("Item", Items);
            Data.Add("Skill", Skills);
        }

        public void GameOver()
        {
            Shell.WriteLine("游戏结束.", ConsoleColor.Black);
            IsInGame = false;
            IsGameOver = true;
        }

        public void Draw()
        {
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.Draw));
        }

        public void Start(int saveNum = 0, string pn="")
        {
            if (saveNum == 0)     // 开始新游戏
            {
                NewGame(pn);
                MLevel.Levels.Add(new MLevel(1));
                MMainCharacter.Instance.Name = CurrentProfile.PlayerName;     // 新主角只用定义Name
                MMainCharacter.Instance.LocationX = 9;
                MMainCharacter.Instance.LocationY = 4;
            }
            else     // 加载游戏
            {
                LoadProfile(saveNum);
                MLevel.Levels = CurrentProfile.ExistLevels;
                MLevel.CurrentLevel = CurrentProfile.CurrentLevelNumber;
                MMainCharacter.Instance = CurrentProfile.Character;     // 旧主角需要跟存档中的主角一样
            }
            PlayTime = DateTime.Now;
            // 设置进入游戏标志
            IsInGame = true;
            // 重置其他标志
            ResetMarks(false);
            Shell.WriteLine("游戏开始", ConsoleColor.Black);
        }

        public void Exit()
        {
            Shell.WriteLine("退出游戏...", ConsoleColor.Black);
            GameOver();
            if (Thread.CurrentThread.Name == "Form")
                MMainForm.Instance.Dispose();
            else if (Thread.CurrentThread.Name == "Logic")
                MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.Dispose));
        }

        public void NewGame(string pn)
        {
            Shell.WriteLine("新建游戏", ConsoleColor.Black);
            CurrentProfile = new MGameProfile(pn);
        }

        public void LoadProfile(int number)    // 根据Saves初始化当前用户档案
        {
            Shell.WriteLine("加载游戏", ConsoleColor.Black);
            CurrentProfile = Saves[number - 1];
        }

        public void SaveProfile()     // 将用户档案保存到文件，并更新Saves
        {
            Shell.WriteLine("保存游戏", ConsoleColor.Black);
            // 保存到文件
            BinaryFormatter bf = new BinaryFormatter();
            if (!Directory.Exists(@"..\..\Saves")) Directory.CreateDirectory(@"..\..\Saves");
            string path = @"..\..\Saves\Saves_" + (Saves.Count + 1).ToString() + ".save";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                CurrentProfile.ExistLevels = MLevel.Levels;
                CurrentProfile.CurrentLevelNumber = MLevel.CurrentLevel;
                CurrentProfile.Character = MMainCharacter.Instance;
                // 计时
                CurrentProfile.PlayedTime += (int)(DateTime.Now - PlayTime).TotalSeconds;
                bf.Serialize(fs, CurrentProfile);
            }
            // 更新Saves
            Saves.Add(CurrentProfile);
            // 与窗体通信
            if (System.Threading.Thread.CurrentThread.Name == "Logic")
                MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.Fl.AddNewSave));
            else
                MMainForm.Instance.Fl.AddNewSave();
        }
        
        public void CombatMode(MEnemy enemy)
        {
            Shell.WriteLine("进入战斗", ConsoleColor.Black);
            Combat = true;
            // 与窗体通信，显示战斗界面
            MMainForm.Instance.BeginInvoke(new Action<object[]>(MMainForm.Instance.ShowCombatMenu), new object[1] { new object[1] { enemy } });
            // 比较速度判出先后手
            MCharacter currentOne;
            if (MMainCharacter.Instance.Speed >= enemy.Speed)
                currentOne = MMainCharacter.Instance;
            else
                currentOne = enemy;
            // 将主角的HP、MP、Power提到Max值
            MMainCharacter.Instance.HP = MMainCharacter.Instance.MaxHP;
            MMainCharacter.Instance.MP = MMainCharacter.Instance.MaxMP;
            MMainCharacter.Instance.Power = MMainCharacter.Instance.MaxPower;
            while (Combat)
            {
                // 与从窗体通信，告知目前哪些技能可用
                object[] choice = new object[MMainCharacter.Instance.Skills.Count];
                for (int i = 0; i < MMainCharacter.Instance.Skills.Count; i++)
                {
                    if (MMainCharacter.Instance.Skills[i].Type == ATTRIBUTE.POWER)
                    {
                        if (MMainCharacter.Instance.Skills[i].Consumption <= MMainCharacter.Instance.Power)
                            choice[i] = true;
                        else
                            choice[i] = false;
                    }
                    else
                    {
                        if (MMainCharacter.Instance.Skills[i].Consumption <= MMainCharacter.Instance.MP)
                            choice[i] = true;
                        else
                            choice[i] = false;
                    }
                }
                MMainForm.Instance.BeginInvoke(new Action<object[]>(MMainForm.Instance.UpdateCombatMenu), new object[1] { choice });
                Shell.WriteLine(string.Format("玩家HP：{0}     敌人HP：{1}", MMainCharacter.Instance.HP, enemy.HP), ConsoleColor.Green);
                if (currentOne is MMainCharacter)     // 主角的轮次。若30秒之内不攻击，则使用普通攻击。
                {
                    Shell.WriteLine("玩家的回合", ConsoleColor.Green);
                    int i = 0;
                    while (i < 300 && MMainCharacter.Instance.AttackChoice == 255)
                    {
                        Thread.Sleep(100);
                        i++;
                    }
                    // 根据AttackChoice来进行攻击操作。0为普通攻击
                    if (MMainCharacter.Instance.AttackChoice != 0 && MMainCharacter.Instance.AttackChoice != 255)     // 技能攻击
                    {
                        //Shell.WriteLine(string.Format("使用{0}进行攻击", MMainCharacter.Instance.Skills[MMainCharacter.Instance.AttackChoice - 1].Name), ConsoleColor.Green);
                        //MMainCharacter.Instance.Skills[MMainCharacter.Instance.AttackChoice - 1].Activate(enemy);
                        MMainCharacter.Instance.Attack(enemy, MMainCharacter.Instance.Skills[MMainCharacter.Instance.AttackChoice - 1]);
                        MMainCharacter.Instance.AttackChoice = 255;
                    }
                    else     // 普通攻击
                    {
                        Shell.WriteLine("使用普通攻击", ConsoleColor.Green);
                        MMainCharacter.Instance.Attack(enemy, null);
                        MMainCharacter.Instance.AttackChoice = 255;
                    }
                    // 判断对方血量、是否胜利
                    if(enemy.HP <= 0)
                    {
                        Shell.WriteLine("敌人死亡", ConsoleColor.Green);
                        // 获取经验值，判断是否升级
                        MMainCharacter.Instance.GetExp(enemy);
                        // 将敌人从当前关卡移除
                        MLevel.Levels[MLevel.CurrentLevel - 1].Enemies.Remove(enemy);
                        // 更新GameProfile
                        CurrentProfile.DefeatedCount++;
                        Combat = false;
                    }
                    // 切换轮次
                    currentOne = enemy;
                }
                else     // 敌人的轮次
                {
                    Shell.WriteLine("敌人的回合", ConsoleColor.Green);
                    // 延迟
                    Thread.Sleep(1000);
                    // 随机选择技能进行攻击操作
                    Random rand = new Random();
                    enemy.Attack(MMainCharacter.Instance, enemy.Skills.Count == 0 ? null : enemy.Skills[rand.Next(enemy.Skills.Count)]);     // 需更改
                    // 判断对方血量、是否胜利
                    if(MMainCharacter.Instance.HP <= 0)
                    {
                        Shell.WriteLine("主角死亡", ConsoleColor.Green);
                        // 将当前敌人的HP MP Power重置
                        enemy.HP = enemy.MaxHP;
                        enemy.MP = enemy.MaxMP;
                        enemy.Power = enemy.MaxPower;
                        Combat = false;
                    }
                    // 切换轮次
                    currentOne = MMainCharacter.Instance;
                }
            }
            // 关闭战斗界面
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.CloseCombatMenu));
            // 若主角战败，则调用DefeatedMode()
            if (MMainCharacter.Instance.HP <= 0)
            {
                DefeatedEnemy = enemy.Name;
                DefeatedMode();
            }
            else
            {
                Shell.WriteLine(string.Format("击败{0}，获得{1}经验值", enemy.Name, enemy.Exp), ConsoleColor.Green);
                // 若敌人为关底Boss，则调用VictoryMode()
                if (MLevel.CurrentLevel == 16 && enemy is TheDevil)
                    VictoryMode();
            }
        }

        public void VictoryMode()
        {
            Shell.WriteLine("游戏胜利", ConsoleColor.Black);
            IsInGame = false;
            Victory = true;
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.EndingMenu));
            // 展示统计信息
            CurrentProfile.PlayedTime += (int)(PlayTime - DateTime.Now).TotalSeconds;
            Shell.WriteLine(CurrentProfile.ToString(), ConsoleColor.Green);
        }

        public void DefeatedMode()
        {
            Shell.WriteLine("游戏失败", ConsoleColor.Black);
            IsInGame = false;
            Defeated = true;
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.EndingMenu));
        }

        public void PauseRelease()
        {
            Shell.WriteLine("游戏继续", ConsoleColor.Black);
            IsInGame = true;
            Paused = false;
        }

        public void PauseMode()
        {
            Shell.WriteLine("游戏暂停", ConsoleColor.Black);
            IsInGame = false;
            Paused = true;
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.PausedMenu));
        }

        public void StarFromCurrentLevel()     // 战斗失败之后，从当前关卡重玩。将主角传送至关卡入口处即可
        {
            Shell.WriteLine("重玩", ConsoleColor.Black);
            MLevel.LocateNearExit(false);
            IsInGame = true;     // 设置游戏进行中
            Draw();
        }

        public void BackToMainMenu()     // 游戏胜利之后/战斗失败之后，返回主菜单。不保存当前存档
        {
            Shell.WriteLine("返回主界面", ConsoleColor.Black);
            MLevel.Levels = new List<MLevel>();
            IsInGame = false;
            CurrentProfile = null;
            ResetMarks(false);
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.MainMenu));
        }

        public void ResetMarks(bool m = false)
        {
            Paused = m;
            Combat = m;
            Victory = m;
            Defeated = m;
            IsGameOver = m;
        }

        public void GameLoop()
        {
            while (true)
            {
                if (IsInGame)     // 开始游戏之后才开始游戏循环
                {
                    // 需要更改
                    byte direction = 0;     // 上1下2左3右4
                    MLevel currentLevel = (from level in MLevel.Levels where level.LevelNumber == MLevel.CurrentLevel select level).First();
                    // 处理键盘输入
                    if (KeyboardInput == true)
                    {
                        switch (KeyboardData)     // 使用主角的Move()
                        {
                            case Keys.A:
                                MMainCharacter.Instance.Move(3);
                                direction = 3;
                                break;
                            case Keys.D:
                                MMainCharacter.Instance.Move(4);
                                direction = 4;
                                break;
                            case Keys.W:
                                MMainCharacter.Instance.Move(1);
                                direction = 1;
                                break;
                            case Keys.S:
                                MMainCharacter.Instance.Move(2);
                                direction = 2;
                                break;
                            case Keys.Escape:
                                PauseMode();
                                break;
                        }
                        Draw();
                        // 重置输入
                        KeyboardInput = false;
                        KeyboardData = Keys.None;
                    }
                    // 暂停，不进行后续处理
                    if (Paused) continue;
                    // 碰撞检测
                    bool hit = false;
                    // 与物品碰撞
                    foreach (MItem item in currentLevel.Items)
                    {
                        if(item.LocationX == MMainCharacter.Instance.LocationX && item.LocationY == MMainCharacter.Instance.LocationY)
                        {
                            // 与物品发生碰撞
                            hit = true;
                            // 若为门/第一关入口，则不进行移动
                            if(item is MDoor || (item is MExit && MLevel.CurrentLevel==1))
                            {
                                if(direction != 0)
                                    switch (direction)
                                    {
                                        case 1:
                                            MMainCharacter.Instance.Move(2);
                                            break;
                                        case 2:
                                            MMainCharacter.Instance.Move(1);
                                            break;
                                        case 3:
                                            MMainCharacter.Instance.Move(4);
                                            break;
                                        case 4:
                                            MMainCharacter.Instance.Move(3);
                                            break;
                                    }
                            }
                            // 发生交互
                            //Shell.WriteLine(string.Format("与{0}发生交互", item.Name), ConsoleColor.Blue);
                            item.Interact();
                            Draw();
                            break;
                        }
                    }
                    // 与敌人碰撞
                    if(!hit)
                        foreach(MEnemy enemy in currentLevel.Enemies)
                        {
                            if (enemy.LocationX == MMainCharacter.Instance.LocationX && enemy.LocationY == MMainCharacter.Instance.LocationY)
                            {
                                Shell.WriteLine(string.Format("与{0}发生战斗", enemy.Name), ConsoleColor.Red);
                                CombatMode(enemy);
                                Draw();
                                break;
                            }
                        }
                }
                if(Paused && KeyboardInput && KeyboardData == Keys.Escape)
                {
                    PauseRelease();
                    // 重置输入
                    KeyboardInput = false;
                    KeyboardData = Keys.None;
                    // 与窗体通信
                    MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.Fp.Picturebox_Load_menu.Hide));
                }
                if (IsGameOver) break;     // 若游戏结束，则退出循环，关闭线程
            }
        }
    }
}
