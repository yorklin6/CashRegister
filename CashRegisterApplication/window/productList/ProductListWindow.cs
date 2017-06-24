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
using System.Drawing.Printing;
using System.Diagnostics;

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
      
            CenterContral.Clean();

            
                System.Windows.Forms.Clipboard.SetText("8410376009392");
            //System.Windows.Forms.Clipboard.SetText("2100507005701");
            // System.Windows.Forms.Clipboard.SetText("9556247516480");
            //System.Windows.Forms.Clipboard.SetText("倍乐");
            this.label_defaultUser.Text = CenterContral.DefaultUserName;
            this.label_postId.Text = CenterContral.iPostId.ToString();
        }

        public void CallShow()
        {
            this.Show();
        }

        public void SetMemberInfo()
        {
            CommUiltl.Log("this.label_member_account.Text:"+ this.label_member_account.Text);
            this.label_member_account.Text = CenterContral.oStockOutDTO.oMember.memberAccount;
            this.label_member_balance.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.oMember.balance).ToString();
            this.label_member_point.Text = CenterContral.oStockOutDTO.oMember.point.ToString();
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
            this.label_total_product_count.Text = "0";
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
            _UpdateStockBaseMsg();
            _GeneraterOrder();
            CenterContral.Window_RecieveMoney.ShowByProductListWindow();
            //this.Hide();
        }

     

        private bool  _GenerateProductListForOrder(ref string strProductList)
        {
            int rowCount = CenterContral.oStockOutDTO.details.Count;
            for (int index = 0; index < rowCount; ++index)
            {
                var oStockOutDetail= CenterContral.oStockOutDTO.details[index];
                strProductList += oStockOutDetail.goodsId + ":";
                strProductList += oStockOutDetail.actualCount + ":";
                strProductList += oStockOutDetail.subtotal + "|";
            }
            return true;
        }
        internal void CallShowBySettingWindows()
        {
            this.Show();
            this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = this.dataGridView_productList.RowCount;
            UpdateProductListWindowsMoneyLabel();
        }
        internal void EscapeShowByRecieveWindows()
        {
            this.Show();
            this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = this.dataGridView_productList.RowCount;
            _SetCheckoutGrid();
            UpdateProductListWindowsMoneyLabel();
        }
        internal void CloseOrderByControlWindow()
        {

            this.Show();
            
            _SetCheckoutGrid();
            UpdateProductListWindowsMoneyLabel();
         
            this.dataGridView_checkout.CurrentCell = null;
            this.dataGridView_productList.CurrentCell = null;
            _ShowPayTipsInProductListAndSaveOrderMsg();

            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[0].Cells[1];
            this.dataGridView_productList.BeginEdit(true);
            //打印本单
          
            _ResetAllData();
        }

       

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

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
        public void UpdateProductListWindowsMoneyLabel()
        {
            CommUiltl.Log("_SetDataGridViewOrderFee");
            this.label_orderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount);
            this.label_receiveFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.RecieveFee);
            this.label_changeFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.ChangeFee);
            this.label_total_product_count.Text = CenterContral.oStockOutDTO.Base.totalProductCount.ToString();
        }

        private void _SetCheckoutGrid()
        {
            this.dataGridView_checkout.Rows.Clear();
            foreach (var item in CenterContral.oStockOutDTO.checkouts)
            {
                int i = this.dataGridView_checkout.Rows.Add();
                this.dataGridView_checkout.Rows[i].Cells[0].Value = item.payTypeDesc;
                this.dataGridView_checkout.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
            }
            this.dataGridView_checkout.CurrentCell = null;
            this.dataGridView_checkout.ClearSelection();
        }



        private void _SetCurrentCell()
        {
            _GoProductList();
        }
        private void _GoProductList()
        {
            this.dataGridView_checkout.CurrentCell = null;
            this.dataGridView_checkout.ClearSelection();
            //默认最后一行正在编辑中
            this.dataGridView_productList.Focus();
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
            long actualCount = 0, unitPrice = 0;

            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.GOODS_BARCODE].Value))
            {
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.GOODS_BARCODE);
                MessageBox.Show("错误条码" );
                return false;
            }
            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value))
            {
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
                MessageBox.Show("数量错误,不能为空");
                return false;
            }
            string strRetailCount = this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value.ToString();
            if (!_CheckRetailAccount(CenterContral.oStockOutDTO.details[rowIndex],strRetailCount,ref actualCount))
            {
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
                //_SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_RetailDetailCount]);
                MessageBox.Show("错误数量" );
                return false;
            }
          
            if (!CommUiltl.ConverStrYuanToUnion(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value, out unitPrice))
            {
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_NORMAL_PRICE);
                MessageBox.Show("错误金额" );
                return false;
            }

            CommUiltl.Log("unitPrice:"+ unitPrice);
            _UpdateStockOutDtoDetailMoney(CenterContral.oStockOutDTO.details[rowIndex], strRetailCount, actualCount,unitPrice);
            this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.details[rowIndex].subtotal);
            _UpdateStockBaseMsg();
            return true;
        }

        private void _UpdateStockOutDtoDetailMoney(StockOutDetail stockOutDetail,string strRetailCount, long actualCount, long unitPrice)
        {
            stockOutDetail.unitPrice = unitPrice;
            if (stockOutDetail.isBarCodeMoneyGoods == CenterContral.IS_BARCODE_MOENY_GOODS)
            {
                //计重类数量
                long barcodeCount = 0;
                CommUiltl.ConverStrYuanToUnion(strRetailCount, out barcodeCount);
                stockOutDetail.barcodeCount = barcodeCount;
                stockOutDetail.actualCount = stockOutDetail.actualCount;//实际数量不变
                stockOutDetail.subtotal = CommUiltl.CaculateBarCodeTotalMoney(stockOutDetail.barcodeCount, stockOutDetail.unitPrice);
                return;
            }

            stockOutDetail.actualCount = actualCount;
            stockOutDetail.subtotal = stockOutDetail.actualCount* stockOutDetail.unitPrice;
        }

        private bool _CheckRetailAccount(StockOutDetail oStockOutDetail,string strRetailCount,ref long actualCount )
        {
            if (oStockOutDetail.isBarCodeMoneyGoods == CenterContral.IS_BARCODE_MOENY_GOODS)
            {
                //计重类数量   
                long barcodeCount = 0;
                return CommUiltl.ConverStrYuanToUnion(strRetailCount, out barcodeCount);

            }
            return CommUiltl.CoverStrToLong(strRetailCount, out actualCount);
        }

        private void _UpdateStockBaseMsg()
        {
            long rowCount = CenterContral.oStockOutDTO.details.Count;
            long orderPrice = 0, subtotalCount = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                subtotalCount += CenterContral.oStockOutDTO.details[index].actualCount;
                orderPrice += CenterContral.oStockOutDTO.details[index].subtotal;
            }
            CenterContral.updateOrderAmount(orderPrice);
            string strOrderPrice = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount);
       
            CenterContral.oStockOutDTO.Base.totalProductCount = subtotalCount;
            UpdateProductListWindowsMoneyLabel();
            return;
        }

        private void GetProductInfoByBarcode(int rowIndex, int columnIndex)
        {
            DataGridViewRow currentRow = this.dataGridView_productList.Rows[rowIndex];
            CommUiltl.Log("GetProductInfoByBarcode currentRow:"+ currentRow.Index);
            if (CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value) 
                && CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //条形码为空
                return;
            }
            if ( !CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value) )
            {
                //已经有商品
                return;
            }

            string strKeyWord = currentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value.ToString().Trim();
            if (strKeyWord == "")
            {
                _SetPointToResetCurrentCell(currentRow.Cells[columnIndex]);
                MessageBox.Show("当前行有问题 rowIndex:" + rowIndex + " columnIndex" + columnIndex);
                return;
            }
            //根据-商品货号-取出商品（商品货号：可能是条码，可能是商品号）
            ProductPricingInfoResp oStockOutDetailInfoResp = new ProductPricingInfoResp();
            if (!CenterContral.GetGoodsByGoodsKey(strKeyWord ,ref oStockOutDetailInfoResp))
            {
                _SetPointToResetCurrentCell(currentRow.Cells[columnIndex]);
                return;
            }
            if (oStockOutDetailInfoResp.data.list.Count == 0)
            {
                MessageBox.Show("未找到商品资料");
                _SetPointToResetCurrentCell(currentRow.Cells[columnIndex]);
                return;
            }
            //商品个数大于1
            if (oStockOutDetailInfoResp.data.list.Count >1 )
            {
                _SetPointToResetCurrentCell(currentRow.Cells[columnIndex]);
                //唤起界面，对商品进行筛选
                _CallWindowsSelectGoood(oStockOutDetailInfoResp.data.list);
                gSelectGoodsRow = currentRow;
                return;
            }
            ProductPricing  productInfo=oStockOutDetailInfoResp.data.list[0];
            productInfo.postKeyWord = strKeyWord;
            //单个商品
            _AddProducntInfoToDataGridViewProductList(currentRow,productInfo);
            //将光标移动到数量里面
            _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.PRODUCT_RetailDetailCount);
        }

        private void _CallWindowsSelectGoood(List<ProductPricing> list)
        {
            CenterContral.CallWindowsSelectGooodByProudctList( list);
        }
        DataGridViewRow gSelectGoodsRow;
        public void CallBackBySelectGoodWindow(ProductPricing productInfo)
        {
            //选中商品后回调这里
            this.Show();
            DataGridViewRow currentRow = this.dataGridView_productList.CurrentRow;
            if (!CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                CommUiltl.Log("CallBackBySelectGoodWindow CommUiltl.IsObjEmpty currentRow.Index:" + currentRow.Index);
                //已经有商品
                return;
            }
            productInfo.postKeyWord = currentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value.ToString().Trim();
            _AddProducntInfoToDataGridViewProductList(currentRow,productInfo);
            //将光标移动到数量里面
            this.dataGridView_productList.CurrentCell = currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount];
            this.dataGridView_productList.BeginEdit(true);
        }
        public void EecBySelectGoodWindow()
        {
            //选中商品后回调这里
            this.Show();
            DataGridViewRow currentRow = this.dataGridView_productList.CurrentRow;
            //将光标移动到数量里面
            this.dataGridView_productList.CurrentCell = currentRow.Cells[CELL_INDEX.GOODS_BARCODE];
            this.dataGridView_productList.BeginEdit(true);
        }
        public void _AddProducntInfoToDataGridViewProductList(DataGridViewRow currentRow, ProductPricing productInfo)
        {
            //单个商品
            StockOutDetail detail = new StockOutDetail();
            CenterContral.ProductTostockDetail(productInfo, ref detail);
            //设置行里面商品信息
            SetRowsByStockOutDetail(currentRow, detail);
            CenterContral.oStockOutDTO.details.Add(detail);
            CommUiltl.Log(" add Main.oStockOutDTO.details.Count:" + CenterContral.oStockOutDTO.details.Count);
            //更新订单价钱
            _UpdateStockBaseMsg();
        }
        private void SetRowsByStockOutDetail(DataGridViewRow currentRow, StockOutDetail detail)
        {
            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.GOODS_BARCODE].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
           currentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value = detail.barcode;
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = detail.goodsName;
            CommUiltl.Log("detail.goodsShowSpecification:"+ detail.goodsShowSpecification);
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = detail.goodsShowSpecification;

            string RetailPrice = CommUiltl.CoverMoneyUnionToStrYuan(detail.unitPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = RetailPrice;

            currentRow.Cells[CELL_INDEX.PRODUCT_REMARK].Value = detail.remark;
            //currentRow.Cells[CELL_INDEX.PRODUCT_JSON].Value = JsonConvert.SerializeObject(detail);
            //总价和数量
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value =   CommUiltl.CoverMoneyUnionToStrYuan(detail.subtotal);
            currentRow.Cells[CELL_INDEX.PRODUCT_RetailDetailCount].Value = CenterContral.GetGoodsCount(detail);
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
            CommUiltl.Log("begin e.RowIndex："+ e.RowIndex + " ColumnIndex" + e.ColumnIndex);

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
            if (e.ColumnIndex == CELL_INDEX.GOODS_BARCODE)
            {
                CommUiltl.Log(" CELL_INDEX.PRODUCT_CODE");
                //MessageBox.Show("end edit code PRODUCT_CODE RowIndex :" + e.RowIndex + " CellIndex"+e.ColumnIndex   );
                GetProductInfoByBarcode(e.RowIndex, e.ColumnIndex);
                return;
            }
            if (this.dataGridView_productList.CurrentRow.IsNewRow)
            {
                //最后一行是新行不做处理，因为最后一行是新行，说明还没有数据
                CommUiltl.Log("this.dataGridView_productList.CurrentRow.IsNewRow：" + e.RowIndex + " ColumnIndex" + e.ColumnIndex);
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount)
            {
                //条码必须输入
                if (!_CheckIsKeyword(e.RowIndex, e.ColumnIndex))
                {
                    return;
                }
                //将光标移动到价钱
                CommUiltl.Log(" e.ColumnIndex == CELL_INDEX.PRODUCT_RetailDetailCount and  _ResetMoneyByRow and _SetCurrentPointToRetailDetailCount  ");
                if (!_ResetMoneyByRow(e.RowIndex, e.ColumnIndex))
                {
                    return;
                }
                _SetCurrentPointToRetailDetailCount(e.RowIndex, CELL_INDEX.PRODUCT_NORMAL_PRICE);
                return;
            }
            if (e.ColumnIndex == CELL_INDEX.PRODUCT_NORMAL_PRICE && !this.dataGridView_productList.CurrentRow.IsNewRow)
            {
                CommUiltl.Log("PRODUCT_NORMAL_PRICE");
                //条码必须输入
                if (!_CheckIsKeyword(e.RowIndex, e.ColumnIndex))
                {
                    return;
                }
                if (!_ResetMoneyByRow(e.RowIndex, e.ColumnIndex))
                {
                    return;
                }
                //将光标移动到下一行条码
                _GotoNextBarcode(e.RowIndex);
                return;
            }

        }
        private bool _CheckIsKeyword(int rowIndex, int columnIndex)
        {
            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.GOODS_BARCODE].Value))
            {
                MessageBox.Show("请输入商品货号", "操作提示");
                _SetCurrentPointToRetailDetailCount(rowIndex, CELL_INDEX.GOODS_BARCODE);
                return false;
            }
            return true;
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
        private void selectDatagrivdViewProductList()
        {
            this.dataGridView_productList.Select();
            this.dataGridView_productList.BeginEdit(true);
        }

        bool gMoveToNextBarcodeFlag = false;
        private void _GotoNextBarcode(int rowIndex)
        {
            CommUiltl.Log("_GotoNextBarcode RowIndex:"+ rowIndex + " this.dataGridView_productList.RowCount:" + this.dataGridView_productList.RowCount);
            CommUiltl.Log("_GotoNextBarcode PRODUCT_CODE:" + this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.GOODS_BARCODE].Value);
            if (rowIndex == this.dataGridView_productList.RowCount -2 )
            {
                CommUiltl.Log("RowIndex == this.dataGridView_productList.RowCount -2");
                gMoveToNextBarcodeFlag = true;
                gCurrentCell = this.dataGridView_productList.Rows[rowIndex + 1].Cells[CELL_INDEX.GOODS_BARCODE];
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
                            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value)&& this.dataGridView_productList.CurrentRow.IsNewRow)
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
                        //this.Hide();
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
                        _DeleteCurrentRow();
                        return true;
                    }
                case System.Windows.Forms.Keys.F1:
                    {
                        //重新打印小票
                        RePrintThisOrder();
                        return true;
                    }
                case System.Windows.Forms.Keys.F3:
                    {
                        //折扣
                        Discount();
                        return true;
                    }
                case System.Windows.Forms.Keys.F12:
                    {
                        return true;
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
                case System.Windows.Forms.Keys.F6:
                    {
                        //挂单恢复
                        CenterContral.CloseMoneyBox(CenterContral.CloseMoneyBoxComm);
                        return true;
                    }
                case System.Windows.Forms.Keys.End:
                    {
                        CenterContral.flagCallSetting = CenterContral.FLAG_PRODUCTlIST_WINDOW;
                        CenterContral.Windows_SettingDefaultMsgWindow.ShowByProrductList();
                        return true;
                    }
     
                case System.Windows.Forms.Keys.Insert:
                    {
                        //取消订单
                        CanCelOrder();
                        return true;
                    }
              
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void _DeleteCurrentRow()
        {
            //删除操作，把当前行给删除
            if (this.dataGridView_productList.CurrentCell == null || this.dataGridView_productList.CurrentCell.RowIndex
                 < 0 )
            {
                CommUiltl.Log("Keys.Delete CurrentCell ==null ");
                return;
            }
            CommUiltl.Log("Keys.Delete CurrentCell row count :" + this.dataGridView_productList.Rows.Count);
            DataGridViewRow oCurrentRow = this.dataGridView_productList.CurrentRow;

            if (oCurrentRow.IsNewRow)//最新一行
            {
                CommUiltl.Log("oCurrentRow.IsNewRowrow count :" + this.dataGridView_productList.Rows.Count);
                //最新的一行删除按钮，就自动移动光标到上一行
                if (oCurrentRow.Index >= 1)//确保能移动到上一行
                {
                    this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[oCurrentRow.Index - 1].Cells[CELL_INDEX.GOODS_BARCODE];
                }
                return;
            }

            //删除当前行
            CommUiltl.Log("Keys.Delete !IsNewRow oCurrentRow.Index:" + oCurrentRow.Index);
            if (!CommUiltl.IsObjEmpty(oCurrentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value))
            {
                string showTips = "是否要删除当前行 商品货号为:" + oCurrentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value;
                var confirmPayApartResult = MessageBox.Show(showTips,
                                      "取消订单操作",
                                      MessageBoxButtons.YesNo);
                if (confirmPayApartResult != DialogResult.Yes)
                {
                    return;
                }
                //先删除数据
                CenterContral.oStockOutDTO.details.RemoveAt(oCurrentRow.Index);
                CommUiltl.Log("oCurrentRow.Index ：" + oCurrentRow.Index);
                //再删除行
                this.dataGridView_productList.Rows.RemoveAt(oCurrentRow.Index);
                CommUiltl.Log("RemoveAt.Index：" + oCurrentRow.Index);
                _UpdateStockBaseMsg();
                return;
            }
            //关键词为空，删除当前行即可
            CommUiltl.Log("Keys.Delete IsObjEmpty:" + oCurrentRow.Index);
            if (!CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[oCurrentRow.Index + 1].Cells[CELL_INDEX.INDEX].Value))
            {
                this.dataGridView_productList.Rows[oCurrentRow.Index + 1].Cells[CELL_INDEX.INDEX].Value = oCurrentRow.Index+1;//最后一行的行号要变更
            }
            this.dataGridView_productList.Rows.RemoveAt(oCurrentRow.Index);
            return;



        }
        /**********************************取消订单******************************************/
        private void CanCelOrder()
        {
            //取消订单
            string showTips = "是否要取消订单";
            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "取消订单操作",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            string strProductList = "";
            _GenerateProductListForOrder(ref strProductList);
            if (!CenterContral.CanCelOrder(CenterContral.oStockOutDTO))
            {
                return;
            }
    
            MessageBox.Show("取消成功", "取消订单操作");
            _ResetAllData();

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
            _UpdateStockBaseMsg();
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
            _UpdateStockBaseMsg();
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
                SetRowsByStockOutDetail(this.dataGridView_productList.Rows[rowIndex], oStockOutDTO.details[i]);
            }
            //列出订单总价
            UpdateProductListWindowsMoneyLabel();
            //列出支付信息
            _SetPayWayDataGridView();
        }

        private void _SetPayWayDataGridView()
        {
            foreach (var item in CenterContral.oStockOutDTO.checkouts)
            {
                int i = this.dataGridView_checkout.Rows.Add();
                if (item.payType == Checkout.PAY_TYPE_CASH)
                {
                    this.dataGridView_checkout.Rows[i].Cells[0].Value = Checkout.PAY_TYPE_CASH_DESC;
                    this.dataGridView_checkout.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == Checkout.PAY_TYPE_WEIXIN)
                {
                    this.dataGridView_checkout.Rows[i].Cells[0].Value = Checkout.PAY_TYPE_WEIXIN_DESC;
                    this.dataGridView_checkout.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
                else if (item.payType == Checkout.PAY_TYPE_ZHIFUBAO)
                {
                    this.dataGridView_checkout.Rows[i].Cells[0].Value = Checkout.PAY_TYPE_ZHIFUBAO_DESC;
                    this.dataGridView_checkout.Rows[i].Cells[1].Value = CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount);
                }
            }
        }
        

        private  DataGridViewCell gCurrentCell=null;
        private bool gResetRow = false;

      
        private void _ResetAllData()
        {
            gConstructEnd = false;
            //使用clear事件，会触发行修改事件

            this.dataGridView_productList.Rows.Clear();
            this.dataGridView_checkout.Rows.Clear();
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
                &&!CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.GOODS_BARCODE].Value)
                &&CommUiltl.IsObjEmpty(this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                CommUiltl.Log("go CurrentCell ");
                //第一个
                this.dataGridView_productList.CurrentCell = this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.GOODS_BARCODE];
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
            if (CenterContral.oLocalSaveStock.listStock.Count > 0)
            {
                System.Windows.Forms.MessageBox.Show("请清理挂单，再退出");
                //有挂单，不能退出
                e.Cancel = true;
                return;
            }
            this.dataGridView_productList.Rows.Clear();
            CenterContral.Windows_Login.Close();
            Environment.Exit(1);
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
        //FormWindowState LastWindowState = FormWindowState.Minimized;
        private void ProductListWindow_SizeChanged(object sender, EventArgs e)
        {
            // When window state changes
            //if (WindowState != LastWindowState)
            //{
            //    LastWindowState = WindowState;


            //    if (WindowState == FormWindowState.Maximized)
            //    {
            //        CommUiltl.Log ("FormWindowState.Maximized");
            //        this.FormBorderStyle = FormBorderStyle.None;
            //        return;
            //    }
            //    this.FormBorderStyle = FormBorderStyle.Fixed3D;
            //    if (WindowState == FormWindowState.Normal)
            //    {
            //        CommUiltl.Log(" FormWindowState.Normal");
            //        // Restored!
            //        return;
            //    }
            //    CommUiltl.Log(" other");
            //}
        }
        //***********打印事件
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = null;
            // 信息头 
            System.Drawing.Font printFont = new System.Drawing.Font
            ("Arial", 8, System.Drawing.FontStyle.Regular);
           
            text = CenterContral.GetTicketInfo();//获取本次购物清单数据
            // 设置信息打印格式 
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 0, 5);
            CommUiltl.Log("RawPrinterHelper printDocument_PrintPage end" );
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //打印结束后
            //关闭钱箱
            CenterContral.CloseMoneyBox(CenterContral.CloseMoneyBoxComm);
            //删除文件
            if (File.Exists(CenterContral.strPrintFilePath))
            {
                File.Delete(CenterContral.strPrintFilePath);
            }
        }

        public void PrintOrder(StockOutDTO oStockOutDTO)
        {
            CommUiltl.Log("RawPrinterHelper PrintOrder");
            //把当前单据写入文件
            CenterContral.printOrderMsgToFile(oStockOutDTO);
            //打印文件
            this.printDocument.Print();
        }
         
        //#region 读取文本文件 打印完成后 重新删除该文件
        public void RePrintThisOrder()
        {
            CenterContral.Call_PrinterHistoryWindow();
            //var confirm = MessageBox.Show("是否要重打小票",
            //                      "重打小票",
            //                      MessageBoxButtons.YesNo);

            //if (confirm != DialogResult.Yes)
            //{
            //    return;
            //}
            //if (0 == CenterContral.oStockOutDTO.Base.RecieveFee)
            //{
            //     confirm = MessageBox.Show("未有收款，确认要打小票",
            //                      "重打小票",
            //                      MessageBoxButtons.YesNo);
            //    if (confirm != DialogResult.Yes)
            //    {
            //        return;
            //    }
            //}
          
            //if (CenterContral.oStockOutDTO.Base.RecieveFee < CenterContral.oStockOutDTO.Base.orderAmount)
            //{
            //    confirm = MessageBox.Show("收款额小于订单金额，确认要打小票",
            //                     "重打小票",
            //                     MessageBoxButtons.YesNo);
            //    if (confirm != DialogResult.Yes)
            //    {
            //        return;
            //    }
            //}
            //this.PrintOrder(CenterContral.oStockOutDTO);
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    public static class CELL_INDEX
    {
        public static int INDEX = 0;
        public static int GOODS_BARCODE = 1;
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
