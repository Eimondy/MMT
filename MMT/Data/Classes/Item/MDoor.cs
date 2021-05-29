using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    public class MDoor : MItem
    {
        private byte relatedKey;//和门对应的钥匙
        public byte RelatedKey { get => relatedKey; set => relatedKey = value; }
        //构造函数
        public MDoor(byte locationX, byte locationY, byte relatedKey) : base(locationX, locationY)
        {
            Name = "门";
            //Image=new Bitmap();
            RelatedKey = relatedKey;
        }
        public override void Interact()
        {
            MMainLogic.Instance.CurrentProfile.DoorCount++;//将所开的门类信息加一
        }
    }
}
