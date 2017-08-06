using System;
using System.Drawing.Printing;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductListWindow));
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label_receiveFee = new System.Windows.Forms.Label();
            this.label_orderFee = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label_changeFee = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label_serial_number = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label_defaultUser = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label_postId = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_connectStatus = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label_discount_amount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label_discount_rate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_member_balance = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_member_account = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label_Sate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_local_save_stock_number = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label_member_point = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_total_product_count = new System.Windows.Forms.Label();
            this.dataGridView_checkout = new System.Windows.Forms.DataGridView();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_checkout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label_receiveFee, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label_orderFee, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label28, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label_changeFee, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label26, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label30, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(207, 394);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.42857F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.57143F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(163, 140);
            this.tableLayoutPanel6.TabIndex = 42;
            // 
            // label_receiveFee
            // 
            this.label_receiveFee.AutoSize = true;
            this.label_receiveFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_receiveFee.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_receiveFee.Location = new System.Drawing.Point(82, 47);
            this.label_receiveFee.Margin = new System.Windows.Forms.Padding(0);
            this.label_receiveFee.Name = "label_receiveFee";
            this.label_receiveFee.Size = new System.Drawing.Size(80, 53);
            this.label_receiveFee.TabIndex = 6;
            this.label_receiveFee.Text = "0.00";
            this.label_receiveFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_orderFee
            // 
            this.label_orderFee.AutoSize = true;
            this.label_orderFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_orderFee.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_orderFee.Location = new System.Drawing.Point(82, 1);
            this.label_orderFee.Margin = new System.Windows.Forms.Padding(0);
            this.label_orderFee.Name = "label_orderFee";
            this.label_orderFee.Size = new System.Drawing.Size(80, 45);
            this.label_orderFee.TabIndex = 5;
            this.label_orderFee.Text = "0.00";
            this.label_orderFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.Location = new System.Drawing.Point(1, 101);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 38);
            this.label28.TabIndex = 3;
            this.label28.Text = "应找零头";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // label_changeFee
            // 
            this.label_changeFee.AutoSize = true;
            this.label_changeFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_changeFee.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_changeFee.Location = new System.Drawing.Point(82, 101);
            this.label_changeFee.Margin = new System.Windows.Forms.Padding(0);
            this.label_changeFee.Name = "label_changeFee";
            this.label_changeFee.Size = new System.Drawing.Size(80, 38);
            this.label_changeFee.TabIndex = 2;
            this.label_changeFee.Text = "0.00";
            this.label_changeFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(1, 1);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 45);
            this.label26.TabIndex = 1;
            this.label26.Text = "总计应收";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(1, 47);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 53);
            this.label30.TabIndex = 4;
            this.label30.Text = "实际已收";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 8;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 4);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.03226F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.602151F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.35484F));
            this.tableLayoutPanel5.Controls.Add(this.label_serial_number, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.label22, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label_defaultUser, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label20, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label_postId, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label_connectStatus, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.label_time, 7, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1, 535);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(782, 26);
            this.tableLayoutPanel5.TabIndex = 41;
            // 
            // label_serial_number
            // 
            this.label_serial_number.AutoSize = true;
            this.label_serial_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_serial_number.Location = new System.Drawing.Point(336, 1);
            this.label_serial_number.Margin = new System.Windows.Forms.Padding(0);
            this.label_serial_number.Name = "label_serial_number";
            this.label_serial_number.Size = new System.Drawing.Size(224, 24);
            this.label_serial_number.TabIndex = 5;
            this.label_serial_number.Text = "xxxxxx";
            this.label_serial_number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(269, 1);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 24);
            this.label22.TabIndex = 4;
            this.label22.Text = "流水号";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_defaultUser
            // 
            this.label_defaultUser.AutoSize = true;
            this.label_defaultUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_defaultUser.Location = new System.Drawing.Point(202, 1);
            this.label_defaultUser.Margin = new System.Windows.Forms.Padding(0);
            this.label_defaultUser.Name = "label_defaultUser";
            this.label_defaultUser.Size = new System.Drawing.Size(66, 24);
            this.label_defaultUser.TabIndex = 3;
            this.label_defaultUser.Text = "0";
            this.label_defaultUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_defaultUser.Click += new System.EventHandler(this.label_defaultUser_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(135, 1);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 24);
            this.label20.TabIndex = 2;
            this.label20.Text = "收银员";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_postId
            // 
            this.label_postId.AutoSize = true;
            this.label_postId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_postId.Location = new System.Drawing.Point(68, 1);
            this.label_postId.Margin = new System.Windows.Forms.Padding(0);
            this.label_postId.Name = "label_postId";
            this.label_postId.Size = new System.Drawing.Size(66, 24);
            this.label_postId.TabIndex = 1;
            this.label_postId.Text = "-1";
            this.label_postId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(1, 1);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 24);
            this.label18.TabIndex = 0;
            this.label18.Text = "POS机号";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_connectStatus
            // 
            this.label_connectStatus.AutoSize = true;
            this.label_connectStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_connectStatus.Location = new System.Drawing.Point(561, 1);
            this.label_connectStatus.Margin = new System.Windows.Forms.Padding(0);
            this.label_connectStatus.Name = "label_connectStatus";
            this.label_connectStatus.Size = new System.Drawing.Size(66, 24);
            this.label_connectStatus.TabIndex = 6;
            this.label_connectStatus.Text = "联网";
            this.label_connectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_connectStatus.Click += new System.EventHandler(this.label_connectStatus_Click);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_time.Location = new System.Drawing.Point(628, 1);
            this.label_time.Margin = new System.Windows.Forms.Padding(0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(153, 24);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "2017.03.02 10:12";
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_time.Click += new System.EventHandler(this.label25_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label_member_balance, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label_member_account, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label31, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_Sate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 1, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(371, 394);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.52632F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.8209F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.35821F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(205, 140);
            this.tableLayoutPanel2.TabIndex = 40;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel4.Controls.Add(this.label_discount_amount, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label_discount_rate, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(43, 55);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(161, 20);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // label_discount_amount
            // 
            this.label_discount_amount.AutoSize = true;
            this.label_discount_amount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_discount_amount.Location = new System.Drawing.Point(100, 1);
            this.label_discount_amount.Margin = new System.Windows.Forms.Padding(0);
            this.label_discount_amount.Name = "label_discount_amount";
            this.label_discount_amount.Size = new System.Drawing.Size(60, 18);
            this.label_discount_amount.TabIndex = 4;
            this.label_discount_amount.Text = "0";
            this.label_discount_amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_discount_amount.Click += new System.EventHandler(this.label6_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(41, 1);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 18);
            this.label16.TabIndex = 3;
            this.label16.Text = "折扣额";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_discount_rate
            // 
            this.label_discount_rate.AutoSize = true;
            this.label_discount_rate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_discount_rate.Location = new System.Drawing.Point(1, 1);
            this.label_discount_rate.Margin = new System.Windows.Forms.Padding(0);
            this.label_discount_rate.Name = "label_discount_rate";
            this.label_discount_rate.Size = new System.Drawing.Size(39, 18);
            this.label_discount_rate.TabIndex = 2;
            this.label_discount_rate.Text = "100";
            this.label_discount_rate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(1, 118);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 21);
            this.label12.TabIndex = 10;
            this.label12.Text = "积分";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_member_balance
            // 
            this.label_member_balance.AutoSize = true;
            this.label_member_balance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_member_balance.Location = new System.Drawing.Point(43, 97);
            this.label_member_balance.Margin = new System.Windows.Forms.Padding(0);
            this.label_member_balance.Name = "label_member_balance";
            this.label_member_balance.Size = new System.Drawing.Size(161, 20);
            this.label_member_balance.TabIndex = 9;
            this.label_member_balance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(1, 97);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "余额";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_member_account
            // 
            this.label_member_account.AutoSize = true;
            this.label_member_account.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_member_account.Location = new System.Drawing.Point(43, 76);
            this.label_member_account.Margin = new System.Windows.Forms.Padding(0);
            this.label_member_account.Name = "label_member_account";
            this.label_member_account.Size = new System.Drawing.Size(161, 20);
            this.label_member_account.TabIndex = 7;
            this.label_member_account.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_member_account.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(1, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "会员卡";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(1, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "折扣率";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Location = new System.Drawing.Point(1, 28);
            this.label31.Margin = new System.Windows.Forms.Padding(0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 26);
            this.label31.TabIndex = 2;
            this.label31.Text = "挂单";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Sate
            // 
            this.label_Sate.AutoSize = true;
            this.label_Sate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Sate.Location = new System.Drawing.Point(43, 1);
            this.label_Sate.Margin = new System.Windows.Forms.Padding(0);
            this.label_Sate.Name = "label_Sate";
            this.label_Sate.Size = new System.Drawing.Size(161, 26);
            this.label_Sate.TabIndex = 1;
            this.label_Sate.Text = "打印小票";
            this.label_Sate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.13044F));
            this.tableLayoutPanel3.Controls.Add(this.label_local_save_stock_number, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(43, 28);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(161, 26);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // label_local_save_stock_number
            // 
            this.label_local_save_stock_number.AutoSize = true;
            this.label_local_save_stock_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_local_save_stock_number.Location = new System.Drawing.Point(1, 1);
            this.label_local_save_stock_number.Margin = new System.Windows.Forms.Padding(0);
            this.label_local_save_stock_number.Name = "label_local_save_stock_number";
            this.label_local_save_stock_number.Size = new System.Drawing.Size(159, 24);
            this.label_local_save_stock_number.TabIndex = 2;
            this.label_local_save_stock_number.Text = "0";
            this.label_local_save_stock_number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.94118F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.05882F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel8.Controls.Add(this.label_member_point, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.label_total_product_count, 2, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(43, 118);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(161, 21);
            this.tableLayoutPanel8.TabIndex = 14;
            this.tableLayoutPanel8.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel8_Paint);
            // 
            // label_member_point
            // 
            this.label_member_point.AutoSize = true;
            this.label_member_point.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_member_point.Location = new System.Drawing.Point(1, 1);
            this.label_member_point.Margin = new System.Windows.Forms.Padding(0);
            this.label_member_point.Name = "label_member_point";
            this.label_member_point.Size = new System.Drawing.Size(35, 20);
            this.label_member_point.TabIndex = 12;
            this.label_member_point.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(37, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "总件数";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_total_product_count
            // 
            this.label_total_product_count.AutoSize = true;
            this.label_total_product_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_total_product_count.Location = new System.Drawing.Point(69, 1);
            this.label_total_product_count.Margin = new System.Windows.Forms.Padding(0);
            this.label_total_product_count.Name = "label_total_product_count";
            this.label_total_product_count.Size = new System.Drawing.Size(91, 20);
            this.label_total_product_count.TabIndex = 14;
            this.label_total_product_count.Text = "0";
            // 
            // dataGridView_checkout
            // 
            this.dataGridView_checkout.AllowUserToAddRows = false;
            this.dataGridView_checkout.AllowUserToDeleteRows = false;
            this.dataGridView_checkout.AllowUserToResizeColumns = false;
            this.dataGridView_checkout.AllowUserToResizeRows = false;
            this.dataGridView_checkout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_checkout.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_checkout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_checkout.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_checkout.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_checkout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_checkout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_checkout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_checkout.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_checkout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_checkout.Enabled = false;
            this.dataGridView_checkout.EnableHeadersVisualStyles = false;
            this.dataGridView_checkout.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView_checkout.Location = new System.Drawing.Point(1, 394);
            this.dataGridView_checkout.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_checkout.MultiSelect = false;
            this.dataGridView_checkout.Name = "dataGridView_checkout";
            this.dataGridView_checkout.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_checkout.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView_checkout.RowHeadersVisible = false;
            this.dataGridView_checkout.RowTemplate.Height = 23;
            this.dataGridView_checkout.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_checkout.Size = new System.Drawing.Size(205, 140);
            this.dataGridView_checkout.TabIndex = 2;
            this.dataGridView_checkout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_payWay_CellContentClick);
            // 
            // Column8
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column8.HeaderText = "付款方式";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column9.HeaderText = "付款金额";
            this.Column9.Name = "Column9";
            // 
            // dataGridView_productList
            // 
            this.dataGridView_productList.AllowUserToOrderColumns = true;
            this.dataGridView_productList.AllowUserToResizeColumns = false;
            this.dataGridView_productList.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_productList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_productList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_productList, 4);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_productList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_productList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_productList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_productList.EnableHeadersVisualStyles = false;
            this.dataGridView_productList.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView_productList.Location = new System.Drawing.Point(1, 1);
            this.dataGridView_productList.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView_productList.MultiSelect = false;
            this.dataGridView_productList.Name = "dataGridView_productList";
            this.dataGridView_productList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_productList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_productList.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridView_productList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_productList.RowTemplate.Height = 23;
            this.dataGridView_productList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_productList.Size = new System.Drawing.Size(782, 392);
            this.dataGridView_productList.TabIndex = 1;
            this.dataGridView_productList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellContentClick);
            this.dataGridView_productList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_CellEndEdit);
            this.dataGridView_productList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_productList_EditingControlShowing);
            this.dataGridView_productList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.productListDataGridView_RowEnter);
            this.dataGridView_productList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.productListDataGridView_RowsAdded);
            this.dataGridView_productList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_productList_RowsRemoved);
            this.dataGridView_productList.SelectionChanged += new System.EventHandler(this.productListDataGridView_SelectionChanged);
            this.dataGridView_productList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_productList_KeyDown);
            // 
            // ColumnIndex
            // 
            this.ColumnIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnIndex.FillWeight = 10F;
            this.ColumnIndex.HeaderText = "序";
            this.ColumnIndex.Name = "ColumnIndex";
            this.ColumnIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIndex.Width = 30;
            // 
            // ColumnProductCode
            // 
            this.ColumnProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProductCode.FillWeight = 15F;
            this.ColumnProductCode.HeaderText = "商品货号";
            this.ColumnProductCode.Name = "ColumnProductCode";
            // 
            // ColumnGoodsName
            // 
            this.ColumnGoodsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnGoodsName.FillWeight = 25F;
            this.ColumnGoodsName.HeaderText = "名称";
            this.ColumnGoodsName.Name = "ColumnGoodsName";
            // 
            // ColumnRetailSpecification
            // 
            this.ColumnRetailSpecification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRetailSpecification.FillWeight = 8F;
            this.ColumnRetailSpecification.HeaderText = "单位";
            this.ColumnRetailSpecification.Name = "ColumnRetailSpecification";
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAmount.FillWeight = 8F;
            this.ColumnAmount.HeaderText = "数量";
            this.ColumnAmount.Name = "ColumnAmount";
            // 
            // ColumnNormalPrice
            // 
            this.ColumnNormalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnNormalPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNormalPrice.FillWeight = 10F;
            this.ColumnNormalPrice.HeaderText = "单价";
            this.ColumnNormalPrice.Name = "ColumnNormalPrice";
            // 
            // ColumnMoney
            // 
            this.ColumnMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMoney.FillWeight = 10F;
            this.ColumnMoney.HeaderText = "金额";
            this.ColumnMoney.Name = "ColumnMoney";
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnRemark.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnRemark.FillWeight = 15F;
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProductID.HeaderText = "商品ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.31579F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_productList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_checkout, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.69403F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.30597F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(577, 394);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(206, 140);
            this.tableLayoutPanel7.TabIndex = 43;
            this.tableLayoutPanel7.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel7_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(103, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 140);
            this.label3.TabIndex = 8;
            this.label3.Text = "F9:会员卡\r\nF10:功能菜单\r\nF11:打印开关\r\nINS:取消订单\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 140);
            this.label7.TabIndex = 7;
            this.label7.Text = "HOME:选择支付\r\nDELETE:删除商品\r\nF1:重打小票\r\nF2:零售退货\r\nF3:整单打折\r\nF4:挂单\r\nF5:挂单恢复\r\nF7:打开钱箱\r\n\r\n";
            // 
            // printDocument
            // 
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ProductListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收银台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductListWindow_FormClosing);
            this.Load += new System.EventHandler(this.ProductListWindow_Load);
            this.Shown += new System.EventHandler(this.ProductListWindow_Shown);
            this.SizeChanged += new System.EventHandler(this.ProductListWindow_SizeChanged);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_checkout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 



        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label_receiveFee;
        private System.Windows.Forms.Label label_orderFee;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label_changeFee;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_productList;
        private System.Windows.Forms.DataGridView dataGridView_checkout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label_discount_amount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_discount_rate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_member_balance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_member_account;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label_Sate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_local_save_stock_number;
        private System.Windows.Forms.Label label_serial_number;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label_defaultUser;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label_postId;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_connectStatus;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRetailSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNormalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Drawing.Printing.PrintDocument printDocument;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label_member_point;
        private Label label4;
        private Label label_total_product_count;
        private Label label3;
        private Label label7;
        private PrintDialog printDialog1;
    }
}