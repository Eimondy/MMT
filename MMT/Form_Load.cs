using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMT
{
    public partial class Form_Load : Form
    {
        public List<Label> tx;
        public List<Label> tx1;
        public int saveSelected = -1;
        public Form_Load()
        {
            InitializeComponent();
            this.Table_Load.RowCount = MMainLogic.Instance.Saves.Count;
            for (int i = 0; i < Table_Load.RowCount; i++)
                this.Table_Load.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77f));
            tx = new List<Label>();
            tx1 = new List<Label>();
            for (int i = 0; i < Table_Load.RowCount; i++)
            {
                tx.Add(new Label());
                tx[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                tx[i].AutoSize = true;
                tx[i].Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tx[i].ForeColor = System.Drawing.Color.White;
                tx1.Add(new Label());
                tx1[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                tx1[i].AutoSize = true;
                tx1[i].Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tx1[i].ForeColor = System.Drawing.Color.White;
                tx1[i].Click += new EventHandler(SaveClick);
            }
            for (int i = 0; i < Table_Load.RowCount; i++)
            {
                //this.Table_Load.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77f));
                tx[i].Text = (i + 1).ToString();
                this.Table_Load.Controls.Add(tx[i], 0, i);
                tx1[i].Text = MMainLogic.Instance.Saves[i].ToString().Replace("\n"," ");
                this.Table_Load.Controls.Add(tx1[i], 1, i);
            }
        }

        private void btn_Load_Confirm_Click(object sender, EventArgs e)
        {
            btn_Load_Confirm.Enabled = false;
            this.Hide();
            if (saveSelected != -1)
                tx1[saveSelected - 1].BorderStyle = BorderStyle.None;
            MMainLogic.Instance.Start(saveSelected);     // 读取选中的存档并开始游戏
            MMainForm.Instance.GameStart();
        }

        private void btn_Load_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            btn_Load_Confirm.Enabled = false; 
            if (saveSelected != -1)
                tx1[saveSelected - 1].BorderStyle = BorderStyle.None;
            if (MMainLogic.Instance.Paused)
            {
                MMainForm.Instance.Picturebox_MainMenu.Hide();
                MMainForm.Instance.Fs.Show();
                MMainForm.Instance.Fs.Height = MMainForm.Instance.Height;
                MMainForm.Instance.Fs.Location = new Point(0, 0);
                MMainForm.Instance.Picturebox_Map.Show();
                MMainForm.Instance.PictureBox_Inventory.Show();
                MMainLogic.Instance.PauseRelease();
            }
            else 
            {
                MMainForm.Instance.MainMenu();
            }
        }

        public void AddNewSave()
        {
            int total = MMainLogic.Instance.Saves.Count;
            // 加新行
            Table_Load.RowCount++;
            Table_Load.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77f));
            // 加label
            Label _tx = new Label();
            Label _tx1 = new Label();
            _tx.Anchor = System.Windows.Forms.AnchorStyles.None;
            _tx.AutoSize = true;
            _tx.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _tx.ForeColor = System.Drawing.Color.White;
            _tx1.Anchor = System.Windows.Forms.AnchorStyles.None;
            _tx1.AutoSize = true;
            _tx1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _tx1.ForeColor = System.Drawing.Color.White;
            _tx.Text = total.ToString();
            _tx1.Text = MMainLogic.Instance.Saves[total-1].ToString().Replace("\n", " ");
            Table_Load.Controls.Add(_tx, 0, total-1);
            Table_Load.Controls.Add(_tx1, 1, total-1);
            // 绑定事件
            _tx1.Click += new EventHandler(SaveClick);
            // 加入列表
            tx.Add(_tx);
            tx1.Add(_tx1);
            
        }

        private void Table_Load_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveClick(object sender, EventArgs e)
        {
            Label l = sender as Label;
            if (saveSelected != -1)
                tx1[saveSelected - 1].BorderStyle = BorderStyle.None;
            int idx = tx1.IndexOf(l) + 1;
            btn_Load_Confirm.Enabled = true;
            saveSelected = idx;
            tx1[saveSelected - 1].BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
