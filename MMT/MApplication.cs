using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MMT.Data.Classes;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MMainLogic Logic = MMainLogic.Instance;
            Logic.GameInit();
            MMainForm Form = MMainForm.Instance;
            //Form.GameInit();
            Thread GameThread = new Thread(new ThreadStart(MMainLogic.Instance.GameLoop));
            //GameThread.Start();
            
            Application.Run(Form);
            // gently top the GameThread

        }
    }
}
