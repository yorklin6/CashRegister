﻿namespace CashRegisterApplication.window
{
    partial class RecieveMoneyWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieveMoneyWindow));
            this.label_OrderFee = new System.Windows.Forms.Label();
            this.textBox_OrderFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonMember = new System.Windows.Forms.Button();
            this.buttonCash = new System.Windows.Forms.Button();
            this.buttonZhifubao = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonWeixin = new System.Windows.Forms.Button();
            this.textBox_RecieveFee = new System.Windows.Forms.TextBox();
            this.label_RecieveFee = new System.Windows.Forms.Label();
            this.label_LeftFee = new System.Windows.Forms.Label();
            this.textBox_LeftFee = new System.Windows.Forms.TextBox();
            this.labelPaidMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_OrderFee
            // 
            this.label_OrderFee.AutoSize = true;
            this.label_OrderFee.Location = new System.Drawing.Point(364, 159);
            this.label_OrderFee.Name = "label_OrderFee";
            this.label_OrderFee.Size = new System.Drawing.Size(41, 12);
            this.label_OrderFee.TabIndex = 7;
            this.label_OrderFee.Text = "总价：";
            // 
            // textBox_OrderFee
            // 
            this.textBox_OrderFee.Location = new System.Drawing.Point(411, 150);
            this.textBox_OrderFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_OrderFee.Name = "textBox_OrderFee";
            this.textBox_OrderFee.ReadOnly = true;
            this.textBox_OrderFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_OrderFee.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(828, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 60);
            this.label4.TabIndex = 12;
            this.label4.Text = "提示:\r\n1键：现金支付\r\n2键：微信支付\r\n3键：支付宝支付\r\n4键：会员支付\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(514, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "3";
            // 
            // buttonMember
            // 
            this.buttonMember.BackgroundImage = global::CashRegisterApplication.Properties.Resources.credit_card_180_93559322034px_1207324_easyicon_net;
            this.buttonMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMember.ImageKey = "(无)";
            this.buttonMember.Location = new System.Drawing.Point(592, 294);
            this.buttonMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMember.Name = "buttonMember";
            this.buttonMember.Size = new System.Drawing.Size(88, 88);
            this.buttonMember.TabIndex = 18;
            this.buttonMember.UseVisualStyleBackColor = true;
            // 
            // buttonCash
            // 
            this.buttonCash.BackgroundImage = global::CashRegisterApplication.Properties.Resources.xianjian;
            this.buttonCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCash.ImageKey = "(无)";
            this.buttonCash.Location = new System.Drawing.Point(256, 294);
            this.buttonCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCash.Name = "buttonCash";
            this.buttonCash.Size = new System.Drawing.Size(79, 88);
            this.buttonCash.TabIndex = 16;
            this.buttonCash.UseVisualStyleBackColor = true;
            this.buttonCash.Click += new System.EventHandler(this.buttonCash_Click);
            // 
            // buttonZhifubao
            // 
            this.buttonZhifubao.BackgroundImage = global::CashRegisterApplication.Properties.Resources.alipay;
            this.buttonZhifubao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZhifubao.ImageKey = "(无)";
            this.buttonZhifubao.Location = new System.Drawing.Point(483, 294);
            this.buttonZhifubao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonZhifubao.Name = "buttonZhifubao";
            this.buttonZhifubao.Size = new System.Drawing.Size(79, 88);
            this.buttonZhifubao.TabIndex = 13;
            this.buttonZhifubao.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(627, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "4";
            // 
            // buttonWeixin
            // 
            this.buttonWeixin.BackgroundImage = global::CashRegisterApplication.Properties.Resources.wechatPay;
            this.buttonWeixin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWeixin.ImageKey = "(无)";
            this.buttonWeixin.Location = new System.Drawing.Point(373, 294);
            this.buttonWeixin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonWeixin.Name = "buttonWeixin";
            this.buttonWeixin.Size = new System.Drawing.Size(79, 88);
            this.buttonWeixin.TabIndex = 20;
            this.buttonWeixin.UseVisualStyleBackColor = true;
            this.buttonWeixin.Click += new System.EventHandler(this.buttonWeixin_Click);
            // 
            // textBox_RecieveFee
            // 
            this.textBox_RecieveFee.Location = new System.Drawing.Point(411, 193);
            this.textBox_RecieveFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RecieveFee.Name = "textBox_RecieveFee";
            this.textBox_RecieveFee.ReadOnly = true;
            this.textBox_RecieveFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_RecieveFee.TabIndex = 21;
            // 
            // label_RecieveFee
            // 
            this.label_RecieveFee.AutoSize = true;
            this.label_RecieveFee.Location = new System.Drawing.Point(346, 196);
            this.label_RecieveFee.Name = "label_RecieveFee";
            this.label_RecieveFee.Size = new System.Drawing.Size(59, 12);
            this.label_RecieveFee.TabIndex = 22;
            this.label_RecieveFee.Text = " 已收款：";
            // 
            // label_LeftFee
            // 
            this.label_LeftFee.AutoSize = true;
            this.label_LeftFee.Location = new System.Drawing.Point(346, 115);
            this.label_LeftFee.Name = "label_LeftFee";
            this.label_LeftFee.Size = new System.Drawing.Size(59, 12);
            this.label_LeftFee.TabIndex = 23;
            this.label_LeftFee.Text = " 未收款：";
            // 
            // textBox_LeftFee
            // 
            this.textBox_LeftFee.Location = new System.Drawing.Point(411, 112);
            this.textBox_LeftFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_LeftFee.Name = "textBox_LeftFee";
            this.textBox_LeftFee.ReadOnly = true;
            this.textBox_LeftFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_LeftFee.TabIndex = 24;
            // 
            // labelPaidMsg
            // 
            this.labelPaidMsg.AutoSize = true;
            this.labelPaidMsg.Location = new System.Drawing.Point(627, 129);
            this.labelPaidMsg.Name = "labelPaidMsg";
            this.labelPaidMsg.Size = new System.Drawing.Size(0, 12);
            this.labelPaidMsg.TabIndex = 25;
            // 
            // RecieveMoneyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 634);
            this.Controls.Add(this.labelPaidMsg);
            this.Controls.Add(this.textBox_LeftFee);
            this.Controls.Add(this.label_LeftFee);
            this.Controls.Add(this.label_RecieveFee);
            this.Controls.Add(this.textBox_RecieveFee);
            this.Controls.Add(this.buttonWeixin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonMember);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCash);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonZhifubao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_OrderFee);
            this.Controls.Add(this.label_OrderFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecieveMoneyWindow";
            this.Text = "收款";
            this.Load += new System.EventHandler(this.RecieveMoneyWindows_Load);
            this.Shown += new System.EventHandler(this.RecieveMoneyWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_OrderFee;
        private System.Windows.Forms.TextBox textBox_OrderFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonZhifubao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonMember;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonWeixin;
        private System.Windows.Forms.TextBox textBox_RecieveFee;
        private System.Windows.Forms.Label label_RecieveFee;
        private System.Windows.Forms.Label label_LeftFee;
        private System.Windows.Forms.TextBox textBox_LeftFee;
        private System.Windows.Forms.Label labelPaidMsg;
    }
}