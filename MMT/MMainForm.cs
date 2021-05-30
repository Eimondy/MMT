using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMT
{
    public partial class MMainForm : Form
    {
        private static MMainForm instance;
        private Graphics g;
        public static MMainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MMainForm();
                    return instance;
                }
                else
                    return instance;
            }
        }
        public Graphics G { get { return g; } }
        public MMainForm()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        public void GameInit() { 
                
        }

        public void GameStart() { 
        
        }

        public void MainMenu() { 
        
        }

        public void LoadMenu() { 
        
        }

        public void SettingMenu() { 
        
        }

        public void PausedMenu() { 
        
        }

        public void CombatMenu() { 
        
        }

        public void EndingMenu() { 
        
        }

        private void MMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = true;
            MMainLogic.Instance.KeyboardData = e.KeyData;
            if (e.KeyData == Keys.D0)
                MMT.Data.Classes.Character.MMainCharacter.Instance.AttackChoice = 0;
        }

        private void MMainForm_Paint(object sender, PaintEventArgs e)     // 绘制事件
        {
            MMainLogic.Instance.Draw();
        }

        private void MMainForm_SizeChanged(object sender, EventArgs e)     // 更改窗体大小时，重设画布
        {
            g = this.CreateGraphics();
        }

        private void MMainForm_KeyUp(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = false;
        }

        private void MMainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_MainMenu_Start_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.Start(0, "TEST");
        }

        private void btn_MainMenu_Load_Click(object sender, EventArgs e)
        {

        }

        private void btn_MainMenu_Exit_Click(object sender, EventArgs e)
        {

        }
    }
}
