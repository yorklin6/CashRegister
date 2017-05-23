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
            this.ColumnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRetailSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNormalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_order = new System.Windows.Forms.DataGridView();
            this.orderMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_order)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.dataGridView_payWay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_payWay.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridView_payWay.Size = new System.Drawing.Size(200, 168);
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
            this.dataGridView_productList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_productList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_productList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIndex,
            this.ColumnProductCode,
            this.ColumnGoodsName,
            this.ColumnRetailSpecification,
            this.ColumnAmount,
            this.ColumnNormalPrice,
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
            this.dataGridView_productList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_productList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_productList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_productList.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_productList.MultiSelect = false;
            this.dataGridView_productList.Name = "dataGridView_productList";
            this.dataGridView_productList.RowHeadersVisible = false;
            this.dataGridView_productList.RowTemplate.Height = 23;
            this.dataGridView_productList.Size = new System.Drawing.Size(800, 400);
            this.dataGridView_productList.TabIndex = 1;
            this.dataGridView_productList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellContentClick);
            this.dataGridView_productList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellEndEdit);
            this.dataGridView_productList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_RowEnter);
            this.dataGridView_productList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.productListDataGridView_RowsAdded);
            this.dataGridView_productList.SelectionChanged += new System.EventHandler(this.productListDataGridView_SelectionChanged);
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
            // ColumnGoodsName
            // 
            this.ColumnGoodsName.FillWeight = 200F;
            this.ColumnGoodsName.HeaderText = "名称";
            this.ColumnGoodsName.Name = "ColumnGoodsName";
            // 
            // ColumnRetailSpecification
            // 
            this.ColumnRetailSpecification.HeaderText = "规格";
            this.ColumnRetailSpecification.Name = "ColumnRetailSpecification";
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.HeaderText = "数量";
            this.ColumnAmount.Name = "ColumnAmount";
            // 
            // ColumnNormalPrice
            // 
            this.ColumnNormalPrice.HeaderText = "单价";
            this.ColumnNormalPrice.Name = "ColumnNormalPrice";
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
            // dataGridView_order
            // 
            this.dataGridView_order.AllowUserToAddRows = false;
            this.dataGridView_order.AllowUserToDeleteRows = false;
            this.dataGridView_order.AllowUserToResizeColumns = false;
            this.dataGridView_order.AllowUserToResizeRows = false;
            this.dataGridView_order.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_order.CausesValidation = false;
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
            this.dataGridView_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_order.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_order.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_order.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_order.MultiSelect = false;
            this.dataGridView_order.Name = "dataGridView_order";
            this.dataGridView_order.ReadOnly = true;
            this.dataGridView_order.RowHeadersVisible = false;
            this.dataGridView_order.RowTemplate.Height = 23;
            this.dataGridView_order.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_order.Size = new System.Drawing.Size(200, 162);
            this.dataGridView_order.TabIndex = 5;
            this.dataGridView_order.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDataGridView_CellEndEdit);
            this.dataGridView_order.SelectionChanged += new System.EventHandler(this.orderDataGridView_SelectionChanged);
            // 
            // orderMsg
            // 
            this.orderMsg.HeaderText = "Column1";
            this.orderMsg.Name = "orderMsg";
            this.orderMsg.ReadOnly = true;
            // 
            // orderMoney
            // 
            this.orderMoney.HeaderText = "Column2";
            this.orderMoney.Name = "orderMoney";
            this.orderMoney.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 84);
            this.label7.TabIndex = 38;
            this.label7.Text = "快捷键\r\nHOME:选择支付方式\r\nDELETE:删除商品\r\nF9:会员充值\r\nF4:挂单\r\nF5:挂单恢复\r\nEND:基本信息设置";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView_productList);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 400);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.dataGridView_payWay);
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 168);
            this.panel2.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(584, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 168);
            this.panel3.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel4.Location = new System.Drawing.Point(399, 400);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 165);
            this.panel4.TabIndex = 42;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel5.Controls.Add(this.dataGridView_order);
            this.panel5.Location = new System.Drawing.Point(200, 400);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 162);
            this.panel5.TabIndex = 43;
            // 
            // ProductListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductListWindow";
            this.Text = "收银台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductListWindow_FormClosing);
            this.Load += new System.EventHandler(this.ProductListWindow_Load);
            this.Shown += new System.EventHandler(this.ProductListWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_payWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_order)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRetailSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNormalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}