namespace CashRegiterApplication
{
    partial class LoginWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindows));
            this.button_loggin = new System.Windows.Forms.Button();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Shop = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_loggin
            // 
            this.button_loggin.ImageKey = "(无)";
            this.button_loggin.Location = new System.Drawing.Point(294, 187);
            this.button_loggin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_loggin.Name = "button_loggin";
            this.button_loggin.Size = new System.Drawing.Size(87, 33);
            this.button_loggin.TabIndex = 0;
            this.button_loggin.Text = "登录";
            this.button_loggin.UseVisualStyleBackColor = false;
            this.button_loggin.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_userName
            // 
            this.textBox_userName.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_userName.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_userName.Location = new System.Drawing.Point(280, 104);
            this.textBox_userName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(126, 23);
            this.textBox_userName.TabIndex = 1;
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_password.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_password.Location = new System.Drawing.Point(280, 137);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(126, 23);
            this.textBox_password.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "门店：";
            // 
            // textBox_Shop
            // 
            this.textBox_Shop.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_Shop.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_Shop.Location = new System.Drawing.Point(279, 70);
            this.textBox_Shop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Shop.Name = "textBox_Shop";
            this.textBox_Shop.ReadOnly = true;
            this.textBox_Shop.Size = new System.Drawing.Size(126, 23);
            this.textBox_Shop.TabIndex = 7;
            this.textBox_Shop.Text = " ";
            // 
            // LoginWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(616, 268);
            this.Controls.Add(this.textBox_Shop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.button_loggin);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginWindows";
            this.Text = "收银机登录";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.LoginWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_loggin;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Shop;
    }
}

