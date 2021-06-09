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
    public class MKey : MItem, MIPickable
    {

        private byte relatedDoor;//和钥匙对应的门
        public byte RelatedDoor { get => relatedDoor; set => relatedDoor = value; }
        //构造函数
        public MKey(byte locationX, byte locationY, byte relatedDoor) : base(locationX, locationY)
        {
            Name = "钥匙";
            RelatedDoor = relatedDoor;
            if (RelatedDoor <= 3)
                Image = Properties.Resources.Img_item_Key1;
            else if (RelatedDoor >= 4 && RelatedDoor <= 6)
                Image = Properties.Resources.Img_item_Key2;
            else if (RelatedDoor >= 7 && RelatedDoor <= 9)
                Image = Properties.Resources.Img_item_Key3;
            else if (RelatedDoor >= 10 && RelatedDoor <= 13)
                Image = Properties.Resources.Img_item_Key4;
            else if (RelatedDoor == 14)
                Image = Properties.Resources.Img_item_Key5;
        }

        public override void Interact()
        {
            // 执行父类的交互操作，将钥匙记录到GameProfile当中
            base.Interact();
            Picked();
            Shell.WriteLine(string.Format("获取{0}号门的钥匙", RelatedDoor), ConsoleColor.Yellow);
        }

        public void Picked()
        {
            // 将该钥匙放入主角的钥匙栏中
            MMainCharacter.Instance.Keys.Add(this);
            // 将该钥匙从关卡中移除
            MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
            // 与窗体通信更新装备栏
            MMainForm.Instance.BeginInvoke(new Action(MMainForm.Instance.UpdateEquipment));
        }

        public override string ToString()
        {
            return string.Format("{0}号钥匙", RelatedDoor);
        }
    }
}
