namespace CashRegisterApplication.window.member
{
    partial class ReceiveMoneyByMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveMoneyByMember));
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_memberAccount = new System.Windows.Forms.TextBox();
            this.textBox_memberBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.textBox_SupportFee = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ChangeFee = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_payType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_phone
            // 
            this.textBox_phone.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_phone.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_phone.Location = new System.Drawing.Point(118, 145);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.ReadOnly = true;
            this.textBox_phone.Size = new System.Drawing.Size(146, 23);
            this.textBox_phone.TabIndex = 28;
            this.textBox_phone.TextChanged += new System.EventHandler(this.textBox_ChangeFee_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "电话：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_name.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_name.Location = new System.Drawing.Point(118, 104);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(146, 23);
            this.textBox_name.TabIndex = 29;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_OrderFee_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "姓名：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "卡号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_memberAccount
            // 
            this.textBox_memberAccount.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberAccount.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberAccount.Location = new System.Drawing.Point(118, 58);
            this.textBox_memberAccount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberAccount.Name = "textBox_memberAccount";
            this.textBox_memberAccount.ReadOnly = true;
            this.textBox_memberAccount.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberAccount.TabIndex = 23;
            this.textBox_memberAccount.TextChanged += new System.EventHandler(this.textBox_ReceiveFee_TextChanged);
            // 
            // textBox_memberBalance
            // 
            this.textBox_memberBalance.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberBalance.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberBalance.Location = new System.Drawing.Point(118, 187);
            this.textBox_memberBalance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberBalance.Name = "textBox_memberBalance";
            this.textBox_memberBalance.ReadOnly = true;
            this.textBox_memberBalance.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberBalance.TabIndex = 34;
            this.textBox_memberBalance.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "会员卡余额(元)：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "会员支付(元)：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ReceiveFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(118, 269);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_ReceiveFee.TabIndex = 36;
            this.textBox_ReceiveFee.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox_ReceiveFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ReceiveFee_KeyPress);
            // 
            // textBox_SupportFee
            // 
            this.textBox_SupportFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_SupportFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_SupportFee.Location = new System.Drawing.Point(118, 226);
            this.textBox_SupportFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_SupportFee.Name = "textBox_SupportFee";
            this.textBox_SupportFee.ReadOnly = true;
            this.textBox_SupportFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_SupportFee.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "应收：";
            // 
            // textBox_ChangeFee
            // 
            this.textBox_ChangeFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ChangeFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_ChangeFee.Location = new System.Drawing.Point(118, 308);
            this.textBox_ChangeFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_ChangeFee.Name = "textBox_ChangeFee";
            this.textBox_ChangeFee.ReadOnly = true;
            this.textBox_ChangeFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_ChangeFee.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "找零：";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConfirm.ImageKey = "(无)";
            this.buttonConfirm.Location = new System.Drawing.Point(136, 352);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(108, 37);
            this.buttonConfirm.TabIndex = 40;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(253, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 60);
            this.label5.TabIndex = 47;
            this.label5.Text = "快捷键:\r\nF1:重新输入会员信息\r\nESC:返回上一个界面";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "付款方式：";
            // 
            // textBox_payType
            // 
            this.textBox_payType.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_payType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_payType.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_payType.Location = new System.Drawing.Point(118, 17);
            this.textBox_payType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_payType.Name = "textBox_payType";
            this.textBox_payType.ReadOnly = true;
            this.textBox_payType.Size = new System.Drawing.Size(146, 23);
            this.textBox_payType.TabIndex = 48;
            // 
            // ReceiveMoneyByMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(390, 462);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_payType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_ChangeFee);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBox_SupportFee);
            this.Controls.Add(this.label8);
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
            this.Name = "ReceiveMoneyByMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收银-储值卡支付";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveMoneyByMember_FormClosing);
            this.Load += new System.EventHandler(this.MemberBuy_Load);
            this.Shown += new System.EventHandler(this.ReceiveMoneyByMember_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_memberAccount;
        private System.Windows.Forms.TextBox textBox_memberBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ReceiveFee;
        private System.Windows.Forms.TextBox textBox_SupportFee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TextBox textBox_ChangeFee;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_payType;
    }
}