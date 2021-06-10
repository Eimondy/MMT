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
    public partial class Form_Lose : Form
    {
        public Form_Lose()
        {
            InitializeComponent();
            this.lbl_Lose.Text = "你被[" + MMainLogic.Instance.DefeatedEnemy + "]击败";
        }

        private void btn_Lose_Again_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.StarFromCurrentLevel();
            MMainForm.Instance.SwitchBGM(1);
            this.Picturebox_Lose.Hide();
        }

        private void btn_Lose_Exit_Click(object sender, EventArgs e)
        {
            MMainLogic.Instance.BackToMainMenu();
            this.Picturebox_Lose.Hide();
        }
    }
}
