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
            this.lbl_Lose.Text = "你被[" + MMainLogic.Instance.CurEnemy.Name + "]击败";
        }
    }
}
