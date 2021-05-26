using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    abstract class MPotion:MItem
    {
        private int promotePoints;//产生效用的数值
        private ATTRIBUTE type;   //药剂类型
        public int PromotePoints { get => promotePoints; set => promotePoints = value; }
        internal ATTRIBUTE Type { get => type ; set => type = value; }
       
        //构造方法
        public MPotion((string name, Bitmap image, byte locationX, byte locationY, int promotePoints, ATTRIBUTE type):base(name,image,locationX,locationY) 
        {
            PromotePoints = promotePoints;
            Type = type;
        }
        public MPotion(MPotion potion) : base(potion.Name, potion.Image, potion.LocationX, potion.LocationY)
        {
            PromotePoints = potion.promotePoints;
            Type = potion.type;
        }
        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }   
       
}
