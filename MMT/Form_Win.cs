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
    public partial class Form_Win : Form
    {
        public Form_Win()
        {
            InitializeComponent();
            // 设置位置
            this.Location = new Point((MMainForm.Instance.Width - Width) / 2, (MMainForm.Instance.Height - Height) / 2);
        }

        private void btn_Win_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.BackToMainMenu();
            this.Close();
        }
    }
}
