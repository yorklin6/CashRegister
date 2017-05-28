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
using CashRegisterApplication.window.Setting;

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
            CenterContral.Init();
            SetTimerTask();
            CenterContral.Window_ProductList = this;//全局窗口
            CenterContral.Clean();
            SetLocalSaveDataNumber();
            System.Windows.Forms.Clipboard.SetText("9556247516480");
            this.label_defaultUser.Text = HttpUtility.DefaultUser;
            this.label_postId.Text = CenterContral.iPostId.ToString();
        }
        public void SetMemberInfo()
        {
            CommUiltl.Log("this.label_member_account.Text:"+ this.label_member_account.Text);
            //挂单数量
            this.label_member_account.Text = CenterContral.oStockOutDTO.oMember.memberAccount;
            this.label_member_point.Text = CenterContral.oStockOutDTO.oMember.point.ToString();
            this.label_member_balance.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.oMember.balance).ToString();
        }
        public void SetLocalSaveDataNumber()
        {
            //挂单数量
            this.label_local_save_stock_number.Text = CenterContral.oLocalSaveStock.listStock.Count.ToString();
        }
        public void  SetSerialNumber(string strSerialNumber)
        {
            //设置流水号
            this.label_serial_number.Text = strSerialNumber;
        }
        
        public void SetStoreName(string strStoreName)
        {
            //设置门店
            this.Text = "收银台-" + strStoreName;
        }

        //折扣信息
        public void UpdateDiscount()
        {
            //折扣额度
            this.label_discount_amount.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.discountAmount);
            //折扣率
            this.label_discount_rate.Text = CenterContral.oStockOutDTO.Base.discountRate.ToString();
        }

        private void SetTimerTask()
        {
            CommUiltl.Log("SetTimerTask ");
            Timer MyTimer = new Timer();
            MyTimer.Interval = (1 * 60 * 1000); // 1 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            CommUiltl.Log("SetTimerTask ");
            MyTimerTask.Run();
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
            _InitOrderMsg();
            this.ColumnIndex.ReadOnly = true;
            this.ColumnGoodsName.ReadOnly = true;
            this.ColumnRetailSpecification.ReadOnly = true;
            this.ColumnRemark.ReadOnly = true;
            this.ColumnMoney.ReadOnly = true;
            gConstructEnd = true;
          
        }
      
        private void _InitOrderMsg()
        {
            this.label_orderFee.Text = "0.00";
            this.label_receiveFee.Text = "0.00";
            this.label_changeFee.Text = "0.00";
        }
        private void _GeneraterOrder()
        {
            //跳到收钱窗口
            string strProductList = "";
            _GenerateProductListForOrder(ref strProductList);
            if (!CenterContral.GenerateOrder(strProductList))
            {
                return;
            }
        }
        /*
       * 弹出框，展示实收多少钱
       */
        private void _Windows_ShowRecieveMoeny()
        {
            _SetOrderPrice();
            _GeneraterOrder();
            CenterContral.Window_RecieveMoney.ShowByProductListWindow();
            this.Hide();
        }

     

        private bool  _GenerateProductListForOrder(ref string strProductList)
        {
            long rowCount = this.dataGridView_productList.RowCount;
            long  subtotal = 0, RetailDetailCount =0 ,price =0 ;

            for (int index = 0; index < rowCount; ++index)
            {
                if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value) )
                {
                    continue;
                }

                if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value, out subtotal))
                {
                    MessageBox.Show("错误行 PRODUCT_MONEY：" + index);
                    return false;
                }

                if (!CommUiltl.CoverStrToLong(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value, out RetailDetailCount))
                {
                    MessageBox.Show("错误行 PRODUCT_RetailDetailCount：" + index);
                    return false;
                }

                if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value, out price))
                {
                    MessageBox.Show("错误行 PRODUCT_NORMAL_PRICE：" + index);
                    return false;
                }
                strProductList += this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_CODE].Value + ":";
                strProductList += RetailDetailCount + ":";
                strProductList += subtotal + "|";
                CommUiltl.Log(" Main.oStockOutDTO.details.Count:" + CenterContral.oStockOutDTO.details.Count);
                CommUiltl.Log(" index:" + index);
                CenterContral.oStockOutDTO.details[index].actualCount = RetailDetailCount;
                CenterContral.oStockOutDTO.details[index].barcode = this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_CODE].Value.ToString();
                CenterContral.oStockOutDTO.details[index].unitPrice = price;
                CenterContral.oStockOutDTO.details[index].subtotal = subtotal;
            }
            return true;
        }
        internal void CallShowBySettingWindows()
        {
            this.Show();
            this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = this.dataGridView_productList.RowCount;
            _SetDataGridViewOrderFee();
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
         
            this.dataGridView_payWay.CurrentCell = null;
            this.dataGridView_productList.CurrentCell = null;
            _ShowPayTipsInProductListAndSaveOrderMsg();

            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
            _ResetAllData();
        }

        private void _ShowPayTipsInProductListAndSaveOrderMsg()
        {
            if (CenterContral.oStockOutDTO.Base.RecieveFee >= CenterContral.oStockOutDTO.Base.orderAmount && CenterContral.oStockOutDTO.Base.ChangeFee == 0)
            {
                System.Windows.Forms.MessageBox.Show("付款成功,无需找零");
            }
            else if (CenterContral.oStockOutDTO.Base.RecieveFee > CenterContral.oStockOutDTO.Base.orderAmount && CenterContral.oStockOutDTO.Base.ChangeFee > 0)
            {
                System.Windows.Forms.MessageBox.Show("付款成功,需找零：" + CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.ChangeFee) + " 元");
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
            this.label_orderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.RecieveFee);
            this.label_changeFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.ChangeFee);
        }

        private void _SetPayWayGrid()
        {
            foreach (var item in CenterContral.oStockOutDTO.checkouts)
            {
                int i = this.dataGridView_payWay.Rows.Add();
                if (item.payType == PayWay.PAY_TYPE_CASH)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_CASH_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == PayWay.PAY_TYPE_WEIXIN)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_WEIXIN_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == PayWay.PAY_TYPE_ZHIFUBAO)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_ZHIFUBAO_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
            }
        }



        private void _SetCurrentCell()
        {
            _GoProductList();
        }
        private void _GoProductList()
        {
            this.dataGridView_payWay.CurrentCell = null;
            this.dataGridView_payWay.ClearSelection();
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

            if (!CommUiltl.CoverStrToLong(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value, out amout))
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
            long orderPrice = 0, subtotal = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
                {
                    continue;
                }

                if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value, out subtotal))
                {
                    MessageBox.Show("错误行：" + index);
                    return;
                }

                orderPrice += subtotal;
            }
            CenterContral.updateOrderAmount(orderPrice);
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount);
            this.label_orderFee.Text = strOrderPrice;
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

            string barcode = currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value.ToString().Trim();
            if (barcode == "")
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("当前行有问题 rowIndex:" + rowIndex + " columnIndex" + columnIndex);
                return;
            }

            ProductPricing productInfo = CenterContral.GetGoodsByProductCode(barcode);
            if (productInfo == null)
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                return;
            }

            if (CommUiltl.IsObjEmpty(productInfo.barcode) ||
               CommUiltl.IsObjEmpty(productInfo.retailPrice) ||
                CommUiltl.IsObjEmpty(productInfo.goodsName)
                )
            {
                MessageBox.Show("productInfo.barcode:" + productInfo.barcode);
                MessageBox.Show("productInfo.retailPrice:" + productInfo.retailPrice);
                MessageBox.Show("productInfo.GoodsName:" + productInfo.goodsName);
                MessageBox.Show("后台返回 有问题商品");
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                return;
            }
            StockOutDetail detail = new StockOutDetail();
            _ProductTostockDetail(productInfo,ref detail);
            //设置行里面商品信息
            _SetRowsByStockOutDetail(currentRow,detail);
            CenterContral.oStockOutDTO.details.Add(detail);
            CommUiltl.Log(" add Main.oStockOutDTO.details.Count:" + CenterContral.oStockOutDTO.details.Count);
            //更新订单价钱
            _SetOrderPrice();
            //将光标移动到数量里面
            _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
        }

        private void _SetRowsByStockOutDetail(DataGridViewRow currentRow, StockOutDetail detail)
        {
            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value = detail.barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:"+ detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.goodsShowSpecification;

            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(detail.unitPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = RetailPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_REMARK].Value = detail.remark;
            currentRow.Cells[CELL_INDEX.PRODUCT_JSON].Value = JsonConvert.SerializeObject(detail);
        }

        private void _ProductTostockDetail(ProductPricing productInfo, ref StockOutDetail detail)
        {
            
            detail.barcode= productInfo.barcode;
            detail.goodsName = productInfo.goodsName;
            detail.unitPrice = (productInfo.retailPrice);
            detail.remark = productInfo.remark;
            detail.specification = productInfo.specification;
            detail.categoryId = productInfo.categoryId;
            detail.unit = productInfo.baseUnit;
   
            detail.goodsShowSpecification = productInfo.baseUnit + "/" + productInfo.bigUnit + "/" + productInfo.specification;
            CommUiltl.Log("_ProductTostockDetail   detail.goodsShowSpecification :" + detail.goodsShowSpecification);
            detail.cloudProductPricing = productInfo;
            detail.detailDataJson = JsonConvert.SerializeObject(productInfo);

        }

        
        private void productListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex + " Column:" + e.ColumnIndex);
        }


        private void productListDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CommUiltl.Log("row:" + e.RowIndex + " Column:" + e.ColumnIndex);


        }

        private void productListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("begin");

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
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount)
            {
                //将光标移动到价钱
                CommUiltl.Log(" e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount and  _ResetMoneyByRow and _SetCurrentPointToRetailDetailCount  ");
                _ResetMoneyByRow(e.RowIndex , e.ColumnIndex);
                _SetCurrentPointToRetailDetailCount(e.RowIndex, CELL_INDEX.PRODUCT_NORMAL_PRICE);
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_NORMAL_PRICE && !this.dataGridView_productList.CurrentRow.IsNewRow)
            {
                CommUiltl.Log("e.ColumnIndex == CELL_INDEX.PRODUCT_NORMAL_PRICE _ResetMoneyByRow and  _GotoNextBarcode");
                //将光标移动到下一行条码
                _ResetMoneyByRow(e.RowIndex, e.ColumnIndex);
                _GotoNextBarcode(e.RowIndex);
                return;
            }

        }
        bool gMoveToRetailDetailCountFlag = false;//用来控制，是否要移动光标到商品数量
        private void _SetCurrentPointToRetailDetailCount(int rowIndex, int columnIndex)
        {
            CommUiltl.Log("_GotoNextBarcode RowIndex:" + rowIndex + " this.dataGridView_productList.RowCount:" + this.dataGridView_productList.RowCount);
            if (rowIndex == this.dataGridView_productList.RowCount - 2)
            {
                CommUiltl.Log("_SetCurrentPointToRetailDetailCount row:" + rowIndex + " Column" + columnIndex);
                gMoveToRetailDetailCountFlag = true;
                gCurrentCell = this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex];
                return;
            }
        }

        bool gMoveToNextBarcodeFlag = false;
        private void _GotoNextBarcode(int rowIndex)
        {
            CommUiltl.Log("_GotoNextBarcode RowIndex:"+ rowIndex + " this.dataGridView_productList.RowCount:" + this.dataGridView_productList.RowCount);
            CommUiltl.Log("_GotoNextBarcode PRODUCT_CODE:" + this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_CODE].Value);
            if (rowIndex == this.dataGridView_productList.RowCount -2 )
            {
                CommUiltl.Log("RowIndex == this.dataGridView_productList.RowCount -2");
                gMoveToNextBarcodeFlag = true;
                gCurrentCell = this.dataGridView_productList.Rows[rowIndex + 1].Cells[CELL_INDEX.PRODUCT_CODE];
                return ;
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
            if (gCurrentCell ==null )
            {
                CommUiltl.Log("gCurrentCell== null ");
                return;
            }
            CommUiltl.Log("gCurrentCell:" + gCurrentCell);
            if (gCurrentCell.RowIndex<0)
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
            if (gMoveToNextBarcodeFlag)
            {
                CommUiltl.Log("gMoveToNextBarcodeFlag:" + gMoveToNextBarcodeFlag);
                gMoveToNextBarcodeFlag = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
                this.dataGridView_productList.CurrentCell.Selected = true;
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
            CommUiltl.Log("keyData:"+ keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        //MessageBox.Show("Keys.Enter: CurrentCell.RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
                        if (this.dataGridView_productList.IsCurrentCellInEditMode)
                        {
                            CommUiltl.Log(" IsCurrentCellInEditMode ");
                            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value)&& this.dataGridView_productList.CurrentRow.IsNewRow)
                            {
                                //唤起收银界面
                                CommUiltl.Log(" CELL_INDEX.PRODUCT_CODE empty ");
                                this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = "";
                                _Windows_ShowRecieveMoeny();
                                return true;
                                //  return base.ProcessCmdKey(ref msg, keyData);
                            }
                            return base.ProcessCmdKey(ref msg, keyData);
                        }
                    }
                    break;
                case System.Windows.Forms.Keys.Home:
                    {
                        _Windows_ShowRecieveMoeny();
                        return true;
                    }
                case System.Windows.Forms.Keys.F9:
                    {
                        CenterContral.ShowWindows_RechargeMoneyForMember();
                        this.Hide();
                        return true;
                    }
                case System.Windows.Forms.Keys.Tab:
                    {
                        //tabl的操作被禁止
                        return true;
                    }
                // case System.Windows.Forms.Keys.OemMinus:
                //case System.Windows.Forms.Keys.Subtract:
                case System.Windows.Forms.Keys.Delete:
                    {
                        CommUiltl.Log("Keys.Delete");
                        //删除操作，把当前行给删除
                        if (this.dataGridView_productList.CurrentCell != null && this.dataGridView_productList.CurrentCell.RowIndex
                             >-1 )
                        {
                            CommUiltl.Log("Keys.Delete CurrentCell");
                            if ( !this.dataGridView_productList.CurrentRow.IsNewRow )
                            {
                                CommUiltl.Log("Keys.Delete !IsNewRow this.dataGridView_productList.CurrentRow.Index:" + this.dataGridView_productList.CurrentRow.Index);
                                if (this.dataGridView_productList.CurrentRow.Index >= 0)
                                {
                                    this.dataGridView_productList.Rows.RemoveAt(this.dataGridView_productList.CurrentRow.Index);
                                    CenterContral.oStockOutDTO.details.RemoveAt(this.dataGridView_productList.CurrentRow.Index);
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
                case System.Windows.Forms.Keys.F4:
                    {
                        //交易挂单
                        SaveStock();
                        //  return base.ProcessCmdKey(ref msg, keyData);
                        return true;
                    }
                case System.Windows.Forms.Keys.F5:
                    {
                        //挂单恢复
                        RecoverStock();
                        return true;
                    }
                case System.Windows.Forms.Keys.End:
                    {
                        SettingDefaultMsgWindow oSettingDefaultMsgWindow = new SettingDefaultMsgWindow();
                        oSettingDefaultMsgWindow.Show();
                        this.Hide();
                        return true;
                    }
                case System.Windows.Forms.Keys.Insert:
                    {
                        //挂单恢复
                        Discount();
                        return true;
                    }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /**********************************整单打折******************************************/
        private void Discount()
        {
            CenterContral.Window_DiscountWindows.ShowWithDiscountMsg();
        }
        /**********************************挂单**********************************************/
        private void SaveStock()
        {
            string showTips = "是否要挂单";
            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "挂单操作",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            _SetOrderPrice();
            string strProductList = "";
            _GenerateProductListForOrder(ref strProductList);
            if (!CenterContral.SaveStock(strProductList))
            {
                return;
            }
            CommUiltl.Log("_ResetAllData");
           _ResetAllData();
        }

        private void RecoverStock()
        {
            CommUiltl.Log("Main.oSaveSotckOut.listStock.Count: "+ CenterContral.oLocalSaveStock.listStock.Count);
            if (CenterContral.oLocalSaveStock.listStock.Count==0)
            {
                MessageBox.Show("无挂单", "挂单操作");
                return;
            }

            string showTips = "本单将会挂起来，恢复上一个挂单";
            if (ProductListIsEmpty(CenterContral.oStockOutDTO))
            {
                showTips = "是否要恢复上一个订单";
            }
          
            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "挂单操作",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            //当前订单保存订单
            _SetOrderPrice();
            string strProductList = "";
            _GenerateProductListForOrder(ref strProductList);

            if ( !ProductListIsEmpty(CenterContral.oStockOutDTO))
            {
                CommUiltl.Log("ProductListIsEmpty " );
                //如果不是空的单据，那么就要保存
                if (!CenterContral.SaveStock(strProductList))
                {
                    return;
                }
            }
            _ResetAllData();
            CenterContral.GetSaveOrderToCurrentMsg();
            SetProductListWindowByStockOut(CenterContral.oStockOutDTO);

        }

        private bool ProductListIsEmpty(StockOutDTO oStockOutDTO)
        {
            return CenterContral.oStockOutDTO.details.Count ==0 ;
        }

        public void SetProductListWindowByStockOut(StockOutDTO oStockOutDTO)
        {
            //列出商品
            int rowIndex;
            for (int i=0;i< oStockOutDTO.details.Count;++i)
            {
                rowIndex=this.dataGridView_productList.Rows.Add();
                CommUiltl.Log("rowIndex "+ rowIndex);
                CommUiltl.Log("i " + i);
                CommUiltl.Log("oStockOutDTO.details[i] " + oStockOutDTO.details[i]);
                _SetRowsByStockOutDetail(this.dataGridView_productList.Rows[rowIndex], oStockOutDTO.details[i]);
            }
            //列出订单总价
            _SetOrderGridView();
            //列出支付信息
            _SetPayWayDataGridView();
        }

        private void _SetPayWayDataGridView()
        {
            foreach (var item in CenterContral.oStockOutDTO.checkouts)
            {
                int i = this.dataGridView_payWay.Rows.Add();
                if (item.payType == PayWay.PAY_TYPE_CASH)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_CASH_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == PayWay.PAY_TYPE_WEIXIN)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_WEIXIN_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == PayWay.PAY_TYPE_ZHIFUBAO)
                {
                    this.dataGridView_payWay.Rows[i].Cells[0].Value = PayWay.PAY_TYPE_ZHIFUBAO_DESC;
                    this.dataGridView_payWay.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
            }
        }
        private void _SetOrderGridView()
        {
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount);
            this.label_orderFee.Text = strOrderPrice;
            string strChangeFee = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.ChangeFee);
            this.label_changeFee.Text = strChangeFee;
            string strRecieveFee = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.RecieveFee);
            this.label_receiveFee.Text = strRecieveFee;
        }

        private  DataGridViewCell gCurrentCell=null;
        private bool gResetRow = false;

        private void orderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            CommUiltl.Log("begin");
            long orderFee = 0, recieveFee = 0, changeFee = 0;
            if (! CommUiltl.ConverStrYuanToUnion(this.label_orderFee .Text, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.label_orderFee.Text );
                return;
            }
            if (! CommUiltl.ConverStrYuanToUnion(this.label_receiveFee.Text, out recieveFee))
            {
                MessageBox.Show("实收错误:" + this.label_receiveFee.Text);
                return;
            }

            changeFee = recieveFee - orderFee;
            this.label_changeFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(changeFee);
            if (changeFee < 0)
            {
                MessageBox.Show("实收价钱小于总价" );
                return;
            }
            MessageBox.Show("生成订单成功");
            _ResetAllData();
        }
        private void _ResetAllData()
        {
            gConstructEnd = false;
            //使用clear事件，会触发行修改事件

            this.dataGridView_productList.Rows.Clear();
            this.dataGridView_payWay.Rows.Clear();
            CenterContral.Clean();
            _InitOrderMsg();
            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
            gConstructEnd = true;

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
        }

        private void ProductListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_payWay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_connectStatus_Click(object sender, EventArgs e)
        {

        }

        private void label_defaultUser_Click(object sender, EventArgs e)
        {

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
