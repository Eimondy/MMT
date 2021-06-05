﻿using System;
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
            {
                this.Table_Load.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, this.Width * 0.333334f));
            }
        }

        public static void addTableElement(TableLayoutPanel tbp,string s1,string s2)
        {
            Label tx1 = new Label();
            tx1.Anchor = System.Windows.Forms.AnchorStyles.None;
            tx1.AutoSize = true;
            tx1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tx1.ForeColor = System.Drawing.Color.White;
            tx1.Text = s1;
            tbp.Controls.Add(tx1, 0, tbp.RowCount - 1);
        }


        private void btn_Load_Confirm_Click(object sender, EventArgs e)
        {

        }

        private void btn_Load_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Table_Load_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}