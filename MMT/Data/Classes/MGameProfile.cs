using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

namespace MMT.Data.Classes
{
    [Serializable]
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

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public int PlayedTime { get { return playedTime; } set { playedTime = value; } }
        public MMainCharacter Character { get { return character; } set { character = value; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } set { currentLevelNumber = value; } }
        public List<MLevel> ExistLevels { get { return existLevels; } }     // 不设setter
        public int DefeatedCount { get { return defeatedCount; } set { defeatedCount = value; } }
        public int DoorCount { get { return doorCount; } set { doorCount = value; } }
        public List<MItem> ItemCount { get { return itemCount; } }     // 不设setter
        public MGameProfile()     // 默认构造函数，初始角色为null
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
                Type type = item.GetType();     // 获取动态类型
                System.Reflection.ConstructorInfo constructor = type.GetConstructor(new Type[1] { type });     // 获取复制构造函数
                itemCount.Add((MItem)Convert.ChangeType(constructor.Invoke(new object[1] { item }), type));     // 调用复制构造函数，将item放入列表中
            }
            character = new MMainCharacter(c);
        }
        public MGameProfile(MGameProfile p)     // 复制构造函数
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
                Type type = item.GetType();     // 获取动态类型
                System.Reflection.ConstructorInfo constructor = type.GetConstructor(new Type[1] { type });     // 获取复制构造函数
                itemCount.Add((MItem)Convert.ChangeType(constructor.Invoke(new object[1] { item }), type));     // 调用复制构造函数，将item放入列表中
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
