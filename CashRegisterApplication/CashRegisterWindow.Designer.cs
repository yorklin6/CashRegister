namespace CashRegiterApplication
{
    partial class CashRegisterWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.payWayDataGridView = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productListDataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNormalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDataGridView = new System.Windows.Forms.DataGridView();
            this.orderMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.payWayDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // payWayDataGridView
            // 
            this.payWayDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.payWayDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.payWayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payWayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.payWayDataGridView.Location = new System.Drawing.Point(23, 330);
            this.payWayDataGridView.Name = "payWayDataGridView";
            this.payWayDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.payWayDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.payWayDataGridView.RowHeadersVisible = false;
            this.payWayDataGridView.RowTemplate.Height = 23;
            this.payWayDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.payWayDataGridView.Size = new System.Drawing.Size(200, 99);
            this.payWayDataGridView.TabIndex = 2;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "付款方式";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "付款金额";
            this.Column9.Name = "Column9";
            // 
            // productListDataGridView
            // 
            this.productListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnProductCode,
            this.ColumnProductName,
            this.ColumnProductSpecification,
            this.ColumnNormalPrice,
            this.ColumnAmount,
            this.ColumnMoney,
            this.ColumnRemark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productListDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.productListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.productListDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.productListDataGridView.Location = new System.Drawing.Point(23, 2);
            this.productListDataGridView.MultiSelect = false;
            this.productListDataGridView.Name = "productListDataGridView";
            this.productListDataGridView.RowHeadersVisible = false;
            this.productListDataGridView.RowTemplate.Height = 23;
            this.productListDataGridView.Size = new System.Drawing.Size(860, 297);
            this.productListDataGridView.TabIndex = 1;
            this.productListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellContentClick);
            this.productListDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellEndEdit);
            this.productListDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellEnter);
            this.productListDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_RowEnter);
            this.productListDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.productListDataGridView_RowsAdded);
            this.productListDataGridView.SelectionChanged += new System.EventHandler(this.productListDataGridView_SelectionChanged);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.HeaderText = "序号";
            this.ColumnIndex.Name = "ColumnIndex";
            // 
            // ColumnProductCode
            // 
            this.ColumnProductCode.HeaderText = "条码";
            this.ColumnProductCode.Name = "ColumnProductCode";
            // 
            // ColumnProductName
            // 
            this.ColumnProductName.HeaderText = "名称";
            this.ColumnProductName.Name = "ColumnProductName";
            // 
            // ColumnProductSpecification
            // 
            this.ColumnProductSpecification.HeaderText = "规格";
            this.ColumnProductSpecification.Name = "ColumnProductSpecification";
            // 
            // ColumnNormalPrice
            // 
            this.ColumnNormalPrice.HeaderText = "单价";
            this.ColumnNormalPrice.Name = "ColumnNormalPrice";
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.HeaderText = "数量";
            this.ColumnAmount.Name = "ColumnAmount";
            // 
            // ColumnMoney
            // 
            this.ColumnMoney.HeaderText = "金额";
            this.ColumnMoney.Name = "ColumnMoney";
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            // 
            // orderDataGridView
            // 
            this.orderDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderMsg,
            this.orderMoney});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.orderDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.orderDataGridView.Location = new System.Drawing.Point(314, 330);
            this.orderDataGridView.MultiSelect = false;
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.RowHeadersVisible = false;
            this.orderDataGridView.RowTemplate.Height = 23;
            this.orderDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.orderDataGridView.Size = new System.Drawing.Size(204, 133);
            this.orderDataGridView.TabIndex = 5;
            this.orderDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDataGridView_CellEndEdit);
            this.orderDataGridView.SelectionChanged += new System.EventHandler(this.orderDataGridView_SelectionChanged);
            // 
            // orderMsg
            // 
            this.orderMsg.HeaderText = "Column1";
            this.orderMsg.Name = "orderMsg";
            // 
            // orderMoney
            // 
            this.orderMoney.HeaderText = "Column2";
            this.orderMoney.Name = "orderMoney";
            // 
            // CashRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 527);
            this.Controls.Add(this.orderDataGridView);
            this.Controls.Add(this.productListDataGridView);
            this.Controls.Add(this.payWayDataGridView);
            this.Name = "CashRegisterWindow";
            this.Text = "收银台";
            this.Load += new System.EventHandler(this.CashRegisterWindow_Load);
            this.Shown += new System.EventHandler(this.CashRegisterWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.payWayDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView payWayDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridView productListDataGridView;
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNormalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderMoney;
    }
}