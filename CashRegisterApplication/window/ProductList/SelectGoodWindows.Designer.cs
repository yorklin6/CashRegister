namespace CashRegisterApplication.window.ProductList
{
    partial class SelectGoodWindows
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectGoodWindows));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_productList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.99062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 600);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // dataGridView_productList
            // 
            this.dataGridView_productList.AllowUserToAddRows = false;
            this.dataGridView_productList.AllowUserToDeleteRows = false;
            this.dataGridView_productList.AllowUserToResizeColumns = false;
            this.dataGridView_productList.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_productList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_productList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_productList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_productList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_productList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_productList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_productList.EnableHeadersVisualStyles = false;
            this.dataGridView_productList.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView_productList.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_productList.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_productList.MultiSelect = false;
            this.dataGridView_productList.Name = "dataGridView_productList";
            this.dataGridView_productList.ReadOnly = true;
            this.dataGridView_productList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_productList.RowHeadersVisible = false;
            this.dataGridView_productList.RowTemplate.Height = 23;
            this.dataGridView_productList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_productList.Size = new System.Drawing.Size(779, 600);
            this.dataGridView_productList.TabIndex = 1;
            this.dataGridView_productList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_productList_CellContentClick);
            this.dataGridView_productList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_productList_CellDoubleClick);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnIndex.FillWeight = 10F;
            this.ColumnIndex.HeaderText = "序";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.ReadOnly = true;
            this.ColumnIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIndex.Width = 30;
            // 
            // ColumnProductCode
            // 
            this.ColumnProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProductCode.FillWeight = 15F;
            this.ColumnProductCode.HeaderText = "商品货号";
            this.ColumnProductCode.Name = "ColumnProductCode";
            this.ColumnProductCode.ReadOnly = true;
            // 
            // ColumnGoodsName
            // 
            this.ColumnGoodsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnGoodsName.FillWeight = 25F;
            this.ColumnGoodsName.HeaderText = "名称";
            this.ColumnGoodsName.Name = "ColumnGoodsName";
            this.ColumnGoodsName.ReadOnly = true;
            // 
            // ColumnRetailSpecification
            // 
            this.ColumnRetailSpecification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRetailSpecification.FillWeight = 8F;
            this.ColumnRetailSpecification.HeaderText = "单位";
            this.ColumnRetailSpecification.Name = "ColumnRetailSpecification";
            this.ColumnRetailSpecification.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAmount.FillWeight = 8F;
            this.ColumnAmount.HeaderText = "数量";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Visible = false;
            // 
            // ColumnNormalPrice
            // 
            this.ColumnNormalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnNormalPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNormalPrice.FillWeight = 10F;
            this.ColumnNormalPrice.HeaderText = "单价";
            this.ColumnNormalPrice.Name = "ColumnNormalPrice";
            this.ColumnNormalPrice.ReadOnly = true;
            // 
            // ColumnMoney
            // 
            this.ColumnMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMoney.FillWeight = 10F;
            this.ColumnMoney.HeaderText = "金额";
            this.ColumnMoney.Name = "ColumnMoney";
            this.ColumnMoney.ReadOnly = true;
            this.ColumnMoney.Visible = false;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnRemark.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnRemark.FillWeight = 15F;
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.HeaderText = "商品ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // SelectGoodWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectGoodWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择商品";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectGoodWindows_FormClosing);
            this.Load += new System.EventHandler(this.SelectGoods_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_productList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRetailSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNormalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}