
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
            this.lbl_Lose = new System.Windows.Forms.Label();
            this.btn_Lose_Again = new System.Windows.Forms.Button();
            this.btn_Lose_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Lose
            // 
            this.lbl_Lose.AutoSize = true;
            this.lbl_Lose.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Lose.Location = new System.Drawing.Point(161, 28);
            this.lbl_Lose.Name = "lbl_Lose";
            this.lbl_Lose.Size = new System.Drawing.Size(251, 62);
            this.lbl_Lose.TabIndex = 1;
            this.lbl_Lose.Text = "你被[]击败";
            // 
            // btn_Lose_Again
            // 
            this.btn_Lose_Again.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_Lose_Again.ForeColor = System.Drawing.Color.White;
            this.btn_Lose_Again.Location = new System.Drawing.Point(136, 115);
            this.btn_Lose_Again.Name = "btn_Lose_Again";
            this.btn_Lose_Again.Size = new System.Drawing.Size(292, 63);
            this.btn_Lose_Again.TabIndex = 2;
            this.btn_Lose_Again.Text = "再来一次";
            this.btn_Lose_Again.UseVisualStyleBackColor = true;
            // 
            // btn_Lose_Exit
            // 
            this.btn_Lose_Exit.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_Lose_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Lose_Exit.Location = new System.Drawing.Point(136, 198);
            this.btn_Lose_Exit.Name = "btn_Lose_Exit";
            this.btn_Lose_Exit.Size = new System.Drawing.Size(292, 63);
            this.btn_Lose_Exit.TabIndex = 3;
            this.btn_Lose_Exit.Text = "返回主菜单";
            this.btn_Lose_Exit.UseVisualStyleBackColor = true;
            // 
            // Form_Lose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.btn_Lose_Exit);
            this.Controls.Add(this.btn_Lose_Again);
            this.Controls.Add(this.lbl_Lose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(384, 80);
            this.Name = "Form_Lose";
            this.Text = "Form_Lose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Lose;
        private System.Windows.Forms.Button btn_Lose_Again;
        private System.Windows.Forms.Button btn_Lose_Exit;
    }
}