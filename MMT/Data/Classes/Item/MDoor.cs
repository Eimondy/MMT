using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    class MDoor:MItem
    {
        private byte relatedKey;//和门对应的钥匙
        public byte RelatedKey { get => relatedKey; set => relatedKey = value; }
        //构造函数
        public MDoor(string name, Bitmap image, byte locationX, byte locationY,byte relatedKey):base(name,image,locationX,locationY)
        {
            RelatedKey = relatedKey;
        }
        public MDoor(MDoor door) : base(door.Name, door.Image, door.LocationX, door.LocationY)
        {
           RelatedKey = door.relatedKey;
        }
        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
