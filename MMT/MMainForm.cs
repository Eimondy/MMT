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
        private Form_Status Fs;
        private Form_Load Fl;
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
            //this.Panel_Inventory.Visible = false;
            Fs = new Form_Status();
            Fs.MdiParent = this;
            Fl = new Form_Load();
            Fl.MdiParent = this;
            Fl.TopLevel = false;
            Fl.Parent = this.Picturebox_MainMenu;  
        }

        public void Draw()
        {
            Bitmap b = new Bitmap(this.Picturebox_Map.Width, this.Picturebox_Map.Height);
            Graphics cur = Graphics.FromImage(b);
            if (MLevel.CurrentLevel - 1 >= MLevel.Levels.Count)     // 解决双线程变量共享读失败问题
                return;
            MLevel CurLevel = MLevel.Levels[MLevel.CurrentLevel - 1];
            var x = this.Picturebox_Map.Width / CurLevel.Map.Size;
            Image ground = null, wall = null;
            for (int i = 0; i < CurLevel.Map.Size; i++)
            {
                for (int j = 0; j < CurLevel.Map.Size; j++)
                {
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
            // 绘制物品
            foreach(var o in MLevel.Levels[MLevel.CurrentLevel - 1].Items)
                cur.DrawImage(o.Image, x * (o.LocationY - 1), x * (o.LocationX - 1), x, x);
            // 绘制敌人
            foreach (var o in MLevel.Levels[MLevel.CurrentLevel - 1].Enemies)
                cur.DrawImage(o.Image, x * (o.LocationY - 1), x * (o.LocationX - 1), x, x);
            // 绘制人物
            cur.DrawImage(MMainCharacter.Instance.Image, x * (MMainCharacter.Instance.LocationY - 1), x * (MMainCharacter.Instance.LocationX - 1), x, x);

            this.Picturebox_Map.Image = b;
            this.Picturebox_Map.Show();
        }

        public void GameStart() 
        {
            this.Picturebox_MainMenu.Hide();
            this.PictureBox_Inventory.Visible = true;
            Fs.Show();
            Draw();
        }

        public void MainMenu() 
        {
            
        }

        public void LoadMenu() 
        {
            this.PictureBox_Inventory.Visible = false;
            this.lbl_MainMenu_MagicTower.Visible = false;
            this.btn_MainMenu_Exit.Visible = false;
            this.btn_MainMenu_Load.Visible = false;
            this.btn_MainMenu_Start.Visible = false;     
            Fl.Show();
            Fl.BringToFront();
        }

        public void PausedMenu() 
        { 
        
        }

        public void SettingMenu() 
        { 
        
        }

        public void ShowCombatMenu() 
        {
            Form_Battle Fb = new Form_Battle();
            Fb.TopLevel = false;
            Fb.Parent = this;
            Fb.Show();
            Fb.BringToFront();
        }

        public void UpdateCombatMenu(byte[] choices)
        {

        }
        public void CloseCombatMenu()
        {

        }
        public void EndingMenu() 
        { 
            // 根据MMainLogic的Victory和Defeated来显示
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
            LoadMenu();
        }

        private void btn_MainMenu_Exit_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.Exit();
        }

        public void Write(string info)
        {
            bool scroll = false;
            if (listBox_Message.TopIndex == listBox_Message.Items.Count - (int)(listBox_Message.Height / listBox_Message.ItemHeight))
                scroll = true;
            listBox_Message.Items.Add(info);
            if(scroll)
                listBox_Message.TopIndex = listBox_Message.Items.Count - (int)(listBox_Message.Height / listBox_Message.ItemHeight);
        }

        private void Panel_Inventory_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
