using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    public class MExit : MItem
    {
        private bool exit;//bool=1为出口，bool=0为上一关入口
        public bool Exit { get => exit; set => exit = value; }
        //构造函数
        public MExit(string name, Bitmap image, byte locationX, byte locationY,bool exit=false):base(name,image,locationX,locationY)
        {
            Exit = exit;
        }

        public MExit(MExit exit) : base(exit.Name, exit.Image, exit.LocationX, exit.LocationY)
        {
            Exit = exit.Exit;
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
