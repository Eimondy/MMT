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
        private bool exit;//true为出口，false为上一关入口
        public bool Exit { get => exit; set => exit = value; }
        //构造函数
        public MExit(byte locationX, byte locationY, bool exit = false) : base(locationX, locationY)
        {
            if (exit)
            {
                Name = "出口";
                //Image=new Bitmap();
            }
            else
            {
                Name = "入口";
                //Image=new Bitmap();
            }
            Exit = exit;
            Image = Properties.Resources.Img_item_Exit;
        }

        public override void Interact()
        {
            if (exit)
            {
                MLevel.IntoNextLevel();
            }
            else
            {
                MLevel.IntoLastLevel();
            }
        }
    }
}

