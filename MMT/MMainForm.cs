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
    public partial class MMainForm : Form
    {
        private static MMainForm instance;
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
        public MMainForm()
        {
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)     // 绘制事件
        {
            base.OnPaint(e);
            MMainLogic.Instance.Draw();
        }

        private void MMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.X)
                MMainLogic.Instance.Exit();
        }
    }
}
