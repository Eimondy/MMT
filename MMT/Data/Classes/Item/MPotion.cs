using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    class MPotion
    {
        private int promotePoints;//产生效用的数值
        private ATTRIBUTE type;   //药剂类型
        public int PromotePoints { get => promotePoints; set => promotePoints = value; }
        internal ATTRIBUTE Type { get => type ; set => type = value; }
       
        //构造方法
        public MPotion(int promotePoints, ATTRIBUTE type) 
        {
            PromotePoints = promotePoints;
            Type = type;
        }
    }   
       
}
