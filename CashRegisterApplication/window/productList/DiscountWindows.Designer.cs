namespace CashRegisterApplication.window.productList
{
    partial class DiscountWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountWindows));
            this.textBox_allGoodsMoneyAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_discountAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_discountRate = new System.Windows.Forms.TextBox();
            this.button_loggin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_allGoodsMoneyAmount
            // 
            this.textBox_allGoodsMoneyAmount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_allGoodsMoneyAmount.Location = new System.Drawing.Point(132, 56);
            this.textBox_allGoodsMoneyAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_allGoodsMoneyAmount.Name = "textBox_allGoodsMoneyAmount";
            this.textBox_allGoodsMoneyAmount.ReadOnly = true;
            this.textBox_allGoodsMoneyAmount.Size = new System.Drawing.Size(126, 23);
            this.textBox_allGoodsMoneyAmount.TabIndex = 14;
            this.textBox_allGoodsMoneyAmount.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(82, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "总价：";
            // 
            // textBox_discountAmount
            // 
            this.textBox_discountAmount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_discountAmount.Location = new System.Drawing.Point(132, 120);
            this.textBox_discountAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_discountAmount.Name = "textBox_discountAmount";
            this.textBox_discountAmount.ReadOnly = true;
            this.textBox_discountAmount.Size = new System.Drawing.Size(126, 23);
            this.textBox_discountAmount.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "折扣额：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(70, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "折扣率：";
            // 
            // textBox_discountRate
            // 
            this.textBox_discountRate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_discountRate.Location = new System.Drawing.Point(132, 90);
            this.textBox_discountRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_discountRate.Name = "textBox_discountRate";
            this.textBox_discountRate.Size = new System.Drawing.Size(56, 23);
            this.textBox_discountRate.TabIndex = 9;
            this.textBox_discountRate.TextChanged += new System.EventHandler(this.textBox_discountRate_TextChanged);
            // 
            // button_loggin
            // 
            this.button_loggin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_loggin.ImageKey = "(无)";
            this.button_loggin.Location = new System.Drawing.Point(133, 168);
            this.button_loggin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_loggin.Name = "button_loggin";
            this.button_loggin.Size = new System.Drawing.Size(87, 33);
            this.button_loggin.TabIndex = 8;
            this.button_loggin.Text = "确认";
            this.button_loggin.UseVisualStyleBackColor = true;
            this.button_loggin.Click += new System.EventHandler(this.button_loggin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(194, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "%";
            // 
            // DiscountWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 236);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_allGoodsMoneyAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_discountAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_discountRate);
            this.Controls.Add(this.button_loggin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiscountWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "折扣";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiscountWindows_FormClosing);
            this.Load += new System.EventHandler(this.DiscountWindows_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_allGoodsMoneyAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_discountAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_discountRate;
        private System.Windows.Forms.Button button_loggin;
        private System.Windows.Forms.Label label4;
    }
}