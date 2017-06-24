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
            this.textBox_memberBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_memberAccount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_memberBalance
            // 
            this.textBox_memberBalance.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberBalance.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberBalance.Location = new System.Drawing.Point(201, 205);
            this.textBox_memberBalance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberBalance.Name = "textBox_memberBalance";
            this.textBox_memberBalance.ReadOnly = true;
            this.textBox_memberBalance.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberBalance.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "会员卡余额：";
            // 
            // textBox_phone
            // 
            this.textBox_phone.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_phone.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_phone.Location = new System.Drawing.Point(201, 164);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.ReadOnly = true;
            this.textBox_phone.Size = new System.Drawing.Size(146, 23);
            this.textBox_phone.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "电话：";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_name.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_name.Location = new System.Drawing.Point(201, 123);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(146, 23);
            this.textBox_name.TabIndex = 40;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "卡号：";
            // 
            // textBox_memberAccount
            // 
            this.textBox_memberAccount.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_memberAccount.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_memberAccount.Location = new System.Drawing.Point(201, 76);
            this.textBox_memberAccount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_memberAccount.Name = "textBox_memberAccount";
            this.textBox_memberAccount.Size = new System.Drawing.Size(146, 23);
            this.textBox_memberAccount.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowText;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(211, 263);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 44);
            this.button1.TabIndex = 43;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MemberInfoWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.button1);
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
            this.Name = "MemberInfoWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemberInfoWindows_FormClosing);
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
        private System.Windows.Forms.Button button1;
    }
}