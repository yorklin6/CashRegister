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
            this.textBox_memberBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_memberAccount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_memberBalance
            // 
            this.textBox_memberBalance.Location = new System.Drawing.Point(246, 145);
            this.textBox_memberBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_memberBalance.Name = "textBox_memberBalance";
            this.textBox_memberBalance.ReadOnly = true;
            this.textBox_memberBalance.Size = new System.Drawing.Size(126, 21);
            this.textBox_memberBalance.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "会员卡余额(元)：";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(246, 116);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.ReadOnly = true;
            this.textBox_phone.Size = new System.Drawing.Size(126, 21);
            this.textBox_phone.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "电话：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(246, 87);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(126, 21);
            this.textBox_name.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "卡号：";
            // 
            // textBox_memberAccount
            // 
            this.textBox_memberAccount.Location = new System.Drawing.Point(246, 54);
            this.textBox_memberAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_memberAccount.Name = "textBox_memberAccount";
            this.textBox_memberAccount.Size = new System.Drawing.Size(126, 21);
            this.textBox_memberAccount.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 36);
            this.label5.TabIndex = 43;
            this.label5.Text = "操作说明:\r\n1.输入卡号按回车就能查到会员\r\n2.输入ESC取消";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // memberRechargeWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_memberBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_memberAccount);
            this.Name = "memberRechargeWindows";
            this.Text = "会员信息";
            this.Load += new System.EventHandler(this.memberRechargeWindows_Load);
            this.Shown += new System.EventHandler(this.memberRechargeWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_memberBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_memberAccount;
        private System.Windows.Forms.Label label5;
    }
}