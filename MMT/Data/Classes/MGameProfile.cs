﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT.Data.Classes
{
    [Serializable]
    public class MGameProfile
    {
        private string playerName;
        private int playedTime;
        private MMainCharacter character;
        private int currentLevelNumber;
        private List<MLevel> existLevels;
        private int defeatedCount;
        private int doorCount;
        private List<MItem> itemCount;

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public int PlayedTime { get { return playedTime; } set { playedTime = value; } }
        public MMainCharacter Character { get { return character; } set { character = value; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } set { currentLevelNumber = value; } }
        public List<MLevel> ExistLevels { get { return existLevels; } }     // no setter
        public int DefeatedCount { get { return defeatedCount; } set { defeatedCount = value; } }
        public int DoorCount { get { return doorCount; } set { doorCount = value; } }
        public List<MItem> ItemCount { get { return itemCount; } }     // no setter
        public MGameProfile()     // default constructor, need no Character
        {
            PlayerName = "";
            PlayedTime = 0;
            CurrentLevelNumber = 0;
            DefeatedCount = 0;
            DoorCount = 0;
            existLevels = new List<MLevel>();
            itemCount = new List<MItem>();
            character = null;
        }
        public MGameProfile(string pn, int pt = 0, int cln = 0, int dec = 0, int doc = 0, MMainCharacter c = null, List<MLevel> el = null, List<MItem> ic = null)
        {
            PlayerName = pn;
            PlayedTime = pt;
            CurrentLevelNumber = cln;
            DefeatedCount = dec;
            DoorCount = doc;
            existLevels = new List<MLevel>();
            foreach(MLevel level in el)
            {
                ExistLevels.Add(new MLevel(level));
            }
            itemCount = new List<MItem>();
            foreach(MItem item in ic)
            {
                itemCount.Add(new MItem(item));
            }
            character = new MMainCharacter(c);
        }
        public MGameProfile(MGameProfile p)     // copy constructor
        {
            PlayerName = p.PlayerName;
            PlayedTime = p.PlayedTime;
            CurrentLevelNumber = p.CurrentLevelNumber;
            DefeatedCount = p.DefeatedCount;
            DoorCount = p.DoorCount;
            existLevels = new List<MLevel>();
            foreach (MLevel level in p.ExistLevels)
            {
                ExistLevels.Add(new MLevel(level));
            }
            itemCount = new List<MItem>();
            foreach (MItem item in p.ItemCount)
            {
                itemCount.Add(new MItem(item));
            }
            character = new MMainCharacter(p.Character);
        }

        public override bool Equals(object obj)
        {
            if (obj is MGameProfile)
            {
                MGameProfile p = obj as MGameProfile;
                if (PlayerName == p.PlayerName && PlayedTime == p.PlayedTime && CurrentLevelNumber == p.CurrentLevelNumber
                    && DefeatedCount == p.DefeatedCount && DoorCount == p.DoorCount )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
