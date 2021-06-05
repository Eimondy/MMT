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
        private Form_Status fs;
        private Form_Load fl;
        private Form_Pause fp;
        private Form_Battle fb;
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

        public Form_Status Fs { get => fs; }
        public Form_Load Fl { get => fl; }
        public Form_Pause Fp { get => fp; }
        public Form_Battle Fb { get => fb; }

        public MMainForm()
        {
            InitializeComponent();

            fs = new Form_Status();
            Fs.MdiParent = this;

            fl = new Form_Load();
            Fl.MdiParent = this;
            Fl.TopLevel = false;
            Fl.Parent = this.Picturebox_MainMenu;

            fp = new Form_Pause();
            Fp.TopLevel = false;
            Fp.Parent = this;
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

            //更新属性和装备
            this.Fs.Form_Status_Load(null,null);
            this.PictureBox_Inventory_LoadCompleted(null,null);
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
        {/*
            this.PictureBox_Inventory.Visible = false;
            this.lbl_MainMenu_MagicTower.Visible = false;
            this.btn_MainMenu_Exit.Visible = false;
            this.btn_MainMenu_Load.Visible = false;
            this.btn_MainMenu_Start.Visible = false;     */
            Fl.Show();
            Fl.BringToFront();
        }

        public void PausedMenu() 
        {
            Fp.Show();
            Fp.BringToFront();
        }

        public void SettingMenu() 
        { 
        
        }

        public void ShowCombatMenu(object[] enemy) 
        {
            fb = new Form_Battle(enemy[0]);
            Fb.TopLevel = false;
            Fb.Parent = this;
            Fb.Show();
            Fb.BringToFront();
        }

        public void UpdateCombatMenu(object[] choice)
        {
            Fb.UpdateCombatMenu(choice);
        }
        public void CloseCombatMenu()
        {
            Fb.Close();
        }
        public void EndingMenu() 
        {
            // 根据MMainLogic的Victory和Defeated来显示
            if (MMainLogic.Instance.Victory)
            {
                Form_Win Fw = new Form_Win();
                Fw.TopLevel = false;
                Fw.Parent = this;
                Fw.Show();
                Fw.BringToFront();
            }
            else if(MMainLogic.Instance.Defeated)
            {
                Form_Lose Fl = new Form_Lose();
                Fl.TopLevel = false;
                Fl.Parent = this;
                Fl.Show();
                Fl.BringToFront();
            }
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

        private void PictureBox_Inventory_LoadCompleted(object sender, AsyncCompletedEventArgs e) //draw重绘时更新装备和背包的数据
        {
           // this.groupBox_Equipped
           // this.groupBox_Inventory
        }
    }
}
