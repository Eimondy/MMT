using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    class MKey
    {
        private byte relatedDoor;//和钥匙对应的门
        public byte RelatedDoor { get => relatedDoor; set => relatedDoor = value; }
        //构造函数
        public MKey(byte relatedDoor)
        {
            RelatedDoor = relatedDoor;
        }
    }
}
