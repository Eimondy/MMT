
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
            this.Picturebox_MainMenu = new System.Windows.Forms.PictureBox();
            this.btn_MainMenu_Exit = new System.Windows.Forms.Button();
            this.btn_MainMenu_Load = new System.Windows.Forms.Button();
            this.btn_MainMenu_Start = new System.Windows.Forms.Button();
            this.lbl_MainMenu_MagicTower = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_MainMenu)).BeginInit();
            this.Picturebox_MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Picturebox_MainMenu
            // 
            this.Picturebox_MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Picturebox_MainMenu.Controls.Add(this.btn_MainMenu_Exit);
            this.Picturebox_MainMenu.Controls.Add(this.btn_MainMenu_Load);
            this.Picturebox_MainMenu.Controls.Add(this.btn_MainMenu_Start);
            this.Picturebox_MainMenu.Controls.Add(this.lbl_MainMenu_MagicTower);
            this.Picturebox_MainMenu.Image = global::MMT.Properties.Resources.Img_start;
            this.Picturebox_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.Picturebox_MainMenu.Name = "Picturebox_MainMenu";
            this.Picturebox_MainMenu.Size = new System.Drawing.Size(984, 602);
            this.Picturebox_MainMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picturebox_MainMenu.TabIndex = 5;
            this.Picturebox_MainMenu.TabStop = false;
            this.Picturebox_MainMenu.UseWaitCursor = true;
            // 
            // btn_MainMenu_Exit
            // 
            this.btn_MainMenu_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_MainMenu_Exit.FlatAppearance.BorderSize = 0;
            this.btn_MainMenu_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MainMenu_Exit.Font = new System.Drawing.Font("华文行楷", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MainMenu_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_MainMenu_Exit.Location = new System.Drawing.Point(210, 440);
            this.btn_MainMenu_Exit.Name = "btn_MainMenu_Exit";
            this.btn_MainMenu_Exit.Size = new System.Drawing.Size(480, 60);
            this.btn_MainMenu_Exit.TabIndex = 2;
            this.btn_MainMenu_Exit.Text = "退出游戏";
            this.btn_MainMenu_Exit.UseVisualStyleBackColor = false;
            this.btn_MainMenu_Exit.UseWaitCursor = true;
            this.btn_MainMenu_Exit.Click += new System.EventHandler(this.btn_MainMenu_Exit_Click);
            // 
            // btn_MainMenu_Load
            // 
            this.btn_MainMenu_Load.BackColor = System.Drawing.Color.Transparent;
            this.btn_MainMenu_Load.FlatAppearance.BorderSize = 0;
            this.btn_MainMenu_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MainMenu_Load.Font = new System.Drawing.Font("华文行楷", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MainMenu_Load.ForeColor = System.Drawing.Color.White;
            this.btn_MainMenu_Load.Location = new System.Drawing.Point(210, 350);
            this.btn_MainMenu_Load.Name = "btn_MainMenu_Load";
            this.btn_MainMenu_Load.Size = new System.Drawing.Size(480, 60);
            this.btn_MainMenu_Load.TabIndex = 1;
            this.btn_MainMenu_Load.Text = "继续游戏";
            this.btn_MainMenu_Load.UseVisualStyleBackColor = false;
            this.btn_MainMenu_Load.UseWaitCursor = true;
            this.btn_MainMenu_Load.Click += new System.EventHandler(this.btn_MainMenu_Load_Click);
            // 
            // btn_MainMenu_Start
            // 
            this.btn_MainMenu_Start.BackColor = System.Drawing.Color.Transparent;
            this.btn_MainMenu_Start.FlatAppearance.BorderSize = 0;
            this.btn_MainMenu_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MainMenu_Start.Font = new System.Drawing.Font("华文行楷", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MainMenu_Start.ForeColor = System.Drawing.Color.White;
            this.btn_MainMenu_Start.Location = new System.Drawing.Point(210, 260);
            this.btn_MainMenu_Start.Name = "btn_MainMenu_Start";
            this.btn_MainMenu_Start.Size = new System.Drawing.Size(480, 60);
            this.btn_MainMenu_Start.TabIndex = 0;
            this.btn_MainMenu_Start.Text = "开始游戏";
            this.btn_MainMenu_Start.UseVisualStyleBackColor = false;
            this.btn_MainMenu_Start.UseWaitCursor = true;
            this.btn_MainMenu_Start.Click += new System.EventHandler(this.btn_MainMenu_Start_Click);
            // 
            // lbl_MainMenu_MagicTower
            // 
            this.lbl_MainMenu_MagicTower.AutoSize = true;
            this.lbl_MainMenu_MagicTower.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MainMenu_MagicTower.Font = new System.Drawing.Font("幼圆", 80F);
            this.lbl_MainMenu_MagicTower.ForeColor = System.Drawing.Color.White;
            this.lbl_MainMenu_MagicTower.Location = new System.Drawing.Point(300, 80);
            this.lbl_MainMenu_MagicTower.Name = "lbl_MainMenu_MagicTower";
            this.lbl_MainMenu_MagicTower.Size = new System.Drawing.Size(315, 107);
            this.lbl_MainMenu_MagicTower.TabIndex = 3;
            this.lbl_MainMenu_MagicTower.Text = "魔 塔";
            this.lbl_MainMenu_MagicTower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_MainMenu_MagicTower.UseWaitCursor = true;
            // 
            // MMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this.Picturebox_MainMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MMainForm";
            this.Text = "MyMagicTower";
            this.Load += new System.EventHandler(this.MMainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MMainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MMainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MMainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MMainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_MainMenu)).EndInit();
            this.Picturebox_MainMenu.ResumeLayout(false);
            this.Picturebox_MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_MainMenu_Start;
        private System.Windows.Forms.Button btn_MainMenu_Load;
        private System.Windows.Forms.Button btn_MainMenu_Exit;
        private System.Windows.Forms.Label lbl_MainMenu_MagicTower;
        private System.Windows.Forms.PictureBox Picturebox_MainMenu;
    }
}

