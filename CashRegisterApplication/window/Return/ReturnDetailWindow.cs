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

        public void ShowByContral(StockOutDTO oLastStockmsg)
        {
            CenterContral.Init();
             oLastStockmsg = new StockOutDTO();
            CenterContral.GetLastSotckOutOrder(ref oLastStockmsg);
            StockOutDTO oStock = new StockOutDTO();
            CenterContral.GetStockBySerialNumber(oLastStockmsg.Base.serialNumber,ref oStock);
            ShowDetailStockOut(oLastStockmsg);
            this.Show();
        }

        private void HitoryDetailWindow_Load(object sender, EventArgs e)
        {
            StockOutDTO oLastStockmsg = new StockOutDTO(); 
            ShowByContral(oLastStockmsg);
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
        StockOutDTO gFromDTO;
        RetailReturnDTO gReturnDTO;
        long returnFee = 0;
        public void ShowDetailStockOut(StockOutDTO oStockOutDTO)
        {
            gFromDTO = oStockOutDTO;
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
           // this.label_stockOutTime.Text = oStockOutDTO.Base.stockOutTime.Substring(0, 19);
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
            currentRow.Cells[CELL_INDEX.GOODS_KEYWORD].Value = detail.barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:" + detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.unit;

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
            var confirmPayApartResult = MessageBox.Show("确认退货:" + this.label_returnFee.Text + "元",
                                 showTips,
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            gReturnDTO = new RetailReturnDTO();
            SetReturnDtoByStockOutDto(ref gReturnDTO);

            if (gReturnDTO.Base.orderAmount == 0)
            {
                MessageBox.Show("退货总金额为0元，不支持退货", "提示");
                return;
            }

            if (!CenterContral.ReturnOrder(gReturnDTO))
            {
                return;
            }
            //成功后返回
            escapeToPreWindows();
        }

      

        private void SetReturnDtoByStockOutDto(ref RetailReturnDTO oRetailReturnDTO)
        {
            //base
            oRetailReturnDTO.Base = new RetailReturnBase();
            oRetailReturnDTO.details = new List<RetailReturnDetail>();

            oRetailReturnDTO.Base.generateSerialNum();

            oRetailReturnDTO.Base.storeId = CenterContral.oStoreWhouse.storeId;
            oRetailReturnDTO.Base.whouseId = CenterContral.oStoreWhouse.storeWhouseId;
            oRetailReturnDTO.Base.whouseName = CenterContral.oStoreWhouse.name;

            oRetailReturnDTO.Base.relatedOrder = gFromDTO.Base.relatedOrder;
            oRetailReturnDTO.Base.clientId = gFromDTO.Base.clientId;

            oRetailReturnDTO.Base.orderAmount = gFromDTO.Base.orderAmount;

            oRetailReturnDTO.Base.posId = CenterContral.iPostId;
            oRetailReturnDTO.Base.cashierId = CenterContral.DefaultUserId;
            oRetailReturnDTO.Base.cashierName = CenterContral.DefaultUserName;

            oRetailReturnDTO.Base.remark = gFromDTO.Base.remark;
            oRetailReturnDTO.Base.createTime = gFromDTO.Base.storeId;

            for (int i=0;i< gFromDTO.details.Count; ++i)
            {
                var stockDetail = gFromDTO.details[i];
                var dataGridViw = dataGridView_productList.Rows[i];
                RetailReturnDetail oRetailReturnDetail = new RetailReturnDetail();


                oRetailReturnDetail.id = stockDetail.id;

                oRetailReturnDetail.goodsId = stockDetail.goodsId;

                oRetailReturnDetail.goodsName = stockDetail.goodsName;

                oRetailReturnDetail.barcode = stockDetail.barcode;

                oRetailReturnDetail.categoryId = stockDetail.categoryId;

                oRetailReturnDetail.specification = stockDetail.specification;

                oRetailReturnDetail.produceTime = stockDetail.produceTime;

                oRetailReturnDetail.expireTime = stockDetail.expireTime;

                oRetailReturnDetail.unit = stockDetail.expireTime;

                oRetailReturnDetail.unitPrice = stockDetail.unitPrice;

                if (stockDetail.isBarCodeMoneyGoods == CenterContral.IS_BARCODE_MOENY_GOODS)
                {
                    //计重类,不允许只退几斤，只允许全退
                    oRetailReturnDetail.subtotal = stockDetail.subtotal  ;
                    oRetailReturnDetail.returnCount = 1;
                }
                else
                {
                    long returnCount = 0;
                    CommUiltl.ConverStrYuanToUnion(dataGridViw.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value
                   , out returnCount);
                    oRetailReturnDetail.returnCount = returnCount;
                    long subtotal = 0;
                    CommUiltl.ConverStrYuanToUnion(dataGridViw.Cells[CELL_INDEX.PRODUCT_MONEY].Value, out subtotal);
                    oRetailReturnDetail.subtotal = 0;
                }
               

                oRetailReturnDTO.details.Add(oRetailReturnDetail);
            }

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
                case System.Windows.Forms.Keys.Home:
                    {
                        escapeToPreWindows();
                    }
                    break;
                case System.Windows.Forms.Keys.Multiply:
                    {
                        //button_delete_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.Delete:
                    {
                        button_delete_Click(null, null);
                        break;
                    }

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
                MessageBox.Show("请选中商品","提示");
                return;
            }

            string showTips = "商品:" + this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value + " 不进行退货吗？";
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
            gFromDTO.details.RemoveAt(iIndex);
            //重新计算退货价钱
            _CaculatePrice();
        }

        private void _CaculatePrice()
        {
            long rowCount = gFromDTO.details.Count;
            long orderPrice = 0, subtotalCount = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                subtotalCount += gFromDTO.details[index].actualCount;
                orderPrice += gFromDTO.details[index].subtotal;
            }
            CenterContral.updateOrderAmount(orderPrice, ref gFromDTO);
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(gFromDTO.Base.orderAmount);

            gFromDTO.Base.totalProductCount = subtotalCount;
            UpdateTextShow();
            return;
        }

        private void UpdateTextShow()
        {
            //更新总价
            returnFee = gFromDTO.Base.orderAmount;
            this.label_returnFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(returnFee);
        }

        private void button_modify_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_productList.CurrentCell == null)
            {
                MessageBox.Show("请选中商品", "提示");
                return;
            }
            CommUiltl.Log("button_modify_Click:");
            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount];
            this.dataGridView_productList.BeginEdit(true);
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
