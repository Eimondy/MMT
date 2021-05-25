using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;

namespace MMT
{
    public class MMainLogic
    {
        private static MMainLogic instance;
        private List<MGameProfile> saves = new List<MGameProfile>();
        private MGameProfile currentProfile = null;
        private bool paused = false;
        private bool combat = false;
        private bool victory = false;
        private bool defeated = false;
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
            
        }

        public void Draw()
        {

        }

        public void Start()
        {

        }

        public void Exit()
        {
            MMainForm.Instance.Dispose();
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
                bf.Serialize(fs, CurrentProfile);
            }
            // 更新Saves
            Saves.Add(CurrentProfile);
        }

        public void CombatMode(MCharacter enemy)     // 类型后续需改为MEnemy
        {
            Combat = true;
            bool fightOver = false;
            // 比较速度判出先后手
            MCharacter currentOne = null;
            // 将主角的HP、MP、Power提到Max值
            while (!fightOver)
            {
                if(currentOne is MMainCharacter)     // 主角的轮次。若30秒之内不攻击，则使用普通攻击。
                {
                    int i = 0;
                    while (i < 30)               // 后续需更改。等待MMAinCharacter的新增属性AttackChoice : int
                    {
                        Thread.Sleep(1000);
                        i++;
                    }
                    // 根据AttackChoice来进行攻击操作

                    // 判断对方血量、是否胜利
                }
                else     // 敌人的轮次
                {
                    // 随机选择技能进行攻击操作

                    // 判断对方血量、是否胜利
                }
            }
            Combat = false;
            // 若主角战败，则调用DefeatedMode()

            // 若敌人为关底Boss，则调用VictoryMode()
        }

        public void VictoryMode()
        {
            Victory = true;
            // 调用MMainForm.Instance.EndingMenu()
            // 展示统计信息
        }

        public void DefeatedMode()
        {
            Defeated = true;
            // 调用MMainForm.Instance.EndingMenu()
        }

        public void StarFromCurrentLevel()     // 战斗失败之后，从当前关卡重玩
        {

        }

        public void BackToMainMenu()     // 游戏胜利之后/战斗失败之后，返回主菜单
        {

        }

        public void GameLoop()
        {

        }
    }
}
