using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT
{
    class MMainLogic
    {
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
        public bool Combat { get { return paused; } set { combat = value; } }
        public bool Victory { get { return paused; } set { victory = value; } }
        public bool Defeated { get { return paused; } set { defeated = value; } }
        public bool IsInGame { get { return isInGame; } set { isInGame = value; } }
        public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }
        public bool KeyboardInput { get { return keyboardInput; } set { keyboardInput = value; } }
        public Keys KeyboardData { get { return keyboardData; } set { keyboardData = value; } }

        public MMainLogic()
        {
        }

        public void GameInit()
        {
            // 加载所有存档文件到Saves
            BinaryFormatter bf = new BinaryFormatter();
            string dir = @"..\..\Saves";
            string[] files = Directory.GetFiles(dir, @"*.save");
            FileStream fs;
            foreach(string file in files)
            {
                fs = new FileStream(file, FileMode.Open);
                Saves.Add(new MGameProfile((MGameProfile)bf.Deserialize(fs)));
            }
        }

        public void GameOver()
        {
            IsInGame = true;
            IsGameOver = true;
        }

        public void Draw()
        {

        }

        public void Start(int saveNum = 0, string pn="")
        {
            if (saveNum == 0)     // 开始新游戏
            {
                NewGame(pn);
                MLevel.Levels.Add(new MLevel(1));
                CurrentProfile.ExistLevels = MLevel.Levels;
            }
            else     // 加载游戏
            {
                LoadProfile(saveNum);
                MLevel.Levels = CurrentProfile.ExistLevels;
            }
            // 设置进入游戏标志
            IsInGame = true;
        }

        public void Exit()
        {
            MMainForm.Instance.Dispose();
            GameOver();
        }

        public void NewGame(string pn)
        {
            CurrentProfile = new MGameProfile(pn);
            CurrentProfile.Character = new MMainCharacter();     // 后续可能需改动
        }

        public void LoadProfile(int number)     // 路径后续可能需改动
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = @"..\..\Saves_" + number.ToString() + ".save";
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                CurrentProfile = new MGameProfile((MGameProfile)bf.Deserialize(fs));
            }
        }

        public void SaveProfile()     // 路径后续可能需改动
        {
            // 保存到文件
            BinaryFormatter bf = new BinaryFormatter();
            string path = @"..\..\Saves_" + (Saves.Count + 1).ToString() + ".save";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                CurrentProfile.ExistLevels = MLevel.Levels;
                bf.Serialize(fs, CurrentProfile);
            }
            // 更新Saves
            Saves.Add(CurrentProfile);
        }
        
        public void CombatMode(MEnemy enemy)
        {
            Combat = true;
            bool fightOver = false;
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
            while (!fightOver)
            {
                if(currentOne is MMainCharacter)     // 主角的轮次。若30秒之内不攻击，则使用普通攻击。
                {
                    int i = 0;
                    while (i < 300 && MMainCharacter.Instance.AttackChoice != -1)     // 后续需更改。等待MMAinCharacter的新增属性AttackChoice : int
                    {
                        Thread.Sleep(100);
                        i++;
                    }
                    // 根据AttackChoice来进行攻击操作
                    if (MMainCharacter.Instance.AttackChoice != -1)     // 技能攻击
                    {
                        //MMainCharacter.Instance.Skills[MMainCharacter.Instance.AttackChoice - 1].Activate(enemy);
                        MMainCharacter.Instance.Attack(enemy, MMainCharacter.Instance.Skills[MMainCharacter.Instance.AttackChoice - 1]);
                        MMainCharacter.Instance.AttackChoice = -1;
                    }
                    else     // 普通攻击
                        MMainCharacter.Instance.Attack(enemy, null);
                    // 判断对方血量、是否胜利
                    if(enemy.HP <= 0)
                    {
                        // 将敌人从当前关卡移除
                        MLevel.Levels[MLevel.CurrentLevel].Enemies.Remove(enemy);
                        // 更新GameProfile
                        CurrentProfile.DefeatedCount++;
                        fightOver = true;
                    }
                }
                else     // 敌人的轮次
                {
                    // 随机选择技能进行攻击操作

                    // 判断对方血量、是否胜利
                    if(MMainCharacter.Instance.HP <= 0)
                    {

                        fightOver = true;
                    }
                }
            }
            Combat = false;
            // 若主角战败，则调用DefeatedMode()

            // 若敌人为关底Boss，则调用VictoryMode()
        }

        public void VictoryMode()
        {
            Victory = true;
            MMainForm.Instance.EndingMenu();
            // 调用MMainForm.Instance.EndingMenu()
            // 展示统计信息
        }

        public void DefeatedMode()
        {
            Defeated = true;
            MMainForm.Instance.EndingMenu();
        }

        public void PauseMode()
        {
            Paused = true;
            MMainForm.Instance.PausedMenu();
        }

        public void StarFromCurrentLevel()     // 战斗失败之后，从当前关卡重玩。将主角传送至关卡入口处即可
        {

        }

        public void BackToMainMenu()     // 游戏胜利之后/战斗失败之后，返回主菜单。不保存当前存档
        {

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
                    // 处理输入
                    if (KeyboardInput == true)
                    {
                        switch (KeyboardData)     // 使用主角的Move()
                        {
                            case Keys.A:
                                if (currentLevel.Map.Content[MMainCharacter.Instance.LocationX, MMainCharacter.Instance.LocationY - 1] == BLOCKS.EARTH)
                                {
                                    MMainCharacter.Instance.LocationY--;
                                    direction = 3;
                                }
                                break;
                            case Keys.D:
                                if (currentLevel.Map.Content[MMainCharacter.Instance.LocationX, MMainCharacter.Instance.LocationY + 1] == BLOCKS.EARTH)
                                {
                                    MMainCharacter.Instance.LocationY++;
                                    direction = 4;
                                }
                                break;
                            case Keys.W:
                                if (currentLevel.Map.Content[MMainCharacter.Instance.LocationX - 1, MMainCharacter.Instance.LocationY] == BLOCKS.EARTH)
                                {
                                    MMainCharacter.Instance.LocationX--;
                                    direction = 1;
                                }
                                break;
                            case Keys.S:
                                if (currentLevel.Map.Content[MMainCharacter.Instance.LocationX+1, MMainCharacter.Instance.LocationY] == BLOCKS.EARTH)
                                {
                                    MMainCharacter.Instance.LocationX++;
                                    direction = 2;
                                }
                                break;
                            case Keys.Escape:
                                PauseMode();
                                break;
                        }
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
                            // 若为门或出入口，则不进行移动
                            if(item is MDoor || item is MExit)
                            {
                                if(direction != 0)
                                    switch (direction)     // 使用主角的Move()
                                    {
                                        case 1:
                                            MMainCharacter.Instance.LocationX++;
                                            break;
                                        case 2:
                                            MMainCharacter.Instance.LocationX--;
                                            break;
                                        case 3:
                                            MMainCharacter.Instance.LocationY++;
                                            break;
                                        case 4:
                                            MMainCharacter.Instance.LocationY--;
                                            break;
                                    }
                            }
                            // 发生交互
                            item.Interact();
                        }
                    }
                    // 与敌人碰撞
                    if(!hit)
                        foreach(MEnemy enemy in currentLevel.Enemies)
                        {
                            if (enemy.LocationX == MMainCharacter.Instance.LocationX && enemy.LocationY == MMainCharacter.Instance.LocationY)
                            {
                                CombatMode(enemy);
                            }
                        }
                }
                if (IsGameOver) break;     // 若游戏结束，则退出循环，关闭线程
            }
        }
    }
}
