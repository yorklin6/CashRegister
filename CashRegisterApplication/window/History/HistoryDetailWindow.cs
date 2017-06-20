using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.History
{
    public partial class HistoryDetailWindow : Form
    {
        public HistoryDetailWindow()
        {
            InitializeComponent();
        }

        private void HitoryDetailWindow_Load(object sender, EventArgs e)
        {
        }

        private void HitoryDetailWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CenterContral.Window_HistoryDetailWindow = new HistoryDetailWindow();
            e.Cancel = false;
            escapeToPreWindows();
        }

        private void escapeToPreWindows()
        {
            CenterContral.Window_HistoryListWindow.Show();
            this.Hide();
        }
        StockOutDTO gStockOutDTO;
        public void ShowDetailStockOut(StockOutDTO oStockOutDTO)
        {
            gStockOutDTO = oStockOutDTO;
            this.Show();
            this.ActiveControl = this.button1;
            this.dataGridView_productList.Rows.Clear();
          

            this.label_searisenumber.Text = "交易明细账(流水号:" + oStockOutDTO.Base.serialNumber + ")";

            this.label_member_account.Text = oStockOutDTO.oMember.memberAccount;

            //折扣额度
            this.label_discount_amount.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.discountAmount);
            //折扣率
            this.label_discount_rate.Text = oStockOutDTO.Base.discountRate.ToString();

            this.label_orderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.orderAmount);

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

            this.dataGridView_productList.CurrentCell = null;//去掉焦点
            
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
            string showTips = "确认打印";
            var confirmPayApartResult = MessageBox.Show("是否要打印当前小票",
                                 showTips,
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            CenterContral.PrintOrder(gStockOutDTO);
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
