namespace CashRegisterApplication.window.member
{
    partial class MemberInfoWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberInfoWindows));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_memberAccount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "卡号：";
            // 
            // textBox_memberAccount
            // 
            this.textBox_memberAccount.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_memberAccount.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberAccount.Location = new System.Drawing.Point(167, 76);
            this.textBox_memberAccount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberAccount.Name = "textBox_memberAccount";
            this.textBox_memberAccount.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberAccount.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowText;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(177, 156);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 36);
            this.button1.TabIndex = 43;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox_Password
            // 
            this.textBox_Password.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Password.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_Password.Location = new System.Drawing.Point(167, 111);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(146, 23);
            this.textBox_Password.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "密码：";
            // 
            // MemberInfoWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(484, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_memberAccount);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberInfoWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员信息";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberInfoWindows_FormClosing);
            this.Load += new System.EventHandler(this.memberRechargeWindows_Load);
            this.Shown += new System.EventHandler(this.memberRechargeWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_memberAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label2;
    }
}