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
    public partial class Form_Win : Form
    {
        public Form_Win()
        {
            InitializeComponent();
        }

        private void btn_Win_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.BackToMainMenu();
            this.Close();
        }
    }
}
