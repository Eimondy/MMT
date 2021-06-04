using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MMT.Data.Classes;

namespace MMT
{
    static class MApplication
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AllocConsole();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MMainLogic Logic = MMainLogic.Instance;
            Logic.GameInit();
            MMainForm Form = MMainForm.Instance;
            //Form.GameInit();
            Thread GameThread = new Thread(new ThreadStart(MMainLogic.Instance.GameLoop));
            GameThread.Name = "Logic";
            GameThread.Start();
            Thread.CurrentThread.Name = "Form";
            Application.Run(Form);
            // 安全地关闭GameThread。通过退出游戏的按钮退出时，将自动关闭窗体、调用GameOver()
            if (!MMainLogic.Instance.IsGameOver)     // 若窗体异常关闭，则主动调用GameOver()，安全结束GameThread
                MMainLogic.Instance.GameOver();

            FreeConsole();
        }
    }

    public static class Shell
    {
        delegate void WRITE(string text);
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToString(), text);
            Console.ForegroundColor = ConsoleColor.White;
            if(MMainLogic.Instance.IsInGame)
                MMainForm.Instance.BeginInvoke(new WRITE(MMainForm.Instance.Write), text);
        }
    }
}
