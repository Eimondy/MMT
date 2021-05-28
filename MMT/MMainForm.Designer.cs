
namespace MMT
{
    partial class MMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary> 
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MMT.Properties.Resources.Img_start;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1254, 569);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MMainForm";
            this.Text = "MyMagicTower";
            this.Load += new System.EventHandler(this.MMainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MMainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MMainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MMainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MMainForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

