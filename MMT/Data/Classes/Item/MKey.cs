using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    public class MKey :MItem
    {
        private byte relatedDoor;//和钥匙对应的门
        public byte RelatedDoor { get => relatedDoor; set => relatedDoor = value; }
        //构造函数
        public MKey(string name, Bitmap image, byte locationX, byte locationY,byte relatedDoor):base(name,image,locationX,locationY)
        {
            RelatedDoor = relatedDoor;
        }
        public MKey(MKey key) : base(key.Name, key.Image, key.LocationX, key.LocationY)
        {
           RelatedDoor = key.RelatedDoor;
        }
        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
