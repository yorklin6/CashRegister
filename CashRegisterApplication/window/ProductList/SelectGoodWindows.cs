using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CashRegiterApplication;
using CashRegisterApplication.model;
using Newtonsoft.Json;

namespace CashRegisterApplication.window.ProductList
{
    public partial class SelectGoodWindows : Form
    {
        public SelectGoodWindows()
        {
            InitializeComponent();
        }

        private void SelectGoods_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_productList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex + " Column:" + e.ColumnIndex);
        }
        List<ProductPricing> gAllSelectList;
        internal void ShowByProductList(List<ProductPricing> list)
        {
            this.Show();
            this.dataGridView_productList.Rows.Clear();
            gAllSelectList = list;
            int rowIndex;
            for (int i = 0; i < list.Count; ++i)
            {
                rowIndex = this.dataGridView_productList.Rows.Add();
                CommUiltl.Log("rowIndex " + rowIndex);
                CommUiltl.Log("i " + i);
                CommUiltl.Log("oStockOutDTO.details[i] " + list[i]);
                StockOutDetail detail = new StockOutDetail();
                _ProductTostockDetail(list[i], ref detail);
                SetRowsByStockOutDetail(this.dataGridView_productList.Rows[rowIndex], detail);

            }

            this.dataGridView_productList.Focus();
            this.dataGridView_productList.Select();
            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
        }
        private void _ProductTostockDetail(ProductPricing productInfo, ref StockOutDetail detail)
        {
            detail.barcode = productInfo.barcode;
            detail.goodsName = productInfo.goodsName;
            detail.unitPrice = (productInfo.retailPrice);
            detail.remark = productInfo.remark;
            detail.specification = productInfo.specification;
            detail.categoryId = productInfo.categoryId;
            detail.unit = productInfo.baseUnit;
            detail.actualCount = 1;
            detail.goodsShowSpecification = productInfo.baseUnit + "/" + productInfo.bigUnit + "/" + productInfo.specification;
            CommUiltl.Log("_ProductTostockDetail   detail.goodsShowSpecification :" + detail.goodsShowSpecification);
            detail.cloudProductPricing = productInfo;

        }

        private void SetRowsByStockOutDetail(DataGridViewRow currentRow, StockOutDetail detail)
        {
            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value = detail.barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:" + detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.goodsShowSpecification;

            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(detail.unitPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = RetailPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = detail.actualCount;
            currentRow.Cells[CELL_INDEX.PRODUCT_REMARK].Value = detail.remark;
            currentRow.Cells[CELL_INDEX.PRODUCT_JSON].Value = JsonConvert.SerializeObject(detail);
        }

        private void dataGridView_productList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击选中
            SelectRow(e.RowIndex);
        }

        private void SelectRow(int rowIndex)
        {
            //gAllSelectList
            CommUiltl.Log("SelectRow rowIndex " + rowIndex);
            CenterContral.CallBackBySelectGoodWindow(gAllSelectList[rowIndex]);
            this.Hide();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("keyData:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        //MessageBox.Show("Keys.Enter: CurrentCell.RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
                        if (this.dataGridView_productList.CurrentCell != null && this.dataGridView_productList.CurrentCell.RowIndex> -1)
                        {
                            SelectRow(this.dataGridView_productList.CurrentCell.RowIndex);
                        }
                        return true;
                    }
                    break;
                case System.Windows.Forms.Keys.Escape:
                    {
                        returnPreventWindows();
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectGoodWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            returnPreventWindows();
            CenterContral.Window_SelectGood = new SelectGoodWindows();
        }

        private void returnPreventWindows()
        {
            CenterContral.EecBySelectGoodWindow();
            this.Hide();
        }
    }

    public static class CELL_INDEX
    {
        public static int INDEX = 0;
        public static int PRODUCT_CODE = 1;
        public static int PRODUCT_NAME = 2;
        public static int PRODUCT_SPECIFICATION = 3;
        public static int PRODUCT_RetailDetailCount = 4;
        public static int PRODUCT_NORMAL_PRICE = 5;

        public static int PRODUCT_MONEY = 6;
        public static int PRODUCT_REMARK = 7;
        public static int PRODUCT_JSON = 8;


        public static int ORDER_COLUMN = 1;
        public static int RECIEVE_FEE_ROW = 0;
        public static int ORDER_FEE_ROW = 1;
        public static int CHANGE_FEE_ROW = 2;
    }
}
