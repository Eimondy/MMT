using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT
{
    class MGameProfile
    {
        private string playerName;
        private int playedTime;
        private MMainCharacter character;
        private int currentLevelNumber;
        private List<MLevel> existLevels;
        private int defeatedCount;
        private int doorCount;
        private List<MItem> itemCount;

        public string PlayerName { get { return playerName; } }
        public int PlayedTime { get { return playedTime; } }
        public MMainCharacter Character { get { return character; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } }
        public List<MLevel> ExistLevels { get { return existLevels; } }
        public int DefeatedCount { get { return defeatedCount; } }
        public int DoorCount { get { return doorCount; } }
        public List<MItem> ItemCount { get { return itemCount; } }
        public MGameProfile()
        {

        }
    }
}
