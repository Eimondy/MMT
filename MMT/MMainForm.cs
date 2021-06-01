using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMT.Data.Classes;
using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;

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

        public void Draw()
        {
            Bitmap b = new Bitmap(this.Picturebox_Map.Width, this.Picturebox_Map.Height);
            Graphics cur = Graphics.FromImage(b);
            MLevel CurLevel = MLevel.Levels[MLevel.CurrentLevel - 1];
            var x = this.Picturebox_Map.Width / CurLevel.Map.Size;
            Image ground = null, wall = null;
            for (int i = 0; i < CurLevel.Map.Size; i++)
            {
                for (int j = 0; j < CurLevel.Map.Size; j++)
                {
                    //Console.WriteLine(System.Environment.CurrentDirectory);
                    switch ((MLevel.CurrentLevel - 1) / 4)
                    {
                        case 0:
                            ground = Properties.Resources.Img_ground1;
                            wall = Properties.Resources.Img_wall1;
                            break;
                        case 1:
                            ground = Properties.Resources.Img_ground2;
                            wall = Properties.Resources.Img_wall2;
                            break;
                        case 2:
                            ground = Properties.Resources.Img_ground3;
                            wall = Properties.Resources.Img_wall3;
                            break;
                        case 3:
                            ground = Properties.Resources.Img_ground4;
                            wall = Properties.Resources.Img_wall4;
                            break;
                    }
                    if (CurLevel.Map.Content[i, j] == BLOCKS.WALL)
                        cur.DrawImage(wall, x * j, x * i, x, x);
                    else
                        cur.DrawImage(ground, x * j, x * i, x, x);
                }
            }

            cur.DrawImage(MMainCharacter.Instance.Image, x * (MMainCharacter.Instance.LocationY - 1), x * (MMainCharacter.Instance.LocationX - 1), x, x);

            this.Picturebox_Map.Image = b;
            this.Picturebox_Map.Show();
        }

        public void GameStart() {
            this.Picturebox_MainMenu.Hide();
            Form_Status Fs = new Form_Status();
            Fs.MdiParent = this;
            Fs.Show();
            Draw();
        }

        public void MainMenu() {
            Picturebox_MainMenu.Visible = true;
        }

        public void LoadMenu() { 
            
        }

        public void PausedMenu() { 
        
        }

        public void SettingMenu() { 
        
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

        }

        private void MMainForm_SizeChanged(object sender, EventArgs e)     // 更改窗体大小时，重设画布
        {
            //g = this.CreateGraphics();
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
            this.GameStart();
        }

        private void btn_MainMenu_Load_Click(object sender, EventArgs e)
        {

        }

        private void btn_MainMenu_Exit_Click(object sender, EventArgs e)
        {

        }

    }
}
