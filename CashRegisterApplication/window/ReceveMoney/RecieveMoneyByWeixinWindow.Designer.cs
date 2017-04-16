namespace CashRegisterApplication.window
{
    partial class RecieveMoneyByWeixinWindow
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
            this.textBox_ChangeFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_OrderFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_ChangeFee
            // 
            this.textBox_ChangeFee.Location = new System.Drawing.Point(268, 152);
            this.textBox_ChangeFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ChangeFee.Name = "textBox_ChangeFee";
            this.textBox_ChangeFee.ReadOnly = true;
            this.textBox_ChangeFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ChangeFee.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "找零：";
            // 
            // textBox_OrderFee
            // 
            this.textBox_OrderFee.Location = new System.Drawing.Point(268, 123);
            this.textBox_OrderFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_OrderFee.Name = "textBox_OrderFee";
            this.textBox_OrderFee.ReadOnly = true;
            this.textBox_OrderFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_OrderFee.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "总价：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "实收：";
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(268, 90);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ReceiveFee.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::CashRegisterApplication.Properties.Resources.wechatPay;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ImageKey = "(无)";
            this.button1.Location = new System.Drawing.Point(268, 221);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 111);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 181);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 21);
            this.textBox1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "客户条码：";
            // 
            // RecieveMoneyByWeixinWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 385);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_ChangeFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_OrderFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ReceiveFee);
            this.Name = "RecieveMoneyByWeixinWindow";
            this.Text = "收银-微信扫顾客手机码";
            this.Load += new System.EventHandler(this.RecieveMoneyByWeixinWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ChangeFee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_OrderFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ReceiveFee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}