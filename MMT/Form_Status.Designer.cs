
namespace MMT
{
    partial class Form_Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Status));
            this.lbl_StopGame = new System.Windows.Forms.Label();
            this.btn_StopGame = new System.Windows.Forms.Button();
            this.lbl_FloorShow = new System.Windows.Forms.Label();
            this.lbl_FloorNum = new System.Windows.Forms.Label();
            this.picturebox_BackColor = new System.Windows.Forms.PictureBox();
            this.lbl_HitRateShow = new System.Windows.Forms.Label();
            this.lbl_LevelShow = new System.Windows.Forms.Label();
            this.lbl_SpeedShow = new System.Windows.Forms.Label();
            this.lbl_HpShow = new System.Windows.Forms.Label();
            this.lbl_MagicArmorShow = new System.Windows.Forms.Label();
            this.lbl_ArmorShow = new System.Windows.Forms.Label();
            this.lbl_PowerShow = new System.Windows.Forms.Label();
            this.lbl_MpShow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_BackColor)).BeginInit();
            this.picturebox_BackColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_StopGame
            // 
            this.lbl_StopGame.AutoSize = true;
            this.lbl_StopGame.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_StopGame.Location = new System.Drawing.Point(44, 63);
            this.lbl_StopGame.Name = "lbl_StopGame";
            this.lbl_StopGame.Size = new System.Drawing.Size(123, 35);
            this.lbl_StopGame.TabIndex = 0;
            this.lbl_StopGame.Text = "暂停游戏";
            // 
            // btn_StopGame
            // 
            this.btn_StopGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_StopGame.BackgroundImage")));
            this.btn_StopGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_StopGame.FlatAppearance.BorderSize = 0;
            this.btn_StopGame.Location = new System.Drawing.Point(193, 63);
            this.btn_StopGame.Name = "btn_StopGame";
            this.btn_StopGame.Size = new System.Drawing.Size(41, 41);
            this.btn_StopGame.TabIndex = 1;
            this.btn_StopGame.UseVisualStyleBackColor = true;
            this.btn_StopGame.Click += new System.EventHandler(this.btn_StopGame_Click);
            // 
            // lbl_FloorShow
            // 
            this.lbl_FloorShow.AutoSize = true;
            this.lbl_FloorShow.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_FloorShow.Location = new System.Drawing.Point(44, 130);
            this.lbl_FloorShow.Name = "lbl_FloorShow";
            this.lbl_FloorShow.Size = new System.Drawing.Size(150, 35);
            this.lbl_FloorShow.TabIndex = 2;
            this.lbl_FloorShow.Text = "当前层数：";
            // 
            // lbl_FloorNum
            // 
            this.lbl_FloorNum.AutoSize = true;
            this.lbl_FloorNum.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_FloorNum.Location = new System.Drawing.Point(187, 130);
            this.lbl_FloorNum.Name = "lbl_FloorNum";
            this.lbl_FloorNum.Size = new System.Drawing.Size(31, 35);
            this.lbl_FloorNum.TabIndex = 3;
            this.lbl_FloorNum.Text = "1";
            // 
            // picturebox_BackColor
            // 
            this.picturebox_BackColor.BackColor = System.Drawing.Color.LightSlateGray;
            this.picturebox_BackColor.Controls.Add(this.lbl_HitRateShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_LevelShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_SpeedShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_HpShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_MagicArmorShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_ArmorShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_PowerShow);
            this.picturebox_BackColor.Controls.Add(this.lbl_MpShow);
            this.picturebox_BackColor.Location = new System.Drawing.Point(50, 202);
            this.picturebox_BackColor.Name = "picturebox_BackColor";
            this.picturebox_BackColor.Size = new System.Drawing.Size(265, 369);
            this.picturebox_BackColor.TabIndex = 4;
            this.picturebox_BackColor.TabStop = false;
            // 
            // lbl_HitRateShow
            // 
            this.lbl_HitRateShow.AutoSize = true;
            this.lbl_HitRateShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_HitRateShow.ForeColor = System.Drawing.Color.White;
            this.lbl_HitRateShow.Location = new System.Drawing.Point(40, 260);
            this.lbl_HitRateShow.Name = "lbl_HitRateShow";
            this.lbl_HitRateShow.Size = new System.Drawing.Size(101, 30);
            this.lbl_HitRateShow.TabIndex = 13;
            this.lbl_HitRateShow.Text = "命中率：";
            // 
            // lbl_LevelShow
            // 
            this.lbl_LevelShow.AutoSize = true;
            this.lbl_LevelShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_LevelShow.ForeColor = System.Drawing.Color.White;
            this.lbl_LevelShow.Location = new System.Drawing.Point(40, 20);
            this.lbl_LevelShow.Name = "lbl_LevelShow";
            this.lbl_LevelShow.Size = new System.Drawing.Size(79, 30);
            this.lbl_LevelShow.TabIndex = 12;
            this.lbl_LevelShow.Text = "等级：";
            // 
            // lbl_SpeedShow
            // 
            this.lbl_SpeedShow.AutoSize = true;
            this.lbl_SpeedShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_SpeedShow.ForeColor = System.Drawing.Color.White;
            this.lbl_SpeedShow.Location = new System.Drawing.Point(40, 225);
            this.lbl_SpeedShow.Name = "lbl_SpeedShow";
            this.lbl_SpeedShow.Size = new System.Drawing.Size(79, 30);
            this.lbl_SpeedShow.TabIndex = 10;
            this.lbl_SpeedShow.Text = "速度：";
            // 
            // lbl_HpShow
            // 
            this.lbl_HpShow.AutoSize = true;
            this.lbl_HpShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_HpShow.ForeColor = System.Drawing.Color.White;
            this.lbl_HpShow.Location = new System.Drawing.Point(40, 55);
            this.lbl_HpShow.Name = "lbl_HpShow";
            this.lbl_HpShow.Size = new System.Drawing.Size(101, 30);
            this.lbl_HpShow.TabIndex = 5;
            this.lbl_HpShow.Text = "生命值：";
            // 
            // lbl_MagicArmorShow
            // 
            this.lbl_MagicArmorShow.AutoSize = true;
            this.lbl_MagicArmorShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_MagicArmorShow.ForeColor = System.Drawing.Color.White;
            this.lbl_MagicArmorShow.Location = new System.Drawing.Point(40, 190);
            this.lbl_MagicArmorShow.Name = "lbl_MagicArmorShow";
            this.lbl_MagicArmorShow.Size = new System.Drawing.Size(79, 30);
            this.lbl_MagicArmorShow.TabIndex = 9;
            this.lbl_MagicArmorShow.Text = "魔抗：";
            // 
            // lbl_ArmorShow
            // 
            this.lbl_ArmorShow.AutoSize = true;
            this.lbl_ArmorShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_ArmorShow.ForeColor = System.Drawing.Color.White;
            this.lbl_ArmorShow.Location = new System.Drawing.Point(40, 160);
            this.lbl_ArmorShow.Name = "lbl_ArmorShow";
            this.lbl_ArmorShow.Size = new System.Drawing.Size(79, 30);
            this.lbl_ArmorShow.TabIndex = 8;
            this.lbl_ArmorShow.Text = "护甲：";
            // 
            // lbl_PowerShow
            // 
            this.lbl_PowerShow.AutoSize = true;
            this.lbl_PowerShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_PowerShow.ForeColor = System.Drawing.Color.White;
            this.lbl_PowerShow.Location = new System.Drawing.Point(40, 125);
            this.lbl_PowerShow.Name = "lbl_PowerShow";
            this.lbl_PowerShow.Size = new System.Drawing.Size(101, 30);
            this.lbl_PowerShow.TabIndex = 7;
            this.lbl_PowerShow.Text = "力量值：";
            // 
            // lbl_MpShow
            // 
            this.lbl_MpShow.AutoSize = true;
            this.lbl_MpShow.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_MpShow.ForeColor = System.Drawing.Color.White;
            this.lbl_MpShow.Location = new System.Drawing.Point(40, 90);
            this.lbl_MpShow.Name = "lbl_MpShow";
            this.lbl_MpShow.Size = new System.Drawing.Size(101, 30);
            this.lbl_MpShow.TabIndex = 6;
            this.lbl_MpShow.Text = "法力值：";
            // 
            // Form_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(384, 640);
            this.Controls.Add(this.picturebox_BackColor);
            this.Controls.Add(this.lbl_FloorNum);
            this.Controls.Add(this.lbl_FloorShow);
            this.Controls.Add(this.btn_StopGame);
            this.Controls.Add(this.lbl_StopGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Status";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_BackColor)).EndInit();
            this.picturebox_BackColor.ResumeLayout(false);
            this.picturebox_BackColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StopGame;
        private System.Windows.Forms.Button btn_StopGame;
        private System.Windows.Forms.Label lbl_FloorShow;
        private System.Windows.Forms.Label lbl_FloorNum;
        private System.Windows.Forms.PictureBox picturebox_BackColor;
        private System.Windows.Forms.Label lbl_HpShow;
        private System.Windows.Forms.Label lbl_MpShow;
        private System.Windows.Forms.Label lbl_PowerShow;
        private System.Windows.Forms.Label lbl_ArmorShow;
        private System.Windows.Forms.Label lbl_MagicArmorShow;
        private System.Windows.Forms.Label lbl_SpeedShow;
        private System.Windows.Forms.Label lbl_LevelShow;
        private System.Windows.Forms.Label lbl_HitRateShow;
    }
}