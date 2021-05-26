using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMT
{
    public partial class MMainForm : Form
    {
        private static MMainForm instance;
        private Graphics g;
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
        public Graphics G { get { return g; } }
        public MMainForm()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void MMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = true;
            MMainLogic.Instance.KeyboardData = e.KeyData;
        }

        private void MMainForm_Paint(object sender, PaintEventArgs e)     // 绘制事件
        {
            MMainLogic.Instance.Draw();
        }

        private void MMainForm_SizeChanged(object sender, EventArgs e)     // 更改窗体大小时，重设画布
        {
            g = this.CreateGraphics();
        }

        private void MMainForm_KeyUp(object sender, KeyEventArgs e)
        {
            MMainLogic.Instance.KeyboardInput = false;
        }
    }
}
