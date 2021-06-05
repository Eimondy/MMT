
namespace MMT
{
    partial class Form_Win
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
            this.lbl_Win = new System.Windows.Forms.Label();
            this.btn_Win = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Win
            // 
            this.lbl_Win.AutoSize = true;
            this.lbl_Win.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Win.Location = new System.Drawing.Point(91, 68);
            this.lbl_Win.Name = "lbl_Win";
            this.lbl_Win.Size = new System.Drawing.Size(411, 62);
            this.lbl_Win.TabIndex = 0;
            this.lbl_Win.Text = "恭喜你击败了魔王";
            // 
            // btn_Win
            // 
            this.btn_Win.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_Win.ForeColor = System.Drawing.Color.White;
            this.btn_Win.Location = new System.Drawing.Point(143, 163);
            this.btn_Win.Name = "btn_Win";
            this.btn_Win.Size = new System.Drawing.Size(292, 63);
            this.btn_Win.TabIndex = 1;
            this.btn_Win.Text = "返回主菜单";
            this.btn_Win.UseVisualStyleBackColor = true;
            this.btn_Win.Click += new System.EventHandler(this.btn_Win_Click);
            // 
            // Form_Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.btn_Win);
            this.Controls.Add(this.lbl_Win);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(384, 80);
            this.Name = "Form_Win";
            this.Text = "Form_Win";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Win;
        private System.Windows.Forms.Button btn_Win;
    }
}