using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMT.Data.Classes.Item
{
    class MExit
    {
        private bool exit;//bool=1为出口，bool=0为上一关入口
        public bool Exit { get => exit; set => exit = value; }
        //构造函数
        public MExit(bool exit)
        {
            Exit = exit;
        }
    }
}
