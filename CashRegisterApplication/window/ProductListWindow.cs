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

namespace CashRegiterApplication
{

    public partial class ProductListWindow : Form
    {

        public RecieveMoneyWindows gRecieveMoneyWindows;
        bool gConstructEnd = false;

        public ProductListWindow()
        {

            InitializeComponent();
            InitData();
            gRecieveMoneyWindows = new RecieveMoneyWindows();
            gRecieveMoneyWindows.SetProductListWindow(this);
        }

        private void ProductListWindow_Load(object sender, EventArgs e)
        {
            //  _GoProductList();
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

            int index = 0;

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
            this.dataGridView_payWayD.AllowUserToAddRows = false;
            this.dataGridView_payWayD.Rows.Add();

            this.ColumnIndex.ReadOnly = true;
            this.ColumnProductName.ReadOnly = true;
            this.ColumnProductSpecification.ReadOnly = true;
            this.ColumnRemark.ReadOnly = true;
            this.ColumnMoney.ReadOnly = true;
            this.orderMsg.ReadOnly = true;
            System.Windows.Forms.Clipboard.SetText("4891913690152");
            //this.productListDataGridView.Rows.Add();
            //this.productListDataGridView[CELL_INDEX.PRODUCT_CODE, 0].Value = "4891913690152";
            //this.productListDataGridView[CELL_INDEX.PRODUCT_CODE, 1].Value = "4891913691036";
            //this.productListDataGridView[CELL_INDEX.PRODUCT_CODE, 2].Value = "4891913690206";
            gConstructEnd = true;
        }
      

 
        private void _InitOrderMsg()
        {
            this.dataGridView_order.Rows[CELL_INDEX.RECIEVE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";
            this.dataGridView_order.Rows[CELL_INDEX.ORDER_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";
            this.dataGridView_order.Rows[CELL_INDEX.CHANGE_FEE_ROW].Cells[CELL_INDEX.ORDER_COLUMN].Value = "0.00";

        }

        /*
       * 弹出框，展示实收多少钱
       */
        private void _Windows_Show_RecieveMoeny()
        {
            CommUiltl.Log("begin");
            int recieveFee = 0, orderFee = 0;
            if (!CommUiltl.ConverStrYuanToFen(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value, out recieveFee))
            {
                MessageBox.Show("实收错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value);
                return;
            }

            if (!CommUiltl.ConverStrYuanToFen(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value);
                return;
            }
            gRecieveMoneyWindows.SetFeeByProductListWindows(recieveFee, orderFee);
            this.Hide();
            gRecieveMoneyWindows.Show();
        }

        private void _Windows_Show_PayWayWindows()
        {

        }


        public void Windows_SetFeeByRecieveFeeWindows(int recieveFee)
        {
            int orderFee = 0;
            if (!CommUiltl.ConverStrYuanToFen(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value);
                return;
            }
            int changeFee = recieveFee - orderFee;
            if (changeFee < 0)
            {
                MessageBox.Show("实收价钱小于总价");
                return;
            }
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value = CommUiltl.CoverMoneyFenToString(recieveFee);
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.CHANGE_FEE_ROW].Value = CommUiltl.CoverMoneyFenToString(changeFee);
            _Windows_Show_PayWayWindows();
        }
      
        private void _SetCurrentCell()
        {
            //if (this.dataGridView_productList.RowCount > 1)
            //{
            //    _SetOrderPrice();
            //    _GoOrderDataGrid();
            //    return;
            //}
            _GoProductList();
        }
        private void _GoProductList()
        {
            this.dataGridView_order.CurrentCell = null;
            this.dataGridView_payWayD.CurrentCell = null;
            this.dataGridView_payWayD.ClearSelection();
            this.dataGridView_order.ClearSelection();
            //默认第一行正在编辑中
            this.dataGridView_productList.Select();

            this.dataGridView_productList.CurrentCell = this.dataGridView_productList.Rows[this.dataGridView_productList.RowCount - 1].Cells[1];

            this.dataGridView_productList.BeginEdit(true);
        }



        private void _ResetMoneyByRow(int rowIndex, int columnIndex)
        {
            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //价钱为空，就停止
                return;
            }
            int amout = 0, price = 0;

            if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_CODE].Value))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误条码：" + rowIndex);
                return;
            }

            if (!CommUiltl.CoverStrToInt(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_AMOUNT].Value, out amout))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误数量：" + rowIndex);
                return;
            }

            if (!CommUiltl.ConverStrYuanToFen(this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value, out price))
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("错误金额：" + rowIndex);
                return;
            }

            int orderPrice = amout * price;
            string strOrderPrice = CommUiltl.CoverMoneyFenToString(orderPrice);
            this.dataGridView_productList.Rows[rowIndex].Cells[CELL_INDEX.PRODUCT_MONEY].Value = strOrderPrice;
            _SetOrderPrice();
        }


        private void _SetOrderPrice()
        {
            int rowCount = this.dataGridView_productList.RowCount;
            int orderPrice = 0, money = 0;
            for (int index = 0; index < rowCount; ++index)
            {
                if (CommUiltl.IsObjEmpty(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value))
                {
                    continue;
                }

                if (!CommUiltl.ConverStrYuanToFen(this.dataGridView_productList.Rows[index].Cells[CELL_INDEX.PRODUCT_MONEY].Value, out money))
                {
                    MessageBox.Show("错误行：" + index);
                    return;
                }

                orderPrice += money;
            }
            string strOrderPrice = CommUiltl.CoverMoneyFenToString(orderPrice);
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value = strOrderPrice;
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value = strOrderPrice;
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.CHANGE_FEE_ROW].Value = "0.00";
            return;
        }

        private void GetProductByProductCode(int rowIndex, int columnIndex)
        {
            DataGridViewRow currentRow = this.dataGridView_productList.Rows[rowIndex];
            //if (!CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            //{
            //    //说明数量被修改了，那么这个商品不再做处理
            //    return;
            //}

            if (CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value) && CommUiltl.IsObjEmpty(currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value))
            {
                //空行
                //_GoOrderDataGrid();//跳到总价
                return;
            }

            string productCode = currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value.ToString().Trim();
            if (productCode == "")
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("当前行有问题 rowIndex:" + rowIndex + " columnIndex" + columnIndex);
                return;
            }

            ProductPricingInfoResp oProductPricingInfoResp = new ProductPricingInfoResp();
            if (!HttpUtility.GetProductByProductCode(productCode, ref oProductPricingInfoResp))
            {
                //网络出现错误，要访问本地

            }
            if (oProductPricingInfoResp.errorCode != 0)
            {
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                MessageBox.Show("后台返回商品失败 productCode:" + productCode);
                return;
            }
            //string tagUrl = "http://aladdin.chalubo.com/cashRegister/getPricingByProductCode.json?productCode=" + productCode;
            //CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            //HttpWebResponse response = HttpUtility.CreateGetHttpResponse(tagUrl, null, null, cookies);

            //StreamReader streamReader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
            //string content = streamReader.ReadToEnd();

            ////将Json字符串转化成对象
            //ProductPricingInfoResp productResp = JsonConvert.DeserializeObject<ProductPricingInfoResp>(content);
            //if (productResp.errorCode != 0 )
            //{
            //    _SetPointToResetCurrentCell(this.productListDataGridView.Rows[rowIndex].Cells[columnIndex]);
            //    MessageBox.Show("后台返回商品失败 productCode:" + productCode + " ;content:" + content);
            //    return ;
            //}


            ProductPricing productInfo = oProductPricingInfoResp.data.info;
            if (CommUiltl.IsObjEmpty(productInfo.ProductCode) ||
               CommUiltl.IsObjEmpty(productInfo.NormalPrice) ||
                CommUiltl.IsObjEmpty(productInfo.ProductName)
                )
            {
                MessageBox.Show("productInfo.ProductCode:" + productInfo.ProductCode);
                MessageBox.Show("productInfo.NormalPrice:" + productInfo.NormalPrice);
                MessageBox.Show("productInfo.ProductName:" + productInfo.ProductName);
                MessageBox.Show("后台返回 有问题商品");
                _SetPointToResetCurrentCell(this.dataGridView_productList.Rows[rowIndex].Cells[columnIndex]);
                return;
            }

            currentRow.Cells[CELL_INDEX.INDEX].Value = currentRow.Index + 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].Value = productInfo.ProductCode;
            currentRow.Cells[CELL_INDEX.PRODUCT_CODE].ReadOnly = true;//请求到后台的条码，不允许修改，只能删除，防止误操作
            currentRow.Cells[CELL_INDEX.PRODUCT_NAME].Value = productInfo.ProductName;
            currentRow.Cells[CELL_INDEX.PRODUCT_SPECIFICATION].Value = productInfo.ProductSpecification;
            string normalPrice = CommUiltl.CoverMoneyFenToString(productInfo.NormalPrice);
            currentRow.Cells[CELL_INDEX.PRODUCT_NORMAL_PRICE].Value = normalPrice;
            currentRow.Cells[CELL_INDEX.PRODUCT_AMOUNT].Value = 1;
            currentRow.Cells[CELL_INDEX.PRODUCT_MONEY].Value = normalPrice;

            //更新订单价钱
            _SetOrderPrice();
            // _GoNextTab();

        }

        private void _GoOrderDataGrid()
        {
            CommUiltl.Log("this.productListDataGridView CurrentCell: " + (this.dataGridView_productList.CurrentCell == null));
            //MessageBox.Show("_GoOrderDataGrid " + this.productListDataGridView.CurrentRow.Index + " index" + this.productListDataGridView.CurrentCell.ColumnIndex);
            //跳转到总价的金额编辑
            this.dataGridView_productList.CurrentRow.Selected = false;
            this.dataGridView_payWayD.ClearSelection();

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
            //int RowIndex=this.productListDataGridView.CurrentCell.RowIndex;
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
                GetProductByProductCode(e.RowIndex, e.ColumnIndex);
            }
            else if (e.ColumnIndex == CELL_INDEX.PRODUCT_AMOUNT || e.ColumnIndex == CELL_INDEX.PRODUCT_NORMAL_PRICE)
            {
                CommUiltl.Log("e.ColumnIndex == CELL_INDEX.PRODUCT_AMOUN ");
                _ResetMoneyByRow(e.RowIndex,e.ColumnIndex);
            }
        }

        private void productListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("begin ");
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
            _GoCurrentProductCodeIfNeed();
            if (this.dataGridView_productList.CurrentCell != null)
            {
                CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
                return;
            }
            CommUiltl.Log("end ");
        }


        private void productListDataGridView_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
        }
        

        private void productListDataGridView_Enter(object sender, EventArgs e)
        {
            CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
            if (gResetRow)
            {
                gResetRow = false;
                this.dataGridView_productList.CurrentCell = gCurrentCell;
            }
            //MessageBox.Show("Enter:" + e.ToString());
        }

        private void productListDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CommUiltl.Log("row:" + this.dataGridView_productList.CurrentCell.RowIndex + " Column:" + this.dataGridView_productList.CurrentCell.ColumnIndex);
            //MessageBox.Show("KeyDown:" + e.ToString());
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
                                    this.dataGridView_productList.CurrentRow.Cells[CELL_INDEX.INDEX].Value = "";
                                    _SetOrderPrice();
                                    //_GoOrderDataGrid();
                                    _Windows_Show_RecieveMoeny();
                                }
                                return base.ProcessCmdKey(ref msg, keyData);
                            }

                        }
                        if (this.dataGridView_order.IsCurrentCellInEditMode)
                        {
                            //this.orderDataGridView.BeginEdit(false);
                            //this.orderDataGridView.CurrentCell = null;
                            //if (this.orderDataGridView.CurrentCell.RowIndex == CELL_INDEX.ORDER_FEE_ROW)
                            //{
                               
                            //}
                            //return true;
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
                                }
                              
                            }
                        }
                        return true;
                    }
                case System.Windows.Forms.Keys.F12:
                    {
                        CommUiltl.Log("Keys.F12");
                        // We use these three SQLite objects:
                        SQLiteConnection sqlite_conn;
                        SQLiteCommand sqlite_cmd;
                        SQLiteDataReader sqlite_datareader;

                        // create a new database connection:
                        sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

                        // open the connection:
                        sqlite_conn.Open();

                        // create a new SQL command:
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        //// Let the SQLiteCommand object know our SQL-Query:
                        //sqlite_cmd.CommandText = "CREATE TABLE  IF NOT EXISTS test (id integer primary key, text varchar(100));";

                        //// Now lets execute the SQL ;D
                        //sqlite_cmd.ExecuteNonQuery();

                        //// Lets insert something into our new table:
                        //sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";

                        //// And execute this again ;D
                        //sqlite_cmd.ExecuteNonQuery();

                        //// ...and inserting another line:
                        //sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";

                        //// And execute this again ;D
                        //sqlite_cmd.ExecuteNonQuery();

                        // But how do we read something out of our table ?
                        // First lets build a SQL-Query again:
                        sqlite_cmd.CommandText = "SELECT * FROM test";

                        // Now the SQLiteCommand object can give us a DataReader-Object:
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        // The SQLiteDataReader allows us to run through the result lines:
                        while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                        {
                            // Print out the content of the text field:
                            //System.Console.WriteLine( sqlite_datareader["text"] );

                            int myreader = sqlite_datareader.GetInt32(0);
                            MessageBox.Show("int:" + sqlite_datareader.GetInt32(0) + " string:" + sqlite_datareader.GetString(1));
                        }
                        // We are ready, now lets cleanup and close our connection:
                        sqlite_conn.Close();
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
            int orderFee = 0, recieveFee = 0, changeFee = 0;
            if (! CommUiltl.ConverStrYuanToFen(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.ORDER_FEE_ROW].Value);
                return;
            }
            if (! CommUiltl.ConverStrYuanToFen(this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value, out recieveFee))
            {
                MessageBox.Show("实收错误:" + this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.RECIEVE_FEE_ROW].Value);
                return;
            }

            changeFee = recieveFee - orderFee;
            this.dataGridView_order[CELL_INDEX.ORDER_COLUMN, CELL_INDEX.CHANGE_FEE_ROW].Value = CommUiltl.CoverMoneyFenToString(changeFee);
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
        private void _GoCurrentProductCodeIfNeed()
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
        public static int PRODUCT_AMOUNT = 5;
        public static int PRODUCT_MONEY = 6;

        public static int ORDER_COLUMN = 1;
        public static int RECIEVE_FEE_ROW = 0;
        public static int ORDER_FEE_ROW = 1;
        public static int CHANGE_FEE_ROW = 2;
    }

}
