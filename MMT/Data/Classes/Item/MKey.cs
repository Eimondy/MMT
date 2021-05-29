using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMT.Data.Classes.Character;

namespace MMT.Data.Classes.Item
{
    class MKey : MItem, MIPickable
    {

        private byte relatedDoor;//和钥匙对应的门
        public byte RelatedDoor { get => relatedDoor; set => relatedDoor = value; }
        //构造函数
        public MKey(byte locationX, byte locationY, byte relatedDoor) : base(locationX, locationY)
        {
            Name = "钥匙";
            //Image=new Bitmap();
            RelatedDoor = relatedDoor;
        }

        public override void Interact()
        {
            // 执行父类的交互操作，将钥匙记录到GameProfile当中
            base.Interact();
            Picked();
        }

        public void Picked()
        {
            // 将该钥匙放入主角的钥匙栏中
            MMainCharacter.Instance.Keys.Add(this);
            // 将该钥匙从关卡中移除
            MLevel.Levels[MLevel.CurrentLevel - 1].Items.Remove(this);
        }
    }
}
