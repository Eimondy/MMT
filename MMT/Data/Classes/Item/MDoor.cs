using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    class MDoor
    {
        private byte relatedKey;//和门对应的钥匙
        public byte RelatedKey { get => relatedKey; set => relatedKey = value; }
        //构造函数
        public MDoor(byte relatedKey)
        {
            RelatedKey = relatedKey;
        }
    }
}
