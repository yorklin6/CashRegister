namespace CashRegiterApplication
{
    partial class ProductListWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductListWindow));
            this.dataGridView_payWay = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_productList = new System.Windows.Forms.DataGridView();
            this.dataGridView_order = new System.Windows.Forms.DataGridView();
            this.orderMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNormalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_order)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_payWay
            // 
            this.dataGridView_payWay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_payWay.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_payWay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_payWay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.dataGridView_payWay.Location = new System.Drawing.Point(23, 320);
            this.dataGridView_payWay.Name = "dataGridView_payWay";
            this.dataGridView_payWay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_payWay.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_payWay.RowHeadersVisible = false;
            this.dataGridView_payWay.RowTemplate.Height = 23;
            this.dataGridView_payWay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_payWay.Size = new System.Drawing.Size(200, 99);
            this.dataGridView_payWay.TabIndex = 2;
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
            // dataGridView_productList
            // 
            this.dataGridView_productList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_productList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnProductCode,
            this.ColumnProductName,
            this.ColumnProductSpecification,
            this.ColumnNormalPrice,
            this.ColumnAmount,
            this.ColumnMoney,
            this.ColumnRemark,
            this.ProductID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_productList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_productList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_productList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_productList.Location = new System.Drawing.Point(23, 2);
            this.dataGridView_productList.MultiSelect = false;
            this.dataGridView_productList.Name = "dataGridView_productList";
            this.dataGridView_productList.RowHeadersVisible = false;
            this.dataGridView_productList.RowTemplate.Height = 23;
            this.dataGridView_productList.Size = new System.Drawing.Size(860, 297);
            this.dataGridView_productList.TabIndex = 1;
            this.dataGridView_productList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellContentClick);
            this.dataGridView_productList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellEndEdit);
            this.dataGridView_productList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_RowEnter);
            this.dataGridView_productList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.productListDataGridView_RowsAdded);
            this.dataGridView_productList.SelectionChanged += new System.EventHandler(this.productListDataGridView_SelectionChanged);
            // 
            // dataGridView_order
            // 
            this.dataGridView_order.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderMsg,
            this.orderMoney});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_order.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_order.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_order.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_order.Location = new System.Drawing.Point(260, 320);
            this.dataGridView_order.MultiSelect = false;
            this.dataGridView_order.Name = "dataGridView_order";
            this.dataGridView_order.RowHeadersVisible = false;
            this.dataGridView_order.RowTemplate.Height = 23;
            this.dataGridView_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_order.Size = new System.Drawing.Size(204, 133);
            this.dataGridView_order.TabIndex = 5;
            this.dataGridView_order.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDataGridView_CellEndEdit);
            this.dataGridView_order.SelectionChanged += new System.EventHandler(this.orderDataGridView_SelectionChanged);
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
            // ProductID
            // 
            this.ProductID.HeaderText = "商品ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // ProductListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 527);
            this.Controls.Add(this.dataGridView_order);
            this.Controls.Add(this.dataGridView_productList);
            this.Controls.Add(this.dataGridView_payWay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductListWindow";
            this.Text = "收银台";
            this.Load += new System.EventHandler(this.ProductListWindow_Load);
            this.Shown += new System.EventHandler(this.ProductListWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_order)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_payWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridView dataGridView_productList;
        private System.Windows.Forms.DataGridView dataGridView_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNormalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}