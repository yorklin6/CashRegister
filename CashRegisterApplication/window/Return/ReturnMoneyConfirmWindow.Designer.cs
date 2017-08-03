namespace CashRegisterApplication.window
{
    partial class ReturnMoneyConfirmWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnMoneyConfirmWindow));
            this.textBox_ChangeFee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_SupportFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.textBox_payType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_ChangeFee
            // 
            this.textBox_ChangeFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ChangeFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_ChangeFee.Location = new System.Drawing.Point(186, 204);
            this.textBox_ChangeFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_ChangeFee.Name = "textBox_ChangeFee";
            this.textBox_ChangeFee.ReadOnly = true;
            this.textBox_ChangeFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_ChangeFee.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "找零：";
            // 
            // textBox_SupportFee
            // 
            this.textBox_SupportFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_SupportFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_SupportFee.Location = new System.Drawing.Point(186, 119);
            this.textBox_SupportFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_SupportFee.Name = "textBox_SupportFee";
            this.textBox_SupportFee.ReadOnly = true;
            this.textBox_SupportFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_SupportFee.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "应收：";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConfirm.ImageKey = "(无)";
            this.buttonConfirm.Location = new System.Drawing.Point(196, 262);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(125, 50);
            this.buttonConfirm.TabIndex = 17;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "实收：";
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_ReceiveFee.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(186, 160);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(146, 23);
            this.textBox_ReceiveFee.TabIndex = 9;
            this.textBox_ReceiveFee.TextChanged += new System.EventHandler(this.textBox_ReceiveFee_TextChanged);
            this.textBox_ReceiveFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ReceiveFee_KeyPress);
            // 
            // textBox_payType
            // 
            this.textBox_payType.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_payType.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_payType.Location = new System.Drawing.Point(186, 78);
            this.textBox_payType.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.textBox_payType.Name = "textBox_payType";
            this.textBox_payType.ReadOnly = true;
            this.textBox_payType.Size = new System.Drawing.Size(146, 23);
            this.textBox_payType.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "付款方式：";
            // 
            // ReturnMoneyConfirmWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_payType);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBox_ChangeFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_SupportFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ReceiveFee);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReturnMoneyConfirmWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收银-";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveMoneyByCashWindow_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveMoneyByCash_Load);
            this.Shown += new System.EventHandler(this.ReceiveMoneyByCash_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ChangeFee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_SupportFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ReceiveFee;
        private System.Windows.Forms.TextBox textBox_payType;
        private System.Windows.Forms.Label label4;
    }
}