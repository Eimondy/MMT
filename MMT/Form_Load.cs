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
        public Form_Load()
        {
            InitializeComponent();
            this.Table_Load.RowCount = MMainLogic.Instance.Saves.Count;
            for (int i = 0; i < Table_Load.RowCount; i++)
                this.Table_Load.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77f));
            Label[] tx = new Label[MMainLogic.Instance.Saves.Count];
            Label[] tx1 = new Label[MMainLogic.Instance.Saves.Count];
            for (int i = 0; i < Table_Load.RowCount; i++)
            {
                tx[i] = new Label();
                tx[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                tx[i].AutoSize = true;
                tx[i].Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tx[i].ForeColor = System.Drawing.Color.White;
                tx1[i] = new Label();
                tx1[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                tx1[i].AutoSize = true;
                tx1[i].Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                tx1[i].ForeColor = System.Drawing.Color.White;
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
            //MMainLogic.Instance.Start(num);     // 读取选中的存档并开始游戏
            this.Hide();
        }

        private void btn_Load_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();            
            if (MMainLogic.Instance.Paused)
            {
                MMainForm.Instance.Picturebox_MainMenu.Hide();
                MMainForm.Instance.Fs.Show();
                MMainForm.Instance.Picturebox_Map.Show();
                MMainForm.Instance.PictureBox_Inventory.Show();
            }
            else {
                MMainForm.Instance.MainMenu();
            }
        }

        private void Table_Load_Paint(object sender, PaintEventArgs e)
        {
            // 若无存档，则不可点击确认
            if (MMainLogic.Instance.Saves.Count == 0)
                btn_Load_Confirm.Enabled = false;
            else
                btn_Load_Confirm.Enabled = true;
        }
    }
}
