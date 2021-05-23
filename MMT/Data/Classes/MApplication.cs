using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MMT.Data.Classes;

namespace MMT
{
    static class MApplication
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            MMainLogic Logic = MMainLogic.Instance;
            Logic.GameInit();
            //MMainForm Form = MMainForm.Instance;
            //Form.GameInit();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MMainForm());
        }
    }
}
