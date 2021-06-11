using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
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
        private Form_Create fc;
        private List<Button> equipped;
        private List<Button> equipment;
        private List<Label> lblEquipped;
        private bool repaintAttrInv = false;
        private byte lastLv = 0;
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
        public Form_Create Fc { get => fc; set => fc = value; }
        public List<Button> Equipped { get => equipped; }
        public List<Button> Equipment { get => equipment; }
        public List<Label> LblEquipped { get => lblEquipped; }

        public MMainForm()
        {
            InitializeComponent();
            // 602
            fs = new Form_Status();
            Fs.MdiParent = this;

            fl = new Form_Load();
            Fl.TopLevel = false;
            Fl.Parent = this.Picturebox_MainMenu;

            fp = new Form_Pause();
            Fp.TopLevel = false;
            Fp.Parent = this;

            fc = new Form_Create();

            InitEquipBtn();

            player.enableContextMenu = false;
            player.settings.setMode("loop", true);
            // player.settings.volume = 100;     // 播放音量
            SwitchBGM(0);
        }

        public void SwitchBGM(int n)     // 0 - menu, 1 - game, 2 - combat, 3 - end
        {
            string url = "";
            switch (n)
            {
                case 0:
                    url = System.IO.Path.GetFullPath(@"..\..\Data\Sound\Main.mp3");
                    break;
                case 1:
                    url = System.IO.Path.GetFullPath(@"..\..\Data\Sound\GameScreen.mp3");
                    break;
                case 2:
                    url = System.IO.Path.GetFullPath(@"..\..\Data\Sound\Combat.mp3");
                    break;
                case 3:
                    url = System.IO.Path.GetFullPath(@"..\..\Data\Sound\Ending.mp3");
                    break;
            }
            player.URL = url;
            player.Ctlcontrols.play();
        }

        public void UpdateEquipped()
        {
            int total = MMainCharacter.Instance.Equipped.Count;
            for (int i = 0; i < 4; i++)
            {
                if (i < total && total <= 4)
                {
                    Equipped[i].BackgroundImage = MMainCharacter.Instance.Equipped[i].Image;
                    LblEquipped[i].Text = MMainCharacter.Instance.Equipped[i].Name;
                    ToolTip_.SetToolTip(Equipped[i], MMainCharacter.Instance.Equipped[i].ToString());
                }
                else
                {
                    Equipped[i].BackgroundImage = Properties.Resources.Img_slot;
                    LblEquipped[i].Text = "";
                    ToolTip_.SetToolTip(Equipped[i], "");
                }
            }
        }

        public void UpdateEquipment()
        {
            int total = MMainCharacter.Instance.Equipment.Count + MMainCharacter.Instance.Keys.Count;
            for(int i = 0; i < 28; i++)
            {
                if (i < total && total <=28)
                {
                    int idx = i;
                    Equipment[i].Visible = true;
                    if (i >= MMainCharacter.Instance.Equipment.Count)     // 装钥匙
                    {
                        idx = i - MMainCharacter.Instance.Equipment.Count;
                        Equipment[i].BackgroundImage = MMainCharacter.Instance.Keys[idx].Image;
                        ToolTip_.SetToolTip(Equipment[i], MMainCharacter.Instance.Keys[idx].ToString());
                    }
                    else     // 装装备
                    {
                        Equipment[i].BackgroundImage = MMainCharacter.Instance.Equipment[idx].Image;
                        ToolTip_.SetToolTip(Equipment[i], MMainCharacter.Instance.Equipment[idx].ToString());
                    }
                }
                else
                {
                    Equipment[i].Visible = false;
                    Equipment[i].BackgroundImage = Properties.Resources.Img_slot;
                }
            }
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
                    // 绘制地图
                    if (CurLevel.Map.Content[i, j] == BLOCKS.WALL)
                        cur.DrawImage(wall, x * j, x * i, x, x);
                    else
                        cur.DrawImage(ground, x * j, x * i, x, x);
                }
            }
            // 若地图材质变化，则重绘属性栏与背包栏
            if (lastLv != MLevel.CurrentLevel)
            {
                lastLv = Convert.ToByte(MLevel.CurrentLevel);
                repaintAttrInv = true;
            }
            // 绘制物品
            foreach (var o in MLevel.Levels[MLevel.CurrentLevel - 1].Items)
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

            if (repaintAttrInv)
            {
                // 绘制属性背景
                int attrMargin = 0;
                Bitmap attrImg = new Bitmap(Fs.Width, Fs.Height);
                Graphics attrG = Graphics.FromImage(attrImg);
                int xBlock = (Fs.Width - 2 * attrMargin) / x + 1, yBlock = (Fs.Height - 2 * attrMargin) / x + 1;
                for (int i = 0; i < xBlock; i++)
                {
                    for (int j = 0; j < yBlock; j++)
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
                repaintAttrInv = false;
            }
        }

        public void GameStart() 
        {
            UpdateEquipped();
            UpdateEquipment();
            this.Picturebox_MainMenu.Hide();
            this.PictureBox_Inventory.Visible = true;
            this.Panel_Message_F.Visible = true;
            Fs.Show();
            Fs.Height = this.Height;
            Fs.Location = new Point(0, 0);
            SwitchBGM(1);
            Draw();
        }

        public void MainMenu()
        {
            this.Panel_Message_F.Hide();
            this.PictureBox_Inventory.Hide();
            this.Picturebox_Map.Hide();
            this.Picturebox_MainMenu.Show();
            SwitchBGM(0);
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
            SwitchBGM(2);
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
            SwitchBGM(1);
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
            SwitchBGM(3);
        }

        private void InitEquipBtn()
        {
            equipped = new List<Button>()
            {
                equipped_1, equipped_2, equipped_3, equipped_4
            };
            equipment = new List<Button>()
            {
                equipment_1, equipment_2, equipment_3, equipment_4, equipment_5, equipment_6, equipment_7,
                equipment_8, equipment_9, equipment_10, equipment_11, equipment_12, equipment_13, equipment_14,
                equipment_15, equipment_16, equipment_17, equipment_18, equipment_19, equipment_20, equipment_21,
                equipment_22, equipment_23, equipment_24, equipment_25, equipment_26, equipment_27, equipment_28
            };
            lblEquipped = new List<Label>()
            {
                lbl_equipped_1, lbl_equipped_2, lbl_equipped_3, lbl_equipped_4
            };
            // 绑定事件
            foreach(var b in Equipped)
            {
                b.Click += new EventHandler(EquippedBtnClick);
            }
            foreach(var b in Equipment)
            {
                b.Click += new EventHandler(EquipmentBtnClick);
            }
        }

        private void EquippedBtnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int idx = int.Parse(b.Name.Split('_')[1]) - 1;
            // 若有装备则卸下，否则返回
            if (idx >= MMainCharacter.Instance.Equipped.Count) return;
            MMainCharacter.Instance.Equipped[idx].Unequip();
            // 更新装备栏
            UpdateEquipped();
        }

        private void EquipmentBtnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int idx = int.Parse(b.Name.Split('_')[1]) - 1;
            // 若为装备则穿戴
            if (idx >= MMainCharacter.Instance.Equipment.Count) return;
            MMainCharacter.Instance.Equipment[idx].Equip();
            // 更新装备栏
            UpdateEquipped();
        }


        private void MMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = true;
            MMainLogic.Instance.KeyboardData = e.KeyData;
            if (e.KeyData == Keys.D0)
                MMT.Data.Classes.Character.MMainCharacter.Instance.AttackChoice = 0;
        }

        private void MMainForm_KeyUp(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = false;
        }

        private void btn_MainMenu_Start_Click(object sender, EventArgs e)
        {
            Fc.TopLevel = false;
            Fc.Parent = this.Picturebox_MainMenu;
            Fc.Show();
            Fc.BringToFront();
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
            /*
            bool scroll = false;
            if (listBox_Message.TopIndex == listBox_Message.Items.Count - (int)(listBox_Message.Height / listBox_Message.ItemHeight))
                scroll = true;
            listBox_Message.Items.Add(info);
            if (scroll)
                listBox_Message.TopIndex = listBox_Message.Items.Count - (int)(listBox_Message.Height / listBox_Message.ItemHeight);
            */
            Label l = new Label();
            l.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            l.BackColor = Color.Transparent;
            l.AutoSize = false;
            l.Size = new Size(358, 20);
            l.Location = new Point(15, Panel_Message.Controls.Count * 20 + 10);
            l.Text = info;
            l.Font = new Font("幼圆", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            l.Name = "Label_Message_" + (Panel_Message.Controls.Count + 1).ToString();
            Panel_Message.Controls.Add(l);
            Panel_Message.VerticalScroll.Value = Panel_Message.VerticalScroll.Maximum;
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
