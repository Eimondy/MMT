using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Item
{
    [Serializable]
    public class MDoor : MItem
    {
        private byte relatedKey;//和门对应的钥匙
        public byte RelatedKey { get => relatedKey; set => relatedKey = value; }
        //构造函数
        public MDoor(byte locationX, byte locationY, byte relatedKey) : base(locationX, locationY)
        {
            Name = "门";
            RelatedKey = relatedKey;
            if (RelatedKey == 14)
                Image = Properties.Resources.Img_item_Door5;
            else if (RelatedKey <= 3)
                Image = Properties.Resources.Img_item_Door1;
            else if (RelatedKey <= 6 && RelatedKey>3)
                Image = Properties.Resources.Img_item_Door2;
            else if (RelatedKey <= 9 && RelatedKey>6)
                Image = Properties.Resources.Img_item_Door3;
            else if (RelatedKey <= 13 && RelatedKey>9)
                Image = Properties.Resources.Img_item_Door4;
        }
        public override void Interact()
        {
            if(MMainCharacter.Instance.Keys.Find(key => key.RelatedDoor == RelatedKey) != null)
            {
                MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
                MMainLogic.Instance.CurrentProfile.DoorCount++;//将所开的门类信息加一
                Shell.WriteLine(string.Format("开启{0}号门", RelatedKey), ConsoleColor.Yellow);
            }
        }
    }
}
