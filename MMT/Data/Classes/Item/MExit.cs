using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    [Serializable]
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
                Image = Properties.Resources.Img_item_Exit;
            }
            else
            {
                Name = "入口";
                Image = Properties.Resources.Img_item_Entrance;
            }
            Exit = exit;
            
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

