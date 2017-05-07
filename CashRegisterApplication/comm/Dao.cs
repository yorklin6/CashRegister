using CashRegisterApplication.model;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.comm
{
    public class Dao
    {
        // We use these three SQLite objects:
        public static SQLiteConnection sqlite_conn;



        public static SQLiteCommand sqlite_cmd;
        public static SQLiteDataReader sqlite_datareader;
        public static bool initDbFalg=false;

        public const int STOCK_BASE_SAVE_FLAG_INIT = 0;
        public const int STOCK_BASE_SAVE_FLAG_SAVING = 1;//挂单状态
        public const int STOCK_BASE_SAVE_FLAG_CLOSE = 2;//挂单关单

        public static void  ConnecSql()
        {
            if (initDbFalg)
            {
                return;
            }
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            initDbFalg = true;
        }
        /*********************下单单*********************/
        public static bool GenerateOrder(StockOutDTO oStockOutDTO)
        {
            ConnecSql();
            CommUiltl.Log("Dao GenerateOrder");
            int iRow = 0;
            //插入订单
           string strSql = "insert into tb_stock_out_base  ";
            strSql += " (stock_out_id,serial_number,type,store_id,whouse_id,";
            strSql += "related_order,client_id,pos_id,cashier_id,order_amount,";
            strSql += "recieve_fee,change_fee,create_time,";
            strSql += "base_data_json,cloud_add_flag,cloud_update_flag,cloud_close_flag,cloud_delete_flag,";
            strSql += "local_save_flag,";
            strSql += "remark,status) VALUES (";
            strSql += "'" + oStockOutDTO.Base.stockOutId + "',";
            strSql += "'"+ oStockOutDTO.Base.serialNumber+"',";
            strSql += "'" + oStockOutDTO.Base.type + "',";
            strSql += "" + oStockOutDTO.Base.storeId + ",";
            strSql += "" + oStockOutDTO.Base.whouseId + ",";
            strSql += "" + oStockOutDTO.Base.relatedOrder + ",";
            strSql += "'" + oStockOutDTO.Base.clientId + "',";
            strSql += "'" + oStockOutDTO.Base.posId + "',";
            strSql += "'" + oStockOutDTO.Base.cashierId + "',";
            strSql += "" + oStockOutDTO.Base.orderAmount + ",";
            strSql += "" + oStockOutDTO.Base.RecieveFee + ",";
            strSql += "" + oStockOutDTO.Base.ChangeFee + ",";
            strSql += "datetime('now'),";
            strSql += "'" + oStockOutDTO.Base.baseDataJson + "',";
            strSql += "" + oStockOutDTO.Base.cloudAddFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudUpdateFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudCloseFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudDeleteFlag + ",";

            strSql += "" + oStockOutDTO.Base.localSaveFlag + ",";
            strSql += "'" + oStockOutDTO.Base.remark + "',";
            strSql += "" + oStockOutDTO.Base.status + " ";
            strSql += ")";
            sqlite_cmd = sqlite_conn.CreateCommand();

            try
            {
                CommUiltl.Log("sql: "+strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("插入本地数据库失败:" +ex.ToString());
                return false;
            }
            if ( 0 == iRow)
            {
                MessageBox.Show("插入本地数据库失败");
                return false;
            }
            //插入订单商品数据
            foreach (var item in oStockOutDTO.details)
            {
                strSql = "INSERT INTO tb_stock_out_detail ";
                strSql += " (id,stock_out_id,serial_number,goods_id,goods_name,barcode,actual_count,cloud_state,specification,unit,order_count,detail_data_json,unit_price) VALUES (";
                strSql += " " + item .id + ",";
                strSql += " " + item.stockOutId + ",";
                strSql += " '" + oStockOutDTO.Base.serialNumber + "',";
                strSql += " " + item.goodsId + ",";
                strSql += " '" + item.goodsName + "',";
                strSql += "'" + item.barcode + "',";
                strSql += "" + item.actualCount + ",";
                strSql += "" + item.cloudState + ",";
                strSql += "'" + item.specification + "',";
                strSql += "'" + item.unit + "',";
                strSql += "" + item.orderCount + ",";
                strSql += "'" + item.detailDataJson + "',";
                strSql += "" + item.unitPrice + " ";
                strSql += ")";
                sqlite_cmd = sqlite_conn.CreateCommand();

                try
                {
                    sqlite_cmd.CommandText = strSql;
                    iRow = sqlite_cmd.ExecuteNonQuery();
                }

                catch (SQLiteException ex)
                {
                    MessageBox.Show("插入订单商品本地数据库失败:" + ex.ToString());
                    return false;
                }

                if (0 == iRow)
                {
                    MessageBox.Show("插入商品本地订单本地数据库失败");
                    return false;
                }
            }
            CommUiltl.Log("本地下单成功");
            return true;
        }



        internal static bool UpdateOrderCloudState(StockOutDTO oStockOutDTO)
        {
            ConnecSql();
            CommUiltl.Log("Dao updateRetailStock");
            int iRow = 0;
            //插入订单
            string strSql = "update tb_stock_out_base set   ";


            strSql += " base_data_json='" + oStockOutDTO.Base.baseDataJson + "',";
            strSql += " cloud_add_flag=" + oStockOutDTO.Base.cloudAddFlag + ",";
            strSql += " cloud_update_flag=" + oStockOutDTO.Base.cloudUpdateFlag + ",";
            strSql += " cloud_close_flag=" + oStockOutDTO.Base.cloudCloseFlag + ",";
            strSql += " cloud_delete_flag=" + oStockOutDTO.Base.cloudDeleteFlag + "";

            strSql += " where  serial_number='" + oStockOutDTO.Base.serialNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库操作失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新本地数据库操作失败");
                return false;
            }

            CommUiltl.Log("更新商品本地数据库成功");
            return true;
        }



        public static bool updateRetailStock(StockOutDTO oStockOutDTO)
        {
            
            CommUiltl.Log("Dao GenerateOrder");
            int iRow = 0;
            //更新订单
            string strSql = "update tb_stock_out_base set   ";
            strSql += " stock_out_id='" + oStockOutDTO.Base.stockOutId + "',";
            strSql += " type='" + oStockOutDTO.Base.type + "',";
            strSql += " store_id=" + oStockOutDTO.Base.storeId + ",";
            strSql += " whouse_id=" + oStockOutDTO.Base.whouseId + ",";
            strSql += " related_order=" + oStockOutDTO.Base.relatedOrder + ",";
            strSql += " client_id='" + oStockOutDTO.Base.clientId + "',";
            strSql += " pos_id='" + oStockOutDTO.Base.posId + "',";
            strSql += " cashier_id='" + oStockOutDTO.Base.cashierId + "',";
            strSql += " order_amount=" + oStockOutDTO.Base.orderAmount + ",";
            strSql += " recieve_fee=" + oStockOutDTO.Base.RecieveFee + ",";
            strSql += " change_fee=" + oStockOutDTO.Base.ChangeFee + ",";
            strSql += " remark='" + oStockOutDTO.Base.remark + "',";
            strSql += " base_data_json='" + oStockOutDTO.Base.baseDataJson + "',";
            strSql += " cloud_add_flag=" + oStockOutDTO.Base.cloudAddFlag + ",";
            strSql += " cloud_update_flag=" + oStockOutDTO.Base.cloudUpdateFlag + ",";
            strSql += " cloud_close_flag=" + oStockOutDTO.Base.cloudCloseFlag + ",";
            strSql += " cloud_delete_flag=" + oStockOutDTO.Base.cloudDeleteFlag + ",";
            strSql += " status=" + oStockOutDTO.Base.status + " ";
            strSql += " where  serial_number='" + oStockOutDTO.Base.serialNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新订单本地数据库失败:" + ex.ToString());
                return false;
            }
            if ( 0 == iRow)
            {
                MessageBox.Show("更新本地数据库失败，影响行数不为0");
                return false;
            }
            // //把这个单下面的商品都置为删除
            strSql = "update  tb_stock_out_detail set delete_flag =1 where serial_number='" + oStockOutDTO.Base.serialNumber + "'";
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库失败:" + ex.ToString());
                return false;
            }
            //再插入商品
            foreach (var item in oStockOutDTO.details)
            {
                strSql = "INSERT INTO tb_stock_out_detail ";
                strSql += " (id,stock_out_id,serial_number,goods_id,goods_name,barcode,actual_count,specification,unit,order_count,unit_price) VALUES (";
                strSql += " " + item.id + ",";
                strSql += " " + item.stockOutId + ",";
                strSql += " '" + oStockOutDTO.Base.serialNumber + "',";
                strSql += " " + item.goodsId + ",";
                strSql += " '" + item.goodsName + "',";
                strSql += "'" + item.barcode + "',";
                strSql += "" + item.actualCount + ",";
                strSql += "'" + item.specification + "',";
                strSql += "'" + item.unit + "',";
                strSql += "" + item.orderCount + ",";
                strSql += "" + item.unitPrice + " ";
                strSql += ")";
                sqlite_cmd = sqlite_conn.CreateCommand();
                try
                {
                    sqlite_cmd.CommandText = strSql;
                    iRow = sqlite_cmd.ExecuteNonQuery();
                }

                catch (SQLiteException ex)
                {
                    MessageBox.Show("插入订单商品本地数据库失败:" + ex.ToString());
                    return false;
                }

                if (0 == iRow)
                {
                    MessageBox.Show("插入商品本地订单本地数据库失败");
                    return false;
                }
            }
            CommUiltl.Log("本地更新订单成功");
            return true;
        }
       
        public static bool UpdateOrderCloudSuccess()
        {

            CommUiltl.Log("Dao UpdateOrderCloudSuccess");
            int iRow = 0;
            //更新订单
            string strSql = "update  tb_stock_out_base set ";
            strSql += "order_amount=" + CenterContral.oStockOutDTO.Base.orderAmount + ", ";
            strSql += "local_save_flag=" + CenterContral.oStockOutDTO.Base.localSaveFlag + " ";
            strSql += "where serialNumber='" + CenterContral.oStockOutDTO.Base.serialNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新订单本地数据库失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新本地数据库失败，影响行数不为0");
                return false;
            }

            CommUiltl.Log("本地更新订单成功");
            return true;
        }
        //关单
        internal static bool CloseOrderWhenPayAllFee()
        {
             string strSql = "update  tb_stock_out_base set ";
            strSql += "PayState=" + CenterContral.PAY_STATE_SUCCESS + " ";
            strSql += "where serialNumber='" + CenterContral.oStockOutDTO.Base.serialNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            int iRow = 0;
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新本地数据库失败，影响行数不为0");
                return false;
            }
            CommUiltl.Log("CloseOrderWhenPayAllFee ok success");
            return true;
        }
        //取出云同步失败的订单
        internal static bool GetCloudStateFailedStockOutList(StockOutDTO oState,ref List<StockOutDTO> oJsonList)
        {
            string strSql = "";
            strSql += "select stock_out_id,serial_number,base_data_json from tb_stock_out_base ";
            strSql += "where 1=1 ";
            if (oState.Base.cloudAddFlag != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                strSql += " and cloud_add_flag="+ oState.Base.cloudAddFlag;
            }
            else if (oState.Base.cloudUpdateFlag != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                strSql += " and cloud_update_flag=" + oState.Base.cloudUpdateFlag;
            }
            else if (oState.Base.cloudCloseFlag != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                strSql += " and cloud_close_flag=" + oState.Base.cloudCloseFlag;
            }
            else if (oState.Base.cloudDeleteFlag != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                strSql += " and cloud_delete_flag=" + oState.Base.cloudDeleteFlag;
            }
            else if (oState.Base.localSaveFlag != Dao.STOCK_BASE_SAVE_FLAG_INIT)
            {
                strSql += " and local_save_flag=" + oState.Base.localSaveFlag;
            }
            else
            {
                strSql += " and 1=0 ";//什么都没输入，那么就什么都不查
            }
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show("插入本地数据库失败:" + ex.ToString());
                CommUiltl.Log("查询本地数据库失败:" + ex.ToString());
                return false;
            }

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                StockOutDTO oStockOutDTO = new StockOutDTO();
                oStockOutDTO.Base.stockOutId = sqlite_datareader.GetInt64(0);
                oStockOutDTO.Base.serialNumber = sqlite_datareader.GetString(1);
                oStockOutDTO.Base.baseDataJson = sqlite_datareader.GetString(2);
                oJsonList.Add(oStockOutDTO);
            }
            return true;
        }

        /*********************支付单*********************/
        internal static bool GeneratePay(PayWay oPayWay)
        {
            CommUiltl.Log("Dao GenerateOrder");
           
            int iRow = 0;
            //插入订单
            string strSql = "insert into tb_checkout  ";
            strSql += " (id,pos_id,store_id,is_deleted,related_order,serial_number,CashRegisterPayOrderNumber,pay_amount,pay_type,payStatus,create_time,CloudState,PayCode) VALUES (";
            strSql += "" + oPayWay.id + ",";
            strSql += "" + oPayWay.posId + ",";
            strSql += "" + oPayWay.storeId + ",";
            strSql += "" + oPayWay.isDeleted + ",";
            
            strSql += "'" + oPayWay.relatedOrder + "',";
            strSql += "'" + oPayWay.stockOutSerialNumber + "',";
            strSql += "'" + oPayWay.serialNumber + "',";
            strSql += "" + oPayWay.payAmount + ",";
            strSql += "" + oPayWay.payType+ ",";
            strSql += "" + oPayWay.payStatus + ",";
            strSql += "datetime('now'),";
            strSql += "" + oPayWay.cloudState + ",";
            strSql += "'PayCode'";
            strSql += ")";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("插入本地数据库失败:" + ex.ToString());
                return false;
            }

            if (0 == iRow)
            {
                MessageBox.Show("插入本地数据库失败");
                return false;
            }
            CommUiltl.Log("PayOrderByCash ok success");
            return true;
        }
        //UpdatePayCloudStae
        internal static bool UpdatePayCloudStae(PayWay oPayWay)
        {
            CommUiltl.Log("Dao UpdatePayCloudStae");
            int iRow = 0;
            //插入订单
            string strSql = "update tb_checkout set CloudState=" + oPayWay.cloudState + " where  CashRegisterPayOrderNumber='" + oPayWay.serialNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新支付本地数据库云状态失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新支付本地数据库云状态");
                return false;
            }
            CommUiltl.Log("更新支付本地数据库云状态 UpdatePayCloudStae ok success");
            return true;
        }
        //会员充值流水
        internal static bool memberRecharge(Member oRechargeMember, long beforeMberBalance, long afterMemberAccount, long recieveFee)
        {
            CommUiltl.Log("Dao memberRecharge");
            int iRow = 0;
            //插入订单
            string strSql = "insert into tb_member_recharge  ";
            strSql += " (member_id,name,member_account,berfore_balance,after_balance,create_time,cloud_state,req_json) VALUES (";
            strSql += "" + oRechargeMember.memberId + ",";
            strSql += "'" + oRechargeMember.name + "',";
            strSql += "" + oRechargeMember.memberAccount + ",";
            strSql += "" + beforeMberBalance + ",";
            strSql += "" + afterMemberAccount + ",";
            strSql += "datetime('now'),";
            strSql += "" + oRechargeMember.cloudState + ",";
            strSql += "'" + oRechargeMember.reqJson + "'";
            strSql += ")";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("插入本地数据库失败:" + ex.ToString());
                return false;
            }

            if (0 == iRow)
            {
                MessageBox.Show("插入本地数据库失败");
                return false;
            }
            CommUiltl.Log("PayOrderByCash ok success");
            return true;
        }
        internal static bool GetPayType(ref string json)
        {
            string strSql = "";
            strSql += "select pay_type_list from tb_local_msg ";
            strSql += "limit 1 ";

            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                CommUiltl.Log("支付类型:" + ex.ToString());
                return false;
            }

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                json = sqlite_datareader.GetString(0);
            }
            return true;
        }
        internal static bool SetPayType(ref string json)
        {
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_msg set pay_type_list='" + json + "'";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新支付本地数据库影响行数=0失败");
                return false;
            }
            CommUiltl.Log("SetPayType ok success");
            return true;
        }

        /************************门店信息****************************/
        //取出默认门店
        internal static bool GetStoreWhouseDefault(ref string json)
        {
            string strSql = "";
            strSql += "select store_whouse_default from tb_local_msg ";
            strSql += "limit 1 ";
          
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                CommUiltl.Log("门店信息:" + ex.ToString());
                return false;
            }

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                json = sqlite_datareader.GetString(0);
            }
            return true;
        }
        


        internal static bool UpdateStoreWhouseDefault(string strStoreWhouseDefult)
        {
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_msg set store_whouse_default='" + strStoreWhouseDefult + "'";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新支付本地数据库影响行数=0失败");
                return false;
            }
            CommUiltl.Log("UpdateStoreWhouseDefault ok success");
            return true;
        }

        //取出默认数据
        internal static bool GetLocalMsgDefaultCount(out int iCount)
        {
            iCount = 0;
            string strSql = "";
            strSql += "select count(*) from tb_local_msg ";
            strSql += "limit 1 ";

            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                CommUiltl.Log("取出默认信息异常:" + ex.ToString());
                return false;
            }
            while (sqlite_datareader.Read()) 
            {
                iCount = sqlite_datareader.GetInt32(0);
            }
            return true;
        }
        //初始化默认数据
        internal static bool InsertLocalMsgDefault()
        {
            string strSql = "insert into tb_local_msg  ";
            strSql += " (store_whouse_default,pay_type_list) VALUES (";
            strSql += "'',";
            strSql += "''";
            strSql += ")";
            sqlite_cmd = sqlite_conn.CreateCommand();
            int iRow = 0;
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("插入本地数据库失败:" + ex.ToString());
                return false;
            }

            if (0 == iRow)
            {
                MessageBox.Show("插入本地数据库失败");
                return false;
            }
            CommUiltl.Log("InsertLocalMsgDefault ok success");
            return true;
        }

        public bool Daemone()
        {
            ConnecSql();
            //Main
            // Main.oStockOutDTO.details;
            CommUiltl.Log("Dao Daemone");

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
            return true;
        }


    }
}
