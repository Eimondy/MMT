using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MMT
{
    class MMainLogic
    {
        private static MMainLogic instance;
        private List<MGameProfile> saves;
        private MGameProfile currentProfile;
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
                 // load all saves from disk into Saves
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

        }

        public void NewGame()
        {

        }

        public void LoadProfile(int number)     //untested
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = @"..\..\Saves\Saves_" + number.ToString() + ".save";
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                CurrentProfile = new MGameProfile((MGameProfile)bf.Deserialize(fs));
            }
        }

        public void SaveProfile()     // untested
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = @"..\..\Saves\Saves_" + (Saves.Count + 1).ToString() + ".save";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, CurrentProfile);
            }
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
