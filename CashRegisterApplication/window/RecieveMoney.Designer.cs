namespace CashRegisterApplication.window
{
    partial class RecieveMoneyWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieveMoneyWindows));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ChangeFee = new System.Windows.Forms.TextBox();
            this.textBox_OrderFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "总价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "实收：";
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(422, 162);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.ReadOnly = true;
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ReceiveFee.TabIndex = 5;
            this.textBox_ReceiveFee.Leave += new System.EventHandler(this.textBox_ReceiveFee_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "找零：";
            // 
            // textBox_ChangeFee
            // 
            this.textBox_ChangeFee.Location = new System.Drawing.Point(422, 224);
            this.textBox_ChangeFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ChangeFee.Name = "textBox_ChangeFee";
            this.textBox_ChangeFee.ReadOnly = true;
            this.textBox_ChangeFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ChangeFee.TabIndex = 8;
            // 
            // textBox_OrderFee
            // 
            this.textBox_OrderFee.Location = new System.Drawing.Point(422, 195);
            this.textBox_OrderFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_OrderFee.Name = "textBox_OrderFee";
            this.textBox_OrderFee.ReadOnly = true;
            this.textBox_OrderFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_OrderFee.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(851, 545);
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
            // button4
            // 
            this.button4.BackgroundImage = global::CashRegisterApplication.Properties.Resources.credit_card_180_93559322034px_1207324_easyicon_net;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.ImageKey = "(无)";
            this.button4.Location = new System.Drawing.Point(592, 294);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 88);
            this.button4.TabIndex = 18;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::CashRegisterApplication.Properties.Resources.xianjian;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.ImageKey = "(无)";
            this.button3.Location = new System.Drawing.Point(256, 294);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 88);
            this.button3.TabIndex = 16;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::CashRegisterApplication.Properties.Resources.alipay;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.ImageKey = "(无)";
            this.button2.Location = new System.Drawing.Point(483, 294);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 88);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.BackgroundImage = global::CashRegisterApplication.Properties.Resources.wechatPay;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageKey = "(无)";
            this.button1.Location = new System.Drawing.Point(373, 294);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 88);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RecieveMoneyWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_ChangeFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_OrderFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ReceiveFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecieveMoneyWindows";
            this.Text = "收款";
            this.Load += new System.EventHandler(this.RecieveMoneyWindows_Load);
            this.Shown += new System.EventHandler(this.RecieveMoneyWindows_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ReceiveFee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ChangeFee;
        private System.Windows.Forms.TextBox textBox_OrderFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}