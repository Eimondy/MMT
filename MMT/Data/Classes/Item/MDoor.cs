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
            Shell.WriteLine(string.Format("这是{0}号门", RelatedKey), ConsoleColor.Yellow);
            MKey key = MMainCharacter.Instance.Keys.Find(k => k.RelatedDoor == RelatedKey);
            if (key != null)
            {
                // 从关卡中移除门
                MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
                // 从背包中移除对应钥匙
                MMainCharacter.Instance.Keys.Remove(key);
                // 将所开的门类信息加一
                MMainLogic.Instance.CurrentProfile.DoorCount++;
                Shell.WriteLine(string.Format("开启{0}号门", RelatedKey), ConsoleColor.Yellow);
                // 与窗体通信更新装备栏
                MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.UpdateEquipment));
            }
        }
    }
}
