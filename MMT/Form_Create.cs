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
    public partial class Form_Create : Form
    {
        public Form_Create()
        {
            InitializeComponent();
        }

        private void btn_Create_Confirm_Click(object sender, EventArgs e)
        {
            if (textBox_Create.Text == "") return;
            this.Hide();
            MMainLogic.Instance.Start(0, textBox_Create.Text);

            //MMainCharacter.Instance.MaxHP = 1;
            //MMainCharacter.Instance.Speed = -1;

            MMainForm.Instance.GameStart();
        }

        private void btn_Create_Cancel_Click(object sender, EventArgs e)
        {
            textBox_Create.Text = "";
            this.Hide();
            //MMainForm.Instance.MainMenu();
        }
    }
}
