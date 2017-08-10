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
        public void ShowByContral()
        {
            this.Show();
        }
        public void ShowByContral(DbStockOutDTO oLastStockmsg)
        {
         
            gResetRow = true;
            
            CenterContral.Init();
             ShowDetailStockOut(oLastStockmsg);
            this.Show();
            gConstructEnd = true;
           
        }

        private void HitoryDetailWindow_Load(object sender, EventArgs e)
        {
            gConstructEnd = false;
            DbStockOutDTO oLastStockmsg = new DbStockOutDTO();
         
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
        DbStockOutDTO gFromDTO;
        RetailReturnDTO gReturnDTO;
        long returnFee = 0;
        public void ShowDetailStockOut(DbStockOutDTO oStockOutDTO)
        {
            gFromDTO = oStockOutDTO;
            this.Show();
            this.ActiveControl = this.button_return;
            this.dataGridView_productList.Rows.Clear();

            this.label_searisenumber.Text = "退货单(流水号:" + oStockOutDTO.Base.serialNumber + ")";
            this.label_member_account2.Text = oStockOutDTO.oMember.memberAccount;

            //折扣额
            this.label_discount_amount.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.discountAmount);

            this.label_discount_rate.Text = CommUiltl.CoveDiscountDiv100( oStockOutDTO.Base.discountRate);

            this.label_orderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.orderAmount);
            returnFee = oStockOutDTO.Base.orderAmount;
            this.label_returnFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(returnFee);
           // this.label_stockOutTime.Text = oStockOutDTO.Base.stockOutTime.Substring(0, 19);
            this.label_state.Text = CenterContral.GetStateDscByStockOutBase(oStockOutDTO);
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

        private void SetRowsByStockOutDetail(DataGridViewRow currentRow, DbStockOutDetail detail)
        {
            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.GOODS_KEYWORD].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.GOODS_KEYWORD].Value = detail.barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:" + detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.baseUnit;

            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(detail.unitPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;

            currentRow.Cells[CELL_INDEX.PRODUCT_REMARK].Value = detail.remark;
            //currentRow.Cells[CELL_INDEX.PRODUCT_JSON].Value = JsonConvert.SerializeObject(detail);
            //总价和数量
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = CommUiltl.CoverMoneyUnionToStrYuan(detail.subtotal);
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = CenterContral.GetGoodsCount(detail);
        }

        internal void ShowByComfirWindow(long returnMoney)
        {
            gReturnDTO.Base.orderAmount = returnMoney;

            if (!CenterContral.ReturnOrder(gReturnDTO))
            {
                return;
            }
            MessageBox.Show("退货成功", "提示");
            //成功后返回
            CenterContral.Window_ProductList.ShowWindows();
            this.Hide();
        }

        internal static void ShowByReturnMoneyWindow(long orderAmount)
        {
            CenterContral.Window_ReturnMoneyConfirmWindow.ShowByReturnMoneyWindow(orderAmount);

        }


        private void button_return_Click(object sender, EventArgs e)
        {
            gReturnDTO = new RetailReturnDTO();
            SetReturnDtoByStockOutDto(ref gReturnDTO);
            CenterContral.Window_ReturnMoneyConfirmWindow.CallByReturnDetailWindow(gReturnDTO.Base.orderAmount);
        }

        private void CallByCenterContral(long returnMoney)
        {
            
            
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

                oRetailReturnDetail.baseUnit = stockDetail.baseUnit;
                oRetailReturnDetail.bigUnit = stockDetail.bigUnit;
                oRetailReturnDetail.unitConversion = stockDetail.unitConversion;

                oRetailReturnDetail.unitPrice = stockDetail.unitPrice;

                oRetailReturnDetail.subtotal = stockDetail.subtotal;
                oRetailReturnDetail.returnCount= stockDetail.orderCount;
               

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
                        button_modify_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.Delete:
                    {
                        button_delete_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.Enter:
                    {
                        if (this.dataGridView_productList.CurrentRow.Index == ( this.dataGridView_productList.RowCount -1 ))
                        {
                            //最后一行
                            CommUiltl.Log("last row:" + this.dataGridView_productList.CurrentRow.Index);

                            this.ActiveControl = this.button_return;
                            return true;
                            //  return base.ProcessCmdKey(ref msg, keyData);
                        }
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
                subtotalCount += gFromDTO.details[index].orderCount;
                orderPrice += gFromDTO.details[index].subtotal;
                CommUiltl.Log("subtotal:"+ gFromDTO.details[index].subtotal);
            }
            CommUiltl.Log("orderPrice:" + orderPrice);
            CenterContral.updateOrderAmount(orderPrice, ref gFromDTO);
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(gFromDTO.Base.orderAmount);
            CommUiltl.Log("gFromDTO.Base.orderAmount:" + gFromDTO.Base.orderAmount);
            gFromDTO.Base.totalProductCount = subtotalCount;
            //更新总价
            returnFee = gFromDTO.Base.orderAmount;
            this.label_returnFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(returnFee);
            return;
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

        private void dataGridView_productList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //e.RowIndex;
            //重新定义序号
            CommUiltl.Log("dataGridView_productList_RowsRemoved row:" + e.RowIndex + " RowCount" + this.dataGridView_productList.RowCount);

            for (int i = 0, rowIndex = 0; i < this.dataGridView_productList.RowCount; ++i)
            {
                this.dataGridView_productList.Rows[i].Cells[CELL_INDEX.INDEX].Value = rowIndex + 1;
                ++rowIndex;
            }
        }

        
        private bool gDeleteEventFlag = false;
        private bool gConstructEnd = false;
        private DataGridViewCell gCurrentCell = null;
        private bool gResetRow = false;
        private void productListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("begin e.RowIndex：" + e.RowIndex + " ColumnIndex" + e.ColumnIndex);

            if (!gConstructEnd)
            {
                //未初始化行表的时候，这里是空的
                return;
            }
            if (gDeleteEventFlag)
            {
                CommUiltl.Log("dataGridView_productList_RowsRemoved row:" + e.RowIndex + " Column");
                //删除数据的时候，会走到这里，这里面行数已经删除
                gDeleteEventFlag = false;
                return;
            }
            CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
            if (this.dataGridView_productList.CurrentCell.ColumnIndex != e.ColumnIndex ||
                this.dataGridView_productList.CurrentCell.RowIndex != e.RowIndex)
            {
                CommUiltl.Log("ColumnIndex != e.ColumnIndex");
                //非当前行
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount)
            {
                CommUiltl.Log(" e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount and  _ResetMoneyByRow and _SetCurrentPointToRetailDetailCount  ");
                if (!_ResetMoneyByRow(e.RowIndex, e.ColumnIndex))
                {
                    return;
                }
                //_SetCurrentPointToRetailDetailCount(e.RowIndex, CELL_INDEX.PRODUCT_NORMAL_PRICE);
                return;
            }

        }
        private bool _ResetMoneyByRow(int rowIndex, int columnIndex)
        {

            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //价钱为空，就停止
                return false;
            }
            var stockOutDetail = gFromDTO.details[rowIndex];
            CommUiltl.Log("rowIndex:rowIndex" + rowIndex + " GOODS_KEYWORD:" + this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.GOODS_KEYWORD].Value.ToString());
            CommUiltl.Log("detail count:" + gFromDTO.details.Count);
            long actualCount = 0, unitPrice = 0;
            CommUiltl.Log("PRODUCT_RetailDetailCount:" + this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value);
            if (!CommUiltl.CoverStrToLong(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value, out actualCount))
            {
                MessageBox.Show("数量错误");
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
                return false;
            }

            if (actualCount > stockOutDetail.orderCount)
            {
                 MessageBox.Show("数量错误，退货数不能大于订单数数");
                this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = stockOutDetail.orderCount;
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
                return false;
            }
            stockOutDetail.orderCount = actualCount;
            stockOutDetail.subtotal = stockOutDetail.orderCount * stockOutDetail.unitPrice;

            this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value = CommUiltl.CoverMoneyUnionToStrYuan(stockOutDetail.subtotal);
            CommUiltl.Log("unitPrice:" + unitPrice);

            //重新计算退货价钱
            _CaculatePrice();
            //string strRetailCount = this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value.ToString();
            //if (!_CheckRetailAccount(gFromDTO.details[rowIndex], strRetailCount, ref actualCount))
            //{
            //    _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
            //    //_SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount]);
            //    MessageBox.Show("错误数量");
            //    return false;
            //}

            //if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value, out unitPrice))
            //{
            //    _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_NORMAL_PRICE);
            //    MessageBox.Show("错误金额");
            //    return false;
            //}

            //CommUiltl.Log("unitPrice:" + unitPrice);
            //_UpdateStockOutDtoDetailMoney(gFromDTO.details[rowIndex], strRetailCount, actualCount, unitPrice);
            //this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value = CommUiltl.CoverMoneyUnionToStrYuan(gFromDTO.details[rowIndex].subtotal);
            //_UpdateStockBaseMsg();
            return true;
        }
        bool gMoveToRetailDetailCountFlag = false;//用来控制，是否要移动光标到商品数量
        private void _SetCurrentPointToRetailDetailCount(int rowIndex, int columnIndex)
        {
            CommUiltl.Log("_GotoNextBarcode RowIndex:" + rowIndex + " this.dataGridView_productList.RowCount:" + this.dataGridView_productList.RowCount);
            if (rowIndex >= 0  && rowIndex < this.dataGridView_productList.RowCount)
            {
                CommUiltl.Log("_SetCurrentPointToRetailDetailCount row:" + rowIndex + " Column" + columnIndex);
                gMoveToRetailDetailCountFlag = true;
                gCurrentCell = this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex];
            }
           
        }

        private void productListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("begin ");
            if (this.dataGridView_productList.CurrentCell == null)
            {
                CommUiltl.Log("this.dataGridView_productList.CurrentCell == null");
                return;
            }
            if (!gConstructEnd)
            {
                CommUiltl.Log("gConstructEnd ");
                //未初始化行表的时候，这里是空的
                return;
            }
            if (gCurrentCell == null)
            {
                CommUiltl.Log("gCurrentCell== null ");
                return;
            }
            CommUiltl.Log("gCurrentCell:" + gCurrentCell);
            if (gCurrentCell.RowIndex < 0)
            {
                CommUiltl.Log("gCurrentCell.RowIndex<0");
                return;
            }
            if (gResetRow)
            {
                CommUiltl.Log("gResetRow:" + gResetRow);
                gResetRow = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
                this.dataGridView_productList.CurrentCell.Selected = true;
                return;
            }
            if (gMoveToRetailDetailCountFlag)
            {
                CommUiltl.Log("gMoveToRetailDetailCountFlag:" + gMoveToRetailDetailCountFlag);

                gMoveToRetailDetailCountFlag = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
                this.dataGridView_productList.CurrentCell.Selected = true;
            }
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
