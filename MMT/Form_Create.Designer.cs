
namespace MMT
{
    partial class Form_Create
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
            this.lbl_Create = new System.Windows.Forms.Label();
            this.textBox_Create = new System.Windows.Forms.TextBox();
            this.btn_Create_Confirm = new System.Windows.Forms.Button();
            this.btn_Create_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Create
            // 
            this.lbl_Create.AutoSize = true;
            this.lbl_Create.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Create.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbl_Create.ForeColor = System.Drawing.Color.White;
            this.lbl_Create.Location = new System.Drawing.Point(149, 99);
            this.lbl_Create.Name = "lbl_Create";
            this.lbl_Create.Size = new System.Drawing.Size(313, 52);
            this.lbl_Create.TabIndex = 0;
            this.lbl_Create.Text = "请输入玩家名称:";
            // 
            // textBox_Create
            // 
            this.textBox_Create.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox_Create.Location = new System.Drawing.Point(206, 214);
            this.textBox_Create.Name = "textBox_Create";
            this.textBox_Create.Size = new System.Drawing.Size(204, 38);
            this.textBox_Create.TabIndex = 1;
            // 
            // btn_Create_Confirm
            // 
            this.btn_Create_Confirm.BackgroundImage = global::MMT.Properties.Resources.Img_button;
            this.btn_Create_Confirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Create_Confirm.FlatAppearance.BorderSize = 0;
            this.btn_Create_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create_Confirm.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_Create_Confirm.Location = new System.Drawing.Point(158, 310);
            this.btn_Create_Confirm.Name = "btn_Create_Confirm";
            this.btn_Create_Confirm.Size = new System.Drawing.Size(101, 38);
            this.btn_Create_Confirm.TabIndex = 2;
            this.btn_Create_Confirm.Text = "确认";
            this.btn_Create_Confirm.UseVisualStyleBackColor = true;
            this.btn_Create_Confirm.Click += new System.EventHandler(this.btn_Create_Confirm_Click);
            // 
            // btn_Create_Cancel
            // 
            this.btn_Create_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create_Cancel.BackgroundImage = global::MMT.Properties.Resources.Img_button;
            this.btn_Create_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Create_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Create_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create_Cancel.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_Create_Cancel.Location = new System.Drawing.Point(361, 310);
            this.btn_Create_Cancel.Name = "btn_Create_Cancel";
            this.btn_Create_Cancel.Size = new System.Drawing.Size(101, 38);
            this.btn_Create_Cancel.TabIndex = 3;
            this.btn_Create_Cancel.Text = "取消";
            this.btn_Create_Cancel.UseVisualStyleBackColor = false;
            this.btn_Create_Cancel.Click += new System.EventHandler(this.btn_Create_Cancel_Click);
            // 
            // Form_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MMT.Properties.Resources.Img_LoadMenu_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btn_Create_Cancel);
            this.Controls.Add(this.btn_Create_Confirm);
            this.Controls.Add(this.textBox_Create);
            this.Controls.Add(this.lbl_Create);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(400, 80);
            this.Name = "Form_Create";
            this.Text = "Form_Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Create;
        private System.Windows.Forms.TextBox textBox_Create;
        private System.Windows.Forms.Button btn_Create_Confirm;
        private System.Windows.Forms.Button btn_Create_Cancel;
    }
}