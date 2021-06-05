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
    public partial class Form_Pause : Form
    {
        public Form_Pause()
        {
            InitializeComponent();
        }

        private void btn_Pause_Continue_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.PauseRelease();
            this.Hide();
        }

        private void btn_Pause_Save_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.SaveProfile();
        }

        private void btn_Pause_Load_Click(object sender, EventArgs e)
        {
            MMainForm.Instance.LoadMenu();
        }

        private void btn_Pause_Mainmenu_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.BackToMainMenu();
            this.Hide();
        }

        private void btn_Pause_Exit_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.Exit();
            this.Hide();
        }
    }
}
