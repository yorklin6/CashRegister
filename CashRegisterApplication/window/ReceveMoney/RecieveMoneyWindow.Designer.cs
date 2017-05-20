namespace CashRegisterApplication.window
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
            this.textBox_RecieveFee = new System.Windows.Forms.TextBox();
            this.label_RecieveFee = new System.Windows.Forms.Label();
            this.label_LeftFee = new System.Windows.Forms.Label();
            this.textBox_LeftFee = new System.Windows.Forms.TextBox();
            this.labelPaidMsg = new System.Windows.Forms.Label();
            this.dataGridView_payTypeList = new System.Windows.Forms.DataGridView();
            this.payTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quickKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label_OrderFee
            // 
            this.label_OrderFee.AutoSize = true;
            this.label_OrderFee.Location = new System.Drawing.Point(139, 147);
            this.label_OrderFee.Name = "label_OrderFee";
            this.label_OrderFee.Size = new System.Drawing.Size(41, 12);
            this.label_OrderFee.TabIndex = 7;
            this.label_OrderFee.Text = "总价：";
            // 
            // textBox_OrderFee
            // 
            this.textBox_OrderFee.CausesValidation = false;
            this.textBox_OrderFee.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_OrderFee.Enabled = false;
            this.textBox_OrderFee.HideSelection = false;
            this.textBox_OrderFee.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_OrderFee.Location = new System.Drawing.Point(186, 138);
            this.textBox_OrderFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_OrderFee.Name = "textBox_OrderFee";
            this.textBox_OrderFee.ReadOnly = true;
            this.textBox_OrderFee.ShortcutsEnabled = false;
            this.textBox_OrderFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_OrderFee.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 60);
            this.label4.TabIndex = 12;
            this.label4.Text = "提示:\r\n1键：现金支付\r\n2键：微信支付\r\n3键：支付宝支付\r\n4键：会员支付\r\n";
            // 
            // textBox_RecieveFee
            // 
            this.textBox_RecieveFee.Enabled = false;
            this.textBox_RecieveFee.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_RecieveFee.Location = new System.Drawing.Point(186, 181);
            this.textBox_RecieveFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RecieveFee.Name = "textBox_RecieveFee";
            this.textBox_RecieveFee.ReadOnly = true;
            this.textBox_RecieveFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_RecieveFee.TabIndex = 21;
            // 
            // label_RecieveFee
            // 
            this.label_RecieveFee.AutoSize = true;
            this.label_RecieveFee.Location = new System.Drawing.Point(121, 184);
            this.label_RecieveFee.Name = "label_RecieveFee";
            this.label_RecieveFee.Size = new System.Drawing.Size(59, 12);
            this.label_RecieveFee.TabIndex = 22;
            this.label_RecieveFee.Text = " 已收款：";
            // 
            // label_LeftFee
            // 
            this.label_LeftFee.AutoSize = true;
            this.label_LeftFee.Location = new System.Drawing.Point(121, 103);
            this.label_LeftFee.Name = "label_LeftFee";
            this.label_LeftFee.Size = new System.Drawing.Size(59, 12);
            this.label_LeftFee.TabIndex = 23;
            this.label_LeftFee.Text = " 未收款：";
            // 
            // textBox_LeftFee
            // 
            this.textBox_LeftFee.Enabled = false;
            this.textBox_LeftFee.HideSelection = false;
            this.textBox_LeftFee.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_LeftFee.Location = new System.Drawing.Point(186, 100);
            this.textBox_LeftFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_LeftFee.Name = "textBox_LeftFee";
            this.textBox_LeftFee.ReadOnly = true;
            this.textBox_LeftFee.Size = new System.Drawing.Size(126, 21);
            this.textBox_LeftFee.TabIndex = 24;
            // 
            // labelPaidMsg
            // 
            this.labelPaidMsg.AutoSize = true;
            this.labelPaidMsg.Location = new System.Drawing.Point(402, 117);
            this.labelPaidMsg.Name = "labelPaidMsg";
            this.labelPaidMsg.Size = new System.Drawing.Size(0, 12);
            this.labelPaidMsg.TabIndex = 25;
            // 
            // dataGridView_payTypeList
            // 
            this.dataGridView_payTypeList.AllowUserToAddRows = false;
            this.dataGridView_payTypeList.AllowUserToDeleteRows = false;
            this.dataGridView_payTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_payTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.payTypeDescription,
            this.quickKey,
            this.payType});
            this.dataGridView_payTypeList.Location = new System.Drawing.Point(422, 21);
            this.dataGridView_payTypeList.Name = "dataGridView_payTypeList";
            this.dataGridView_payTypeList.ReadOnly = true;
            this.dataGridView_payTypeList.RowHeadersVisible = false;
            this.dataGridView_payTypeList.RowTemplate.Height = 23;
            this.dataGridView_payTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_payTypeList.Size = new System.Drawing.Size(209, 436);
            this.dataGridView_payTypeList.TabIndex = 26;
            this.dataGridView_payTypeList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_payTypeList_CellMouseDoubleClick);
            this.dataGridView_payTypeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_payTypeList_MouseDoubleClick);
            // 
            // payTypeDescription
            // 
            this.payTypeDescription.HeaderText = "类型";
            this.payTypeDescription.Name = "payTypeDescription";
            this.payTypeDescription.ReadOnly = true;
            // 
            // quickKey
            // 
            this.quickKey.HeaderText = "快捷键";
            this.quickKey.Name = "quickKey";
            this.quickKey.ReadOnly = true;
            // 
            // payType
            // 
            this.payType.HeaderText = "支付类型";
            this.payType.Name = "payType";
            this.payType.ReadOnly = true;
            this.payType.Visible = false;
            // 
            // RecieveMoneyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 634);
            this.Controls.Add(this.dataGridView_payTypeList);
            this.Controls.Add(this.labelPaidMsg);
            this.Controls.Add(this.textBox_LeftFee);
            this.Controls.Add(this.label_LeftFee);
            this.Controls.Add(this.label_RecieveFee);
            this.Controls.Add(this.textBox_RecieveFee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_OrderFee);
            this.Controls.Add(this.label_OrderFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecieveMoneyWindow";
            this.Text = "收款";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecieveMoneyWindow_FormClosing);
            this.Load += new System.EventHandler(this.RecieveMoneyWindows_Load);
            this.Shown += new System.EventHandler(this.RecieveMoneyWindows_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payTypeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_OrderFee;
        private System.Windows.Forms.TextBox textBox_OrderFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_RecieveFee;
        private System.Windows.Forms.Label label_RecieveFee;
        private System.Windows.Forms.Label label_LeftFee;
        private System.Windows.Forms.TextBox textBox_LeftFee;
        private System.Windows.Forms.Label labelPaidMsg;
        private System.Windows.Forms.DataGridView dataGridView_payTypeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn payTypeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn quickKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn payType;
    }
}