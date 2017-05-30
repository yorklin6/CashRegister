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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecieveMoneyWindow));
            this.label_OrderFee = new System.Windows.Forms.Label();
            this.label_RecieveFee = new System.Windows.Forms.Label();
            this.label_LeftFee1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lable_LeftFee = new System.Windows.Forms.Label();
            this.lable_OrderFee = new System.Windows.Forms.Label();
            this.lable_RecieveFee = new System.Windows.Forms.Label();
            this.dataGridView_payTypeList = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_payType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label_OrderFee
            // 
            this.label_OrderFee.AutoSize = true;
            this.label_OrderFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderFee.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.label_OrderFee.Location = new System.Drawing.Point(4, 128);
            this.label_OrderFee.Name = "label_OrderFee";
            this.label_OrderFee.Size = new System.Drawing.Size(162, 199);
            this.label_OrderFee.TabIndex = 7;
            this.label_OrderFee.Text = "总计应收";
            this.label_OrderFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_RecieveFee
            // 
            this.label_RecieveFee.AutoSize = true;
            this.label_RecieveFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_RecieveFee.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.label_RecieveFee.Location = new System.Drawing.Point(4, 328);
            this.label_RecieveFee.Name = "label_RecieveFee";
            this.label_RecieveFee.Size = new System.Drawing.Size(162, 325);
            this.label_RecieveFee.TabIndex = 22;
            this.label_RecieveFee.Text = "实际已收";
            this.label_RecieveFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_LeftFee1
            // 
            this.label_LeftFee1.AutoSize = true;
            this.label_LeftFee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LeftFee1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_LeftFee1.Location = new System.Drawing.Point(4, 1);
            this.label_LeftFee1.Name = "label_LeftFee1";
            this.label_LeftFee1.Size = new System.Drawing.Size(162, 126);
            this.label_LeftFee1.TabIndex = 23;
            this.label_LeftFee1.Text = " 还需收款";
            this.label_LeftFee1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_LeftFee1.Click += new System.EventHandler(this.label_LeftFee_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_payTypeList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.80442F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(681, 654);
            this.tableLayoutPanel1.TabIndex = 27;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel2.Controls.Add(this.label_LeftFee1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_RecieveFee, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label_OrderFee, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lable_LeftFee, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lable_OrderFee, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lable_RecieveFee, 1, 2);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(343, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.69565F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.30435F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(338, 654);
            this.tableLayoutPanel2.TabIndex = 28;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // lable_LeftFee
            // 
            this.lable_LeftFee.AutoSize = true;
            this.lable_LeftFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_LeftFee.Location = new System.Drawing.Point(173, 1);
            this.lable_LeftFee.Name = "lable_LeftFee";
            this.lable_LeftFee.Size = new System.Drawing.Size(165, 126);
            this.lable_LeftFee.TabIndex = 25;
            this.lable_LeftFee.Text = " 未收款";
            this.lable_LeftFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lable_OrderFee
            // 
            this.lable_OrderFee.AutoSize = true;
            this.lable_OrderFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_OrderFee.Location = new System.Drawing.Point(173, 128);
            this.lable_OrderFee.Name = "lable_OrderFee";
            this.lable_OrderFee.Size = new System.Drawing.Size(165, 199);
            this.lable_OrderFee.TabIndex = 26;
            this.lable_OrderFee.Text = "总价";
            this.lable_OrderFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lable_OrderFee.Click += new System.EventHandler(this.label1_Click);
            // 
            // lable_RecieveFee
            // 
            this.lable_RecieveFee.AutoSize = true;
            this.lable_RecieveFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_RecieveFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lable_RecieveFee.Location = new System.Drawing.Point(173, 328);
            this.lable_RecieveFee.Name = "lable_RecieveFee";
            this.lable_RecieveFee.Size = new System.Drawing.Size(165, 325);
            this.lable_RecieveFee.TabIndex = 27;
            this.lable_RecieveFee.Text = "已收";
            this.lable_RecieveFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView_payTypeList
            // 
            this.dataGridView_payTypeList.AllowUserToAddRows = false;
            this.dataGridView_payTypeList.AllowUserToDeleteRows = false;
            this.dataGridView_payTypeList.AllowUserToResizeColumns = false;
            this.dataGridView_payTypeList.AllowUserToResizeRows = false;
            this.dataGridView_payTypeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_payTypeList.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_payTypeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_payTypeList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_payTypeList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_payTypeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_payTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_payTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column_payType});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_payTypeList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_payTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_payTypeList.Enabled = false;
            this.dataGridView_payTypeList.EnableHeadersVisualStyles = false;
            this.dataGridView_payTypeList.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView_payTypeList.Location = new System.Drawing.Point(1, 1);
            this.dataGridView_payTypeList.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_payTypeList.MultiSelect = false;
            this.dataGridView_payTypeList.Name = "dataGridView_payTypeList";
            this.dataGridView_payTypeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_payTypeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_payTypeList.RowHeadersVisible = false;
            this.dataGridView_payTypeList.RowTemplate.Height = 23;
            this.dataGridView_payTypeList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_payTypeList.Size = new System.Drawing.Size(339, 652);
            this.dataGridView_payTypeList.TabIndex = 3;
            this.dataGridView_payTypeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_payTypeList_CellContentClick_1);
            // 
            // Column8
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column8.HeaderText = "付款方式";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column9.HeaderText = "付款金额";
            this.Column9.Name = "Column9";
            // 
            // Column_payType
            // 
            this.Column_payType.HeaderText = "实际付款类型ID";
            this.Column_payType.Name = "Column_payType";
            this.Column_payType.Visible = false;
            // 
            // RecieveMoneyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(681, 654);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RecieveMoneyWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收款";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecieveMoneyWindow_FormClosing);
            this.Load += new System.EventHandler(this.RecieveMoneyWindows_Load);
            this.Shown += new System.EventHandler(this.RecieveMoneyWindows_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payTypeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_OrderFee;
        private System.Windows.Forms.Label label_RecieveFee;
        private System.Windows.Forms.Label label_LeftFee1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lable_LeftFee;
        private System.Windows.Forms.Label lable_OrderFee;
        private System.Windows.Forms.Label lable_RecieveFee;
        private System.Windows.Forms.DataGridView dataGridView_payTypeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_payType;
    }
}