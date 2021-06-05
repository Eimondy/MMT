
namespace MMT
{
    partial class Form_Pause
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
            this.lbl_Pause = new System.Windows.Forms.Label();
            this.btn_Pause_Continue = new System.Windows.Forms.Button();
            this.btn_Pause_Save = new System.Windows.Forms.Button();
            this.btn_Pause_Load = new System.Windows.Forms.Button();
            this.btn_Pause_Mainmenu = new System.Windows.Forms.Button();
            this.btn_Pause_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Pause
            // 
            this.lbl_Pause.AutoSize = true;
            this.lbl_Pause.Font = new System.Drawing.Font("幼圆", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Pause.Location = new System.Drawing.Point(45, 25);
            this.lbl_Pause.Name = "lbl_Pause";
            this.lbl_Pause.Size = new System.Drawing.Size(212, 48);
            this.lbl_Pause.TabIndex = 0;
            this.lbl_Pause.Text = "游戏暂停";
            // 
            // btn_Pause_Continue
            // 
            this.btn_Pause_Continue.Font = new System.Drawing.Font("幼圆", 18F);
            this.btn_Pause_Continue.Location = new System.Drawing.Point(29, 94);
            this.btn_Pause_Continue.Name = "btn_Pause_Continue";
            this.btn_Pause_Continue.Size = new System.Drawing.Size(246, 51);
            this.btn_Pause_Continue.TabIndex = 1;
            this.btn_Pause_Continue.Text = "继续游戏";
            this.btn_Pause_Continue.UseVisualStyleBackColor = true;
            this.btn_Pause_Continue.Click += new System.EventHandler(this.btn_Pause_Continue_Click);
            // 
            // btn_Pause_Save
            // 
            this.btn_Pause_Save.Font = new System.Drawing.Font("幼圆", 18F);
            this.btn_Pause_Save.Location = new System.Drawing.Point(29, 164);
            this.btn_Pause_Save.Name = "btn_Pause_Save";
            this.btn_Pause_Save.Size = new System.Drawing.Size(246, 51);
            this.btn_Pause_Save.TabIndex = 2;
            this.btn_Pause_Save.Text = "保存游戏";
            this.btn_Pause_Save.UseVisualStyleBackColor = true;
            this.btn_Pause_Save.Click += new System.EventHandler(this.btn_Pause_Save_Click);
            // 
            // btn_Pause_Load
            // 
            this.btn_Pause_Load.Font = new System.Drawing.Font("幼圆", 18F);
            this.btn_Pause_Load.Location = new System.Drawing.Point(29, 234);
            this.btn_Pause_Load.Name = "btn_Pause_Load";
            this.btn_Pause_Load.Size = new System.Drawing.Size(246, 51);
            this.btn_Pause_Load.TabIndex = 3;
            this.btn_Pause_Load.Text = "加载游戏";
            this.btn_Pause_Load.UseVisualStyleBackColor = true;
            this.btn_Pause_Load.Click += new System.EventHandler(this.btn_Pause_Load_Click);
            // 
            // btn_Pause_Mainmenu
            // 
            this.btn_Pause_Mainmenu.Font = new System.Drawing.Font("幼圆", 18F);
            this.btn_Pause_Mainmenu.Location = new System.Drawing.Point(29, 304);
            this.btn_Pause_Mainmenu.Name = "btn_Pause_Mainmenu";
            this.btn_Pause_Mainmenu.Size = new System.Drawing.Size(246, 51);
            this.btn_Pause_Mainmenu.TabIndex = 4;
            this.btn_Pause_Mainmenu.Text = "返回主菜单";
            this.btn_Pause_Mainmenu.UseVisualStyleBackColor = true;
            this.btn_Pause_Mainmenu.Click += new System.EventHandler(this.btn_Pause_Mainmenu_Click);
            // 
            // btn_Pause_Exit
            // 
            this.btn_Pause_Exit.Font = new System.Drawing.Font("幼圆", 18F);
            this.btn_Pause_Exit.Location = new System.Drawing.Point(29, 374);
            this.btn_Pause_Exit.Name = "btn_Pause_Exit";
            this.btn_Pause_Exit.Size = new System.Drawing.Size(246, 51);
            this.btn_Pause_Exit.TabIndex = 5;
            this.btn_Pause_Exit.Text = "退出游戏";
            this.btn_Pause_Exit.UseVisualStyleBackColor = true;
            this.btn_Pause_Exit.Click += new System.EventHandler(this.btn_Pause_Exit_Click);
            // 
            // Form_Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.btn_Pause_Exit);
            this.Controls.Add(this.btn_Pause_Mainmenu);
            this.Controls.Add(this.btn_Pause_Load);
            this.Controls.Add(this.btn_Pause_Save);
            this.Controls.Add(this.btn_Pause_Continue);
            this.Controls.Add(this.lbl_Pause);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(534, 50);
            this.Name = "Form_Pause";
            this.Text = "Form_Pause";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Pause;
        private System.Windows.Forms.Button btn_Pause_Continue;
        private System.Windows.Forms.Button btn_Pause_Save;
        private System.Windows.Forms.Button btn_Pause_Load;
        private System.Windows.Forms.Button btn_Pause_Mainmenu;
        private System.Windows.Forms.Button btn_Pause_Exit;
    }
}