
namespace MMT
{
    partial class Form_Load
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
            this.btn_Load_Confirm = new System.Windows.Forms.Button();
            this.btn_Load_Cancel = new System.Windows.Forms.Button();
            this.Table_Load = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_Load_Confirm
            // 
            this.btn_Load_Confirm.BackColor = System.Drawing.Color.Transparent;
            this.btn_Load_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Load_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Load_Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Load_Confirm.ForeColor = System.Drawing.Color.White;
            this.btn_Load_Confirm.Location = new System.Drawing.Point(270, 347);
            this.btn_Load_Confirm.Name = "btn_Load_Confirm";
            this.btn_Load_Confirm.Size = new System.Drawing.Size(100, 36);
            this.btn_Load_Confirm.TabIndex = 0;
            this.btn_Load_Confirm.Text = "确认";
            this.btn_Load_Confirm.UseVisualStyleBackColor = false;
            this.btn_Load_Confirm.Click += new System.EventHandler(this.btn_Load_Confirm_Click);
            // 
            // btn_Load_Cancel
            // 
            this.btn_Load_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Load_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Load_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Load_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Load_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Load_Cancel.Location = new System.Drawing.Point(430, 347);
            this.btn_Load_Cancel.Name = "btn_Load_Cancel";
            this.btn_Load_Cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_Load_Cancel.TabIndex = 1;
            this.btn_Load_Cancel.Text = "取消";
            this.btn_Load_Cancel.UseVisualStyleBackColor = false;
            this.btn_Load_Cancel.Click += new System.EventHandler(this.btn_Load_Cancel_Click);
            // 
            // Table_Load
            // 
            this.Table_Load.AutoScroll = true;
            this.Table_Load.BackColor = System.Drawing.Color.Transparent;
            this.Table_Load.ColumnCount = 2;
            this.Table_Load.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.31799F));
            this.Table_Load.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.68201F));
            this.Table_Load.Location = new System.Drawing.Point(155, 94);
            this.Table_Load.Name = "Table_Load";
            this.Table_Load.RowCount = 1;
            this.Table_Load.Size = new System.Drawing.Size(511, 222);
            this.Table_Load.TabIndex = 2;
            this.Table_Load.Paint += new System.Windows.Forms.PaintEventHandler(this.Table_Load_Paint);
            // 
            // Form_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MMT.Properties.Resources.Img_LoadMenu_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Table_Load);
            this.Controls.Add(this.btn_Load_Cancel);
            this.Controls.Add(this.btn_Load_Confirm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(284, 80);
            this.Name = "Form_Load";
            this.Text = "Form_Load";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Load_Confirm;
        private System.Windows.Forms.Button btn_Load_Cancel;
        private System.Windows.Forms.TableLayoutPanel Table_Load;
    }
}