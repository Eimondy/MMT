
namespace MMT
{
    partial class Form_Lose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Lose));
            this.lbl_Lose = new System.Windows.Forms.Label();
            this.btn_Lose_Again = new System.Windows.Forms.Button();
            this.btn_Lose_Exit = new System.Windows.Forms.Button();
            this.Picturebox_Lose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_Lose)).BeginInit();
            this.Picturebox_Lose.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Lose
            // 
            this.lbl_Lose.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Lose.Font = new System.Drawing.Font("幼圆", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Lose.ForeColor = System.Drawing.Color.White;
            this.lbl_Lose.Location = new System.Drawing.Point(89, 92);
            this.lbl_Lose.Name = "lbl_Lose";
            this.lbl_Lose.Size = new System.Drawing.Size(417, 62);
            this.lbl_Lose.TabIndex = 1;
            this.lbl_Lose.Text = "你被[]击败";
            this.lbl_Lose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Lose_Again
            // 
            this.btn_Lose_Again.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Lose_Again.BackgroundImage")));
            this.btn_Lose_Again.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Lose_Again.FlatAppearance.BorderSize = 0;
            this.btn_Lose_Again.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Lose_Again.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_Lose_Again.ForeColor = System.Drawing.Color.White;
            this.btn_Lose_Again.Location = new System.Drawing.Point(142, 171);
            this.btn_Lose_Again.Name = "btn_Lose_Again";
            this.btn_Lose_Again.Size = new System.Drawing.Size(292, 63);
            this.btn_Lose_Again.TabIndex = 2;
            this.btn_Lose_Again.Text = "再来一次";
            this.btn_Lose_Again.UseVisualStyleBackColor = true;
            this.btn_Lose_Again.Click += new System.EventHandler(this.btn_Lose_Again_Click);
            // 
            // btn_Lose_Exit
            // 
            this.btn_Lose_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Lose_Exit.BackgroundImage")));
            this.btn_Lose_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Lose_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Lose_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Lose_Exit.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_Lose_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Lose_Exit.Location = new System.Drawing.Point(142, 254);
            this.btn_Lose_Exit.Name = "btn_Lose_Exit";
            this.btn_Lose_Exit.Size = new System.Drawing.Size(292, 63);
            this.btn_Lose_Exit.TabIndex = 3;
            this.btn_Lose_Exit.Text = "返回主菜单";
            this.btn_Lose_Exit.UseVisualStyleBackColor = true;
            this.btn_Lose_Exit.Click += new System.EventHandler(this.btn_Lose_Exit_Click);
            // 
            // Picturebox_Lose
            // 
            this.Picturebox_Lose.BackColor = System.Drawing.Color.Transparent;
            this.Picturebox_Lose.BackgroundImage = global::MMT.Properties.Resources.Img_menu;
            this.Picturebox_Lose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Picturebox_Lose.Controls.Add(this.btn_Lose_Exit);
            this.Picturebox_Lose.Controls.Add(this.btn_Lose_Again);
            this.Picturebox_Lose.Controls.Add(this.lbl_Lose);
            this.Picturebox_Lose.Location = new System.Drawing.Point(0, 0);
            this.Picturebox_Lose.Name = "Picturebox_Lose";
            this.Picturebox_Lose.Size = new System.Drawing.Size(600, 351);
            this.Picturebox_Lose.TabIndex = 4;
            this.Picturebox_Lose.TabStop = false;
            // 
            // Form_Lose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 351);
            this.Controls.Add(this.Picturebox_Lose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(384, 80);
            this.Name = "Form_Lose";
            this.Text = "Form_Lose";
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_Lose)).EndInit();
            this.Picturebox_Lose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Lose_Again;
        private System.Windows.Forms.Button btn_Lose_Exit;
        private System.Windows.Forms.Label lbl_Lose;
        public System.Windows.Forms.PictureBox Picturebox_Lose;
    }
}