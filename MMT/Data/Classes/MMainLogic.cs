using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<MGameProfile> Saves
        {
            get
            {
                return saves;
            }
        }
        public MGameProfile CurrentProfile
        {
            get
            {
                return currentProfile;
            }
        }
        public bool Paused { get { return paused; } set { paused = value; } }
        public bool Combat { get { return paused; } set { combat = value; } }
        public bool Victory { get { return paused; } set { victory = value; } }
        public bool Defeated { get { return paused; } set { defeated = value; } }

        public MMainLogic()
        {

        }

        public void GameInit()
        {

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

        public void LoadProfile()
        {

        }

        public void SaveProfile()
        {

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
