namespace CashRegisterApplication.window
{
    partial class ReceiveMoneyByCashWindow
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
            this.textBox_SupportFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ReceiveFee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_ChangeFee
            // 
            this.textBox_ChangeFee.Location = new System.Drawing.Point(313, 152);
            this.textBox_ChangeFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ChangeFee.Name = "textBox_ChangeFee";
            this.textBox_ChangeFee.ReadOnly = true;
            this.textBox_ChangeFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ChangeFee.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "找零：";
            // 
            // textBox_SupportFee
            // 
            this.textBox_SupportFee.Location = new System.Drawing.Point(313, 123);
            this.textBox_SupportFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_SupportFee.Name = "textBox_SupportFee";
            this.textBox_SupportFee.ReadOnly = true;
            this.textBox_SupportFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_SupportFee.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "应收：";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConfirm.ImageKey = "(无)";
            this.buttonConfirm.Location = new System.Drawing.Point(313, 224);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(121, 53);
            this.buttonConfirm.TabIndex = 17;
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "实收：";
            // 
            // textBox_ReceiveFee
            // 
            this.textBox_ReceiveFee.Location = new System.Drawing.Point(313, 90);
            this.textBox_ReceiveFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ReceiveFee.Name = "textBox_ReceiveFee";
            this.textBox_ReceiveFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_ReceiveFee.TabIndex = 9;
            this.textBox_ReceiveFee.TextChanged += new System.EventHandler(this.textBox_ReceiveFee_TextChanged);
            this.textBox_ReceiveFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ReceiveFee_KeyPress);
            // 
            // ReceiveMoneyByCashWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 380);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBox_ChangeFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_SupportFee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ReceiveFee);
            this.Name = "ReceiveMoneyByCashWindow";
            this.Text = "收银-现金";
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
    }
}