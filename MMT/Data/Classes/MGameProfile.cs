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
        private MMainCharacter character = MMainCharacter.Instance;
        private int currentLevelNumber;
        private List<MLevel> existLevels;
        private int defeatedCount;
        private int doorCount;
        private List<MItem> itemCount;

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public int PlayedTime { get { return playedTime; } set { playedTime = value; } }
        public MMainCharacter Character { get { return character; } }
        public int CurrentLevelNumber { get { return currentLevelNumber; } set { currentLevelNumber = value; } }
        public List<MLevel> ExistLevels { get { return existLevels; } set { existLevels = value; } }
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
            existLevels = null;
            itemCount = null;
            character = null;
        }
        public MGameProfile(string pn, int pt = 0, int cln = 0, int dec = 0, int doc = 0, MMainCharacter c = null, List<MLevel> el = null, List<MItem> ic = null)
        {
            PlayerName = pn;
            PlayedTime = pt;
            CurrentLevelNumber = cln;
            DefeatedCount = dec;
            DoorCount = doc;
            if(el!=null)
                foreach(MLevel level in el)
                {
                    ExistLevels.Add(level);
                }
            itemCount = new List<MItem>();
            if(ic!=null)
                foreach(MItem item in ic)
                {
                    Type type = item.GetType();     // 获取动态类型
                    System.Reflection.ConstructorInfo constructor = type.GetConstructor(new Type[1] { type });     // 获取复制构造函数
                    itemCount.Add((MItem)Convert.ChangeType(constructor.Invoke(new object[1] { item }), type));     // 调用复制构造函数，将item放入列表中
                }
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
