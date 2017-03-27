using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using CashRegisterApplication.window;
using CashRegisterApplication.comm;
using CashRegisterApplication.model;

namespace CashRegiterApplication
{

    public partial class ProductListWindow : Form
    {


        bool gConstructEnd = false;

        public ProductListWindow()
        {

            InitializeComponent();
            InitData();
        }

        private void ProductListWindow_Load(object sender, EventArgs e)
        {
            //_GoProductList();
            CurrentMsg.Window_ProductList = this;//全局窗口
            Dao.ConnecSql();
        }

     
        public System.Windows.Forms.DataGridView GetDataGridViewProduct()
        {
            return this.dataGridView_productList;
        }

        private void ProductListWindow_Shown(object sender, EventArgs e)
        {
            //当界面显示的时候加载这里
            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[0].Cells[0].Value))
            {
                this.dataGridView_productList.Rows[0].Cells[0].Value = "1";
            }
            _SetCurrentCell();
            CommUiltl.Log("ok");
        }

        private void InitData()
        {
            this.dataGridView_productList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView_productList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            long index = 0;

            this.dataGridView_order.RowHeadersVisible = false;
            this.dataGridView_order.ColumnHeadersVisible = false;

            index = this.dataGridView_order.Rows.Add();
            index = this.dataGridView_order.Rows.Add();
            index = this.dataGridView_order.Rows.Add();

            this.dataGridView_order.Rows[CELL_INDEX.RECIEVE_FEE_ROW].Cells[0].Value = "实收";
            this.dataGridView_order.Rows[CELL_INDEX.RECIEVE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].ReadOnly = true;
            this.dataGridView_order.Rows[CELL_INDEX.ORDER_FEE_ROW].Cells[0].Value = "总价";
            this.dataGridView_order.Rows[CELL_INDEX.ORDER_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].ReadOnly = true;
            this.dataGridView_order.Rows[CELL_INDEX.CHANGE_FEE_ROW].Cells[0].Value = "找零";
            this.dataGridView_order.Rows[CELL_INDEX.CHANGE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].ReadOnly = true;
            _InitOrderMsg();

            //this.productListDataGridView.AllowUserToAddRows = false;
            this.dataGridView_order.AllowUserToAddRows = false;
            this.dataGridView_payWay.AllowUserToAddRows = false;
     

            this.ColumnIndex.ReadOnly = true;
            this.ColumnGoodsName.ReadOnly = true;
            this.ColumnRetailSpecification.ReadOnly = true;
            this.ColumnRemark.ReadOnly = true;
            this.ColumnMoney.ReadOnly = true;
            this.orderMsg.ReadOnly = true;
            System.Windows.Forms.Clipboard.SetText("4891913690152");
            gConstructEnd = true;
        }
      

 
        private void _InitOrderMsg()
        {
            CurrentMsg.Order.Clean();//清空order信息
            this.dataGridView_order.Rows[CELL_INDEX.RECIEVE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";
            this.dataGridView_order.Rows[CELL_INDEX.ORDER_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";
            this.dataGridView_order.Rows[CELL_INDEX.CHANGE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";

        }

        /*
       * 弹出框，展示实收多少钱
       */
        private void _Windows_ShowRecieveMoeny()
        {
            this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = "";
            CommUiltl.Log("begin");
            long orderFee=0;
            if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value);
                return;
            }
            //跳到收钱窗口
            string strProductList=""; 
            _GenerateProductListForOrder( ref strProductList);
           
            if ( !CurrentMsg.GenerateOrder(strProductList, orderFee))
            {
                return;
            }
            CurrentMsg.Window_RecieveMoney.ShowByProductListWindow();
            this.Hide();

        }
        private bool  _GenerateProductListForOrder(ref string strProductList)
        {
            long rowCount = this.dataGridView_productList.RowCount;
            long  money = 0, RetailDetailCount =0 , GoodsId = 0 ;

            CurrentMsg.ProductPricing.Clear();
            for (int index = 0; index < rowCount; ++index)
            {
                ProductPricing oProductPricing = new ProductPricing();
                if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value) )
                {
                    continue;
                }

                if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value, out money))
                {
                    MessageBox.Show("错误行 PRODUCT_MONEY：" + index);
                    return false;
                }

                if (!CommUiltl.CoverStrToInt(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value, out RetailDetailCount))
                {
                    MessageBox.Show("错误行 PRODUCT_RetailDetailCount：" + index);
                    return false;
                }
             
                strProductList += this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_CODE].Value + ":";
                strProductList += RetailDetailCount + ":";
                strProductList += money + "|";

               
                if (!CommUiltl.CoverStrToInt(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_ID].Value, out GoodsId))
                {
                    MessageBox.Show("错误行：" + index);
                    return false;
                }

                oProductPricing.Barcode = this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_CODE].Value.ToString();
                oProductPricing.GoodsId= GoodsId;
                oProductPricing.ActualPrice = money;
                oProductPricing.RetailDetailCount = RetailDetailCount;
                CurrentMsg.ProductPricing.Add(oProductPricing);
            }
            return true;
        }

        internal void EscapeShowByRecieveWindows()
        {
            this.Show();
            this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = this.dataGridView_productList.RowCount;
            _SetDataGridViewOrderFee();
        }
        internal void CloseOrderByControlWindow()
        {
            this.Show();
            _SetPayWayGrid();
            _SetDataGridViewOrderFee();
            this.dataGridView_order.CurrentCell = null;
            this.dataGridView_payWay.CurrentCell = null;
            this.dataGridView_productList.CurrentCell = null;
            _ShowPayTipsInProductListAndSaveOrderMsg();

           // System.Windows.Forms.DataGridView  this.dataGridView_order.DataSource;
            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
            _ResetAllData();
        }

        private void _ShowPayTipsInProductListAndSaveOrderMsg()
        {
            if (CurrentMsg.Order.RecieveFee >= CurrentMsg.Order.OrderFee && CurrentMsg.Order.ChangeFee == 0)
            {
                System.Windows.Forms.MessageBox.Show("付款成功,无需找零");
            }
            else if (CurrentMsg.Order.RecieveFee > CurrentMsg.Order.OrderFee && CurrentMsg.Order.ChangeFee > 0)
            {
                System.Windows.Forms.MessageBox.Show("付款成功,需找零：" + CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.Order.ChangeFee) + " 元");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("程序出现找零异常，请联系开发看");
            }
            //把下单的商品列表给缓存
        }
        private void _SetDataGridViewOrderFee()
        {
            CommUiltl.Log("_SetDataGridViewOrderFee");
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.CHANGE_FEE_ROW].Value = CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.Order.ChangeFee);
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value = CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.Order.RecieveFee) ;
        }

        private void _SetPayWayGrid()
        {
            foreach (var item in CurrentMsg.Order.listPayInfo)
            {
                int i = this.dataGridView_payWay.Rows.Add();
                if (item.payType == PayWay.PAY_TYPE_CASH)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_CASH_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.fee);
                }
                else if (item.payType == PayWay.PAY_TYPE_WEIXIN)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_WEIXIN_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.fee);
                }
                else if (item.payType == PayWay.PAY_TYPE_ZHIFUBAO)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_ZHIFUBAO_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.fee);
                }

            }
        }



        private void _SetCurrentCell()
        {
            _GoProductList();
        }
        private void _GoProductList()
        {
            this.dataGridView_order.CurrentCell = null;
            this.dataGridView_payWay.CurrentCell = null;
            this.dataGridView_payWay.ClearSelection();
            this.dataGridView_order.ClearSelection();
            //默认第一行正在编辑中
            this.dataGridView_productList.Select();

            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[this.dataGridView_productList.RowCount - 1].Cells[1];

            this.dataGridView_productList.BeginEdit(true);
        }



        private bool _ResetMoneyByRow(int rowIndex, int columnIndex)
        {
            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //价钱为空，就停止
                return false;
            }
            long amout = 0, price = 0;

            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_CODE].Value))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误条码：" + rowIndex);
                return false;
            }

            if (!CommUiltl.CoverStrToInt(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value, out amout))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误数量：" + rowIndex);
                return false;
            }

            if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value, out price))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误金额：" + rowIndex);
                return false;
            }

            long orderPrice = amout * price;
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(orderPrice);
            this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value = strOrderPrice;
            _SetOrderPrice();
            return true;
        }


        private void _SetOrderPrice()
        {
            long rowCount = this.dataGridView_productList.RowCount;
            long orderPrice = 0, money = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
                {
                    continue;
                }

                if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value, out money))
                {
                    MessageBox.Show("错误行：" + index);
                    return;
                }

                orderPrice += money;
            }
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(orderPrice);
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value = strOrderPrice;
            return;
        }

        private void GetProductInfoByBarcode(int rowIndex, int columnIndex)
        {
            DataGridViewRow currentRow = this.dataGridView_productList.Rows[rowIndex];
 
            if (CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value) && CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //空行
                //_GoOrderDataGrid();//跳到总价
                return;
            }

            string Barcode = currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value.ToString().Trim();
            if (Barcode == "")
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("当前行有问题 rowIndex:" + rowIndex + " columnIndex" + columnIndex);
                return;
            }

            ProductPricingInfoResp oProductPricingInfoResp = new ProductPricingInfoResp();
            if (!HttpUtility.GetProductByBarcode(Barcode, ref oProductPricingInfoResp))
            {
                //网络出现错误，要访问本地
                MessageBox.Show("网络出现错误" );
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                return;
            }
            if (oProductPricingInfoResp.errorCode != 0)
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("后台返回商品失败 Barcode:" + Barcode);
                return;
            }
        
            ProductPricing productInfo = oProductPricingInfoResp.data.info;
            if (CommUiltl.IsObjEmpty(productInfo.Barcode) ||
               CommUiltl.IsObjEmpty(productInfo.RetailPrice) ||
                CommUiltl.IsObjEmpty(productInfo.GoodsName)
                )
            {
                MessageBox.Show("productInfo.Barcode:" + productInfo.Barcode);
                MessageBox.Show("productInfo.RetailPrice:" + productInfo.RetailPrice);
                MessageBox.Show("productInfo.GoodsName:" + productInfo.GoodsName);
                MessageBox.Show("后台返回 有问题商品");
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                return;
            }

            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value = productInfo.Barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = productInfo.GoodsName;
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = productInfo.RetailSpecification;
            
            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(productInfo.RetailPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = RetailPrice;

            currentRow.Cells[CELL_INDEX.PRODUCT_ID].Value = productInfo.GoodsId;
            //更新订单价钱
            _SetOrderPrice();

            //将光标移动到数量里面
            _SetCurrentPointToRetailDetailCount(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount]);

        }
        bool gMoveToRetailDetailCountFlag = false;//用来控制，是否要移动光标到商品数量
        private void _SetCurrentPointToRetailDetailCount(DataGridViewCell currentCell)
        {
            CommUiltl.Log("_SetCurrentPointToRetailDetailCount row:" + currentCell.RowIndex + " Column" + currentCell.ColumnIndex);
            gMoveToRetailDetailCountFlag = true;
            gCurrentCell = currentCell;
        }

        private void _GoOrderDataGrid()
        {
            CommUiltl.Log("this.productListDataGridView CurrentCell: " + (this.dataGridView_productList.CurrentCell == null));
            //MessageBox.Show("_GoOrderDataGrid " + this.productListDataGridView.CurrentRow.Index + " index" + this.productListDataGridView.CurrentCell.ColumnIndex);
            //跳转到总价的金额编辑
            this.dataGridView_productList.CurrentRow.Selected = false;
            this.dataGridView_payWay.ClearSelection();

            this.dataGridView_order.Select();
            this.dataGridView_order.CurrentCell = this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW];
            this.dataGridView_order.BeginEdit(true);
        }

        
        private void productListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex + " Column:" + e.ColumnIndex);
        }


        private void productListDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex + " Column:" + e.ColumnIndex);
            //long RowIndex=this.productListDataGridView.CurrentCell.RowIndex;
            ////MessageBox.Show("Begin edit RowIndex:" + RowIndex);
            //if (RowIndex >= 1)
            //{
            //    if (CommUiltl.IsObjEmpty( this.productListDataGridView.Rows[RowIndex].Cells[CELL_INDEX.PRODUCT_CODE].Value)
            //        && CommUiltl.IsObjEmpty(this.productListDataGridView.Rows[RowIndex-1].Cells[CELL_INDEX.PRODUCT_CODE].Value))
            //    {
            //        _SetOrderPrice();
            //        _GoOrderDataGrid();
            //    }
            //}

        }

        private void productListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("begin");
            //MessageBox.Show("CellEndEdit  RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
            //MessageBox.Show("CellEndEdit");
            if (!gConstructEnd)
            {
                //未初始化行表的时候，这里是空的
                return;
            }
            CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
            if (this.dataGridView_productList.CurrentCell.ColumnIndex != e.ColumnIndex || this.dataGridView_productList.CurrentCell.RowIndex != e.RowIndex)
            {
                CommUiltl.Log("ColumnIndex != e.ColumnIndex");
                //非当前行
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_CODE)
            {
                CommUiltl.Log(" CELL_INDEX.PRODUCT_CODE");
                //MessageBox.Show("end edit code PRODUCT_CODE RowIndex :" + e.RowIndex + " CellIndex"+e.ColumnIndex   );
                GetProductInfoByBarcode(e.RowIndex, e.ColumnIndex);
            }
            else if (e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount || e.ColumnIndex == CELL_INDEX.PRODUCT_NORMAL_PRICE)
            {
                CommUiltl.Log("e.ColumnIndex == CELL_INDEX.PRODUCT_AMOUN ");
                if (_ResetMoneyByRow(e.RowIndex, e.ColumnIndex))//重新计算下价钱
                {
                    //下一行光标有必要移动到商品条码框
                    _GotoNextBarcode(e.RowIndex);
                }
            }
        }
        bool gMoveToNextBarcodeFlag = false;
        private void _GotoNextBarcode(int RowIndex)
        {
            CommUiltl.Log("_GotoNextBarcode RowIndex:"+ RowIndex + " this.dataGridView_productList.RowCount:" + this.dataGridView_productList.RowCount);
            CommUiltl.Log("_GotoNextBarcode PRODUCT_CODE:" + this.dataGridView_productList.Rows[RowIndex].Cells[CELL_INDEX.PRODUCT_CODE].Value);
            if (RowIndex == this.dataGridView_productList.RowCount -2 && this.dataGridView_productList.IsCurrentCellInEditMode )
            {
                gMoveToNextBarcodeFlag = true;
                gCurrentCell = this.dataGridView_productList.Rows[RowIndex + 1].Cells[CELL_INDEX.PRODUCT_CODE];
            }

        }

        private void productListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("begin ");
            if (this.dataGridView_productList.CurrentCell != null)
            {
                CommUiltl.Log("productListDataGridView_SelectionChanged row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
                return;
            }
            if (!gConstructEnd)
            {
                CommUiltl.Log("gConstructEnd ");
                //未初始化行表的时候，这里是空的
                return;
            }
            if (gResetRow)
            {
                CommUiltl.Log("gResetRow:" + gResetRow);
                gResetRow = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
                return;
            }
            if (gMoveToRetailDetailCountFlag)
            {
                CommUiltl.Log("gMoveToRetailDetailCountFlag:" + gMoveToRetailDetailCountFlag);
                gMoveToRetailDetailCountFlag = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
            }
            if (gMoveToNextBarcodeFlag)
            {
                CommUiltl.Log("gMoveToNextBarcodeFlag:" + gMoveToNextBarcodeFlag);
                gMoveToNextBarcodeFlag = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
            }
            _GoCurrentBarcodeIfNeed();

            CommUiltl.Log("end ");
        }

        private void productListDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:" +e.RowIndex );
            this.dataGridView_productList.Rows[e.RowIndex].Cells[CELL_INDEX.INDEX].Value = e.RowIndex + 1;
        }

        private void productListDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex );
            this.dataGridView_productList.Rows[e.RowIndex].Cells[CELL_INDEX.INDEX].Value = e.RowIndex+1;
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        //MessageBox.Show("Keys.Enter: CurrentCell.RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
                        if (this.dataGridView_productList.IsCurrentCellInEditMode)
                        {
                            CommUiltl.Log(" IsCurrentCellInEditMode ");
                            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value))
                            {
                                CommUiltl.Log(" CELL_INDEX.PRODUCT_CODE empty ");
                                //MessageBox.Show("Keys.Enter Value empty  RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
                                if (this.dataGridView_productList.CurrentRow.IsNewRow)
                                {
                                    //删除当前行
                                    //this.productListDataGridView.Rows.Remove(this.productListDataGridView.CurrentRow);
                                  
                                    _SetOrderPrice();
                                    //_GoOrderDataGrid();
                                    _Windows_ShowRecieveMoeny();
                                    
                                }
                                return base.ProcessCmdKey(ref msg, keyData);
                            }

                        }
                    }
                    break;
                    case System.Windows.Forms.Keys.Tab:
                    {
                        //tabl的操作被禁止
                        return true;
                    }
                case System.Windows.Forms.Keys.Delete:
                    {
                        CommUiltl.Log("Keys.Delete");
                        //删除操作，把当前行给删除
                        if (this.dataGridView_productList.CurrentCell != null )
                        {
                            CommUiltl.Log("Keys.Delete CurrentCell");
                            if ( !this.dataGridView_productList.CurrentRow.IsNewRow)
                            {
                                CommUiltl.Log("Keys.Delete !IsNewRow");
                                if (this.dataGridView_productList.CurrentRow.Index >= 0)
                                {
                                    this.dataGridView_productList.Rows.RemoveAt(this.dataGridView_productList.CurrentRow.Index);
                                    _SetOrderPrice();
                                }

                            }
                        }
                        return true;
                    }
                case System.Windows.Forms.Keys.F12:
                    {
      
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private  DataGridViewCell gCurrentCell;
        private bool gResetRow = false;

        private void orderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            CommUiltl.Log("begin");
            long orderFee = 0, recieveFee = 0, changeFee = 0;
            if (! CommUiltl.ConverStrYuanToUnion(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value);
                return;
            }
            if (! CommUiltl.ConverStrYuanToUnion(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value, out recieveFee))
            {
                MessageBox.Show("实收错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value);
                return;
            }

            changeFee = recieveFee - orderFee;
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.CHANGE_FEE_ROW].Value = CommUiltl.CoverMoneyUnionToStrYuan(changeFee);
            if (changeFee < 0)
            {
                _SetPointToResetCurrentCell(dataGridView_order.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                MessageBox.Show("实收价钱小于总价" );
                return;
            }
            MessageBox.Show("生成订单成功");
            _ResetAllData();
        }
        private void _ResetAllData()
        {
            this.dataGridView_productList.Rows.Clear();
            _InitOrderMsg();
            this.dataGridView_order.ClearSelection();
            this.dataGridView_order.CurrentCell = null;
            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
          
        }

        private void _GoCurrentBarcodeIfNeed()
        {
            if (this.dataGridView_productList.ColumnCount < CELL_INDEX.PRODUCT_MONEY +1)
            {
                CommUiltl.Log("ColumnCount < PRODUCT_MONEY");
                //初始化阶段
                return;
            }
            if (this.dataGridView_productList.IsCurrentCellInEditMode
                &&!CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value)
                &&CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                CommUiltl.Log("go CurrentCell ");
                //第一个
                this.dataGridView_productList.CurrentCell = this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_CODE];
            }
        }



        void orderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("begin");
            if (gResetRow)
            {
                CommUiltl.Log("gResetRow");
                gResetRow = false;
                this.dataGridView_order.CurrentCell = gCurrentCell;
            }
        }
     
        private void _SetPointToResetCurrentCell(DataGridViewCell currentCell)
        {
            CommUiltl.Log("row:"+ currentCell.RowIndex +" Column"+ currentCell.ColumnIndex);
            gResetRow = true;
            gCurrentCell = currentCell;
        }

        void orderDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridView_order.SelectionChanged += new EventHandler(orderDataGridView_SelectionChanged);
        }

    }

    public static class CELL_INDEX
    {
        public static int INDEX = 0;
        public static int PRODUCT_CODE = 1;
        public static int PRODUCT_NAME = 2;
        public static int PRODUCT_SPECIFICATION = 3;
        public static int PRODUCT_NORMAL_PRICE = 4;
        public static int PRODUCT_RetailDetailCount = 5;
        public static int PRODUCT_MONEY = 6;
        public static int PRODUCT_ID = 7;

        public static int ORDER_COLUMN = 1;
        public static int RECIEVE_FEE_ROW = 0;
        public static int ORDER_FEE_ROW = 1;
        public static int CHANGE_FEE_ROW = 2;
    }

}
