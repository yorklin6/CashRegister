namespace CashRegisterApplication.window.Member
{
    partial class RechargeMoneyForMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechargeMoneyForMember));
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_memberAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_memberBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_payType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(433, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 60);
            this.label5.TabIndex = 46;
            this.label5.Text = "快捷键:\r\nF1:重新输入会员信息\r\nF2:重新选择充值方式";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox_memberAccount
            // 
            this.textBox_memberAccount.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberAccount.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberAccount.Location = new System.Drawing.Point(223, 93);
            this.textBox_memberAccount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberAccount.Name = "textBox_memberAccount";
            this.textBox_memberAccount.ReadOnly = true;
            this.textBox_memberAccount.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberAccount.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "卡号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "姓名：";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_name.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_name.Location = new System.Drawing.Point(223, 184);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(146, 23);
            this.textBox_name.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "电话：";
            // 
            // textBox_phone
            // 
            this.textBox_phone.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_phone.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_phone.Location = new System.Drawing.Point(223, 139);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.ReadOnly = true;
            this.textBox_phone.Size = new System.Drawing.Size(146, 23);
            this.textBox_phone.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "会员卡余额(元)：";
            // 
            // textBox_memberBalance
            // 
            this.textBox_memberBalance.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberBalance.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberBalance.Location = new System.Drawing.Point(223, 222);
            this.textBox_memberBalance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberBalance.Name = "textBox_memberBalance";
            this.textBox_memberBalance.ReadOnly = true;
            this.textBox_memberBalance.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberBalance.TabIndex = 42;
            this.textBox_memberBalance.TextChanged += new System.EventHandler(this.textBox_memberBalance_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "充值金额(元)：";
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ReceiveFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(223, 263);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_ReceiveFee.TabIndex = 44;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConfirm.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonConfirm.ImageKey = "(无)";
            this.buttonConfirm.Location = new System.Drawing.Point(246, 307);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 51);
            this.buttonConfirm.TabIndex = 45;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "充值方式：";
            // 
            // textBox_payType
            // 
            this.textBox_payType.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_payType.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_payType.Location = new System.Drawing.Point(223, 55);
            this.textBox_payType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_payType.Name = "textBox_payType";
            this.textBox_payType.ReadOnly = true;
            this.textBox_payType.Size = new System.Drawing.Size(146, 23);
            this.textBox_payType.TabIndex = 49;
            // 
            // RechargeMoneyForMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.textBox_payType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBox_ReceiveFee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_memberBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_memberAccount);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RechargeMoneyForMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "充值";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RechargeMoneyForMember_FormClosing);
            this.Load += new System.EventHandler(this.RechargeMoneyForMember_Load);
            this.Shown += new System.EventHandler(this.RechargeMoneyForMember_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_memberAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_memberBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ReceiveFee;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_payType;
    }
}