using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            //MMainForm.Instance.Close();
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

        public void CombatMode()
        {

        }

        public void VictoryMode()
        {

        }

        public void DefeatedMode()
        {

        }

        public void GameLoop()
        {

        }
    }
}
