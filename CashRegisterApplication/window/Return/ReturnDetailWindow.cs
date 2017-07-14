using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.Return
{
    public partial class ReturnDetailWindow : Form
    {
        public ReturnDetailWindow()
        {
            InitializeComponent();
        }

        private void HitoryDetailWindow_Load(object sender, EventArgs e)
        {
            CenterContral.Init();
            StockOutDTO oLastStockmsg = new StockOutDTO();
            CenterContral.GetLastSotckOutOrder(ref oLastStockmsg);
            ShowDetailStockOut(oLastStockmsg);
        }


        private void HitoryDetailWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            escapeToPreWindows();
        }

        private void escapeToPreWindows()
        {
            CenterContral.Window_ProductList.CallShow();
            this.Hide();
        }
        StockOutDTO gStockOutDTO;
        long returnFee = 0;
        public void ShowDetailStockOut(StockOutDTO oStockOutDTO)
        {
            gStockOutDTO = oStockOutDTO;
            this.Show();
            this.ActiveControl = this.button1;
            this.dataGridView_productList.Rows.Clear();

            this.label_searisenumber.Text = "退货单(流水号:" + oStockOutDTO.Base.serialNumber + ")";
            this.label_member_account2.Text = oStockOutDTO.oMember.memberAccount;

            //折扣额
            this.label_discount_amount.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.discountAmount);
      
            this.label_discount_rate.Text = oStockOutDTO.Base.discountRate.ToString();

            this.label_orderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.orderAmount);
            returnFee = oStockOutDTO.Base.orderAmount;
            this.label_returnFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(returnFee);
            this.label_stockOutTime.Text= oStockOutDTO.Base.stockOutTime.Substring(0, 19);
            this.label_state.Text = CenterContral.GetStateDscByStockOutBase(oStockOutDTO.Base);
            //this.label_total_product_count.Text = oStockOutDTO.Base.totalProductCount.ToString();
            for (int i = 0; i < oStockOutDTO.details.Count; ++i)
            {
                int rowIndex = this.dataGridView_productList.Rows.Add();
                CommUiltl.Log("rowIndex " + rowIndex);
                CommUiltl.Log("i " + i);
                CommUiltl.Log("oStockOutDTO.details[i] " + oStockOutDTO.details[i]);

                SetRowsByStockOutDetail(this.dataGridView_productList.Rows[rowIndex], oStockOutDTO.details[i]);
            }

            if (0 > oStockOutDTO.details.Count)
            {
                //默认选中第一行
                this.dataGridView_productList.Focus();
                this.dataGridView_productList.Select();
                this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
                this.dataGridView_productList.BeginEdit(true);
            }
           
        }

        private void SetRowsByStockOutDetail(DataGridViewRow currentRow, StockOutDetail detail)
        {
            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.GOODS_KEYWORD].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.GOODS_KEYWORD].Value = detail.postKeyWord;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:" + detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.goodsShowSpecification;

            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(detail.unitPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;

            currentRow.Cells[CELL_INDEX.PRODUCT_REMARK].Value = detail.remark;
            //currentRow.Cells[CELL_INDEX.PRODUCT_JSON].Value = JsonConvert.SerializeObject(detail);
            //总价和数量
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = CommUiltl.CoverMoneyUnionToStrYuan(detail.subtotal);
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = CenterContral.GetGoodsCount(detail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            //打印
            string showTips = "确认退货";
            var confirmPayApartResult = MessageBox.Show("确认退货:"+this.label_returnFee+"元",
                                 showTips,
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            
            CenterContral.ReturnOrder();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消订单
            string showTips = "是否要删除订单";
            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "删除订单确认",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            
            if (!CenterContral.DeleteOrder(gStockOutDTO))
            {
                return;
            }
            MessageBox.Show("取消成功", "取消订单操作");
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Escape:
                    {
                        escapeToPreWindows();
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label_searisenumber_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_productList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_productList.CurrentCell == null)
            {
                MessageBox.Show("提示", "请选中商品");
                return;
            }
            string showTips = "商品:" + this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value+" 不进行退货吗？";
            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "删除退货单商品操作",
                                  MessageBoxButtons.YesNo);
            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            int iIndex = this.dataGridView_productList.CurrentRow.Index;
            CommUiltl.Log("iIndex:" + iIndex);
           
            this.dataGridView_productList.Rows.RemoveAt(iIndex);
            gStockOutDTO.details.RemoveAt(iIndex);
            //重新计算退货价钱
            _CaculatePrice();
        }

        private void _CaculatePrice()
        {
            long rowCount = gStockOutDTO.details.Count;
            long orderPrice = 0, subtotalCount = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                subtotalCount += gStockOutDTO.details[index].actualCount;
                orderPrice += gStockOutDTO.details[index].subtotal;
            }
            CenterContral.updateOrderAmount(orderPrice, ref gStockOutDTO);
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(gStockOutDTO.Base.orderAmount);

            gStockOutDTO.Base.totalProductCount = subtotalCount;
            UpdateTextShow();
            return;
        }

        private void UpdateTextShow()
        {
            //更新总价

        }
    }
    public static class CELL_INDEX
    {
        public static int INDEX = 0;
        public static int GOODS_KEYWORD = 1;
        public static int PRODUCT_NAME = 2;
        public static int PRODUCT_SPECIFICATION = 3;
        public static int PRODUCT_RetailDetailCount = 4;
        public static int PRODUCT_NORMAL_PRICE = 5;

        public static int PRODUCT_MONEY = 6;//总价
        public static int PRODUCT_REMARK = 7;
        public static int PRODUCT_JSON = 8;


        public static int ORDER_COLUMN = 1;
        public static int RECIEVE_FEE_ROW = 0;
        public static int ORDER_FEE_ROW = 1;
        public static int CHANGE_FEE_ROW = 2;
    }
}
