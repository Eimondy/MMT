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

        public Form_Status Fs { get => fs; set => fs = value; }
        public Form_Load Fl { get => fl; set => fl = value; }
        public Form_Pause Fp { get => fp; set => fp = value; }
        public Form_Battle Fb { get => fb; set => fb = value; }

        public MMainForm()
        {
            InitializeComponent();

            fs = new Form_Status();
            Fs.MdiParent = this;

            fl = new Form_Load();
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

            // 绘制属性背景
            int attrMargin = 0;
            Bitmap attrImg = new Bitmap(Fs.Width, Fs.Height);
            Graphics attrG = Graphics.FromImage(attrImg);
            int xBlock = (Fs.Width - 2 * attrMargin) / x + 1, yBlock = (Fs.Height - 2 * attrMargin) / x + 1;
            for(int i = 0;i<xBlock;i++)
            {
                for(int j = 0; j < yBlock; j++)
                {
                    if (i == 0 || i == xBlock - 1 || j == 0 || j == yBlock - 1)
                        attrG.DrawImage(wall, x * i, x * j, x, x);
                    else
                        attrG.DrawImage(ground, x * i, x * j, x, x);
                }
            }
            Fs.BackgroundImage = attrImg;
            // 绘制装备栏背景
            int invMargin = 0;
            Bitmap invImg = new Bitmap(PictureBox_Inventory.Width, PictureBox_Inventory.Height);
            Graphics invG = Graphics.FromImage(invImg);
            int xBlockInv = (PictureBox_Inventory.Width - 2 * invMargin) / x + 1, yBlockInv = (PictureBox_Inventory.Height - 2 * invMargin) / x + 1;
            for (int i = 0; i < xBlockInv; i++)
            {
                for (int j = 0; j < yBlockInv; j++)
                {
                    if (i == 0 || i == xBlockInv - 1 || j == 0 || j == yBlockInv - 1)
                        invG.DrawImage(wall, x * i, x * j, x, x);
                    else
                        invG.DrawImage(ground, x * i, x * j, x, x);
                }
            }
            PictureBox_Inventory.Image = invImg;
        }

        public void GameStart() 
        {
            this.Picturebox_MainMenu.Hide();
            this.PictureBox_Inventory.Visible = true;
            Fs.Show();
            Fs.Height = this.Height;
            Draw();
        }

        public void MainMenu() 
        {
            this.PictureBox_Inventory.Hide();
            this.Picturebox_Map.Hide();
            this.Picturebox_MainMenu.Show();
            Fs.Hide();
        }

        public void LoadMenu() 
        {/*
            this.PictureBox_Inventory.Visible = false;
            this.lbl_MainMenu_MagicTower.Visible = false;
            this.btn_MainMenu_Exit.Visible = false;
            this.btn_MainMenu_Load.Visible = false;
            this.btn_MainMenu_Start.Visible = false;     */
            if (!MMainLogic.Instance.Paused)
            {
                Fl.Show();
                Fl.BringToFront();
            }
            else {
                Fs.Hide();
                this.Picturebox_Map.Hide();
                this.PictureBox_Inventory.Hide();
                this.Picturebox_MainMenu.Show();
                Fl.Show(); 
                Fl.BringToFront();
            }
        }

        public void PausedMenu() 
        {
            Fp.Picturebox_Load_menu.Parent = this.Picturebox_Map;
            Fp.Picturebox_Load_menu.Show();
            Fp.Picturebox_Load_menu.Location=new Point((Picturebox_Map.Width - Fp.Width) / 2, (Picturebox_Map.Height - Fp.Height) / 2);
            /*
           Fp.Show();
           Fp.BringToFront();
           // 设置位置
           Fp.BackgroundImage = this.Picturebox_Map.Image;
           Fp.Picturebox_Load_menu.Parent = this.Picturebox_Map;
           Fp.SendToBack();
           //Fp.Picturebox_Load_menu.Location = new Point((Width - Fp.Width) / 2, (Height - Fp.Height) / 2);
           */
        }

        public void ShowCombatMenu(object[] enemy) 
        {
            fb = new Form_Battle(enemy[0]);
            Fb.panel1.Parent = this.Picturebox_Map;
            Fb.panel1.Location=new Point((Picturebox_Map.Width - Fb.panel1.Width) / 2, (Picturebox_Map.Height - Fb.panel1.Height) / 2);
            Fb.panel1.Show();
            Fb.panel1.BringToFront();
        }

        public void UpdateCombatMenu(object[] choice)
        {
            if(Fb != null)
                Fb.UpdateCombatMenu(choice);
        }
        public void CloseCombatMenu()
        {
            Fb.panel1.Hide();
            Fb = null;
        }
        public void EndingMenu() 
        {
            // 根据MMainLogic的Victory和Defeated来显示
            if (MMainLogic.Instance.Victory)
            {
                Form_Win Fw = new Form_Win();
                Fw.Picturebox_Win.Parent = this.Picturebox_Map;
                Fw.Picturebox_Win.Location = new Point((Picturebox_Map.Width - Fw.Picturebox_Win.Width) / 2, (Picturebox_Map.Height - Fw.Picturebox_Win.Height) / 2);
                Fw.Picturebox_Win.Show();
                Fw.Picturebox_Win.BringToFront();
            }
            else if(MMainLogic.Instance.Defeated)
            {
                Form_Lose Flose = new Form_Lose();
                Flose.Picturebox_Lose.Parent = this.Picturebox_Map;
                Flose.Picturebox_Lose.Location = new Point((Picturebox_Map.Width - Flose.Picturebox_Lose.Width) / 2, (Picturebox_Map.Height - Flose.Picturebox_Lose.Height) / 2);
                Flose.Picturebox_Lose.Show();
                Flose.Picturebox_Lose.BringToFront();
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
            MMainCharacter.Instance.MaxHP = 1;
            MMainCharacter.Instance.Speed = -1;
            this.GameStart();
        }

        private void btn_MainMenu_Load_Click(object sender, EventArgs e)
        {
            if(MMainLogic.Instance.Saves.Count!=0) 
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
