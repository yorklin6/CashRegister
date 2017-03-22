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
        public static bool GenerateOrder()
        {
            ConnecSql();
            CommUiltl.Log("Dao GenerateOrder");
            int iRow = 0;
            //插入订单
           string strSql = "insert into t2_cash_register_order  ";
            strSql += " (CashRegisterOrderNumber,OrderFee,ReceiveFee,ChangeFee,CreateTime,CloudState,PayState) VALUES (";
            strSql += "'"+ CurrentMsg.Order.OrderNumber+"',";
            strSql += "" + CurrentMsg.Order.OrderFee + ",";
            strSql += "" + CurrentMsg.Order.RecieveFee + ",";
            strSql += "" + CurrentMsg.Order.ChangeFee + ",";
            strSql += "datetime('now'),";
            strSql += "" + CurrentMsg.CLOUD_SATE_ORDER_GENERATE_INIT + ",";
            strSql += "" + CurrentMsg.Order.PayState + " ";
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
            foreach (var item in CurrentMsg.ProductPricing)
            {
                strSql = "INSERT INTO t2_cash_register_order_product ";
                strSql += " (CashRegisterOrderNumber,ProductId,ProductCode,ProductName,PayState,SellAmount,CloudState,SelllPrice) VALUES (";
                strSql += " '" + CurrentMsg.Order.OrderNumber + "',";
                strSql += " " + item.ProductId + ",";
                strSql += "'" + item.ProductCode + "',";
                strSql += "'" + item.ProductName + "',";
                strSql += "" + CurrentMsg.PAY_STATE_INIT + ",";
                strSql += "" + item.Amount + ",";
                strSql += "" + CurrentMsg.CLOUD_SATE_ORDER_GENERATE_INIT + ",";
                strSql += "" + item.SelllPrice + " ";
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
        public static bool UpdateOrderCloudStae(int state)
        {
            ConnecSql();
            CommUiltl.Log("Dao GenerateOrderCloudSuccess");
            int iRow = 0;
            //插入订单
            string strSql = "update t2_cash_register_order set   CloudState=" + state + " where  CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "' ";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("更新本地数据库云操作失败:" + ex.ToString());
                return false;
            }
            if (0 == iRow)
            {
                MessageBox.Show("更新本地数据库云操作失败");
                return false;
            }
            //插入订单商品数据
            foreach (var item in CurrentMsg.ProductPricing)
            {
                strSql = "update t2_cash_register_order_product set   CloudState=" + state + " where  CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "' and DeleteFlag =0 ";
                sqlite_cmd = sqlite_conn.CreateCommand();
                try
                {
                    sqlite_cmd.CommandText = strSql;
                    iRow = sqlite_cmd.ExecuteNonQuery();
                }

                catch (SQLiteException ex)
                {
                    MessageBox.Show("更新商品本地数据库云操作库失败:" + ex.ToString());
                    return false;
                }

                if (0 == iRow)
                {
                    MessageBox.Show("更新商品本地数据库云操作库失败");
                    return false;
                }
            }
            CommUiltl.Log("更新商品本地数据库云操作库失败成功");
            return true;
        }
        


        public static bool updateOrder()
        {
            
            CommUiltl.Log("Dao GenerateOrder");
            int iRow = 0;
            //更新订单
            string strSql = "update  t2_cash_register_order set ";
            strSql += "OrderFee=" + CurrentMsg.Order.OrderFee + " ";
            strSql += "where CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "' ";
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
            strSql = "update  t2_cash_register_order_product set DeleteFlag =1 where CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "'";
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
            foreach (var item in CurrentMsg.ProductPricing)
            {
                strSql = "INSERT INTO t2_cash_register_order_product ";
                strSql += " (CashRegisterOrderNumber,ProductId,ProductCode,ProductName,SellAmount,SelllPrice) VALUES (";
                strSql += " '" + CurrentMsg.Order.OrderNumber + "',";
                strSql += " " + item.ProductId + ",";
                strSql += "'" + item.ProductCode + "',";
                strSql += "'" + item.ProductName + "',";
                strSql += "" + item.Amount + ",";
                strSql += "" + item.SelllPrice + " ";
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
            string strSql = "update  t2_cash_register_order set ";
            strSql += "OrderFee=" + CurrentMsg.Order.OrderFee + " ";
            strSql += "where CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "' ";
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
            // //把这个单下面的商品都置为删除
            strSql = "update  t2_cash_register_order_product set DeleteFlag =1 where CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "'";
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
            foreach (var item in CurrentMsg.ProductPricing)
            {
                strSql = "INSERT INTO t2_cash_register_order_product ";
                strSql += " (CashRegisterOrderNumber,ProductId,ProductCode,ProductName,SellAmount,SelllPrice) VALUES (";
                strSql += " '" + CurrentMsg.Order.OrderNumber + "',";
                strSql += " " + item.ProductId + ",";
                strSql += "'" + item.ProductCode + "',";
                strSql += "'" + item.ProductName + "',";
                strSql += "" + item.Amount + ",";
                strSql += "" + item.SelllPrice + " ";
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
        
        internal static bool CloseOrderWhenPayAllFee()
        {
             string strSql = "update  t2_cash_register_order set ";
            strSql += "PayState=" + CurrentMsg.PAY_STATE_SUCCESS + " ";
            strSql += "where CashRegisterOrderNumber='" + CurrentMsg.Order.OrderNumber + "' ";
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

        /*********************支付单*********************/
        internal static bool PayOrderByCash(int recieveFee)
        {
            CommUiltl.Log("Dao GenerateOrder");
           
            int iRow = 0;
            //插入订单
            string strSql = "insert into t2_cash_register_pay  ";
            strSql += " (CashRegisterOrderNumber,CashRegisterPayOrderNumber,payFee,PayType,PayState,CreateTime,CloudState,PayCode) VALUES (";
            strSql += "'" + CurrentMsg.Order.OrderNumber + "',";
            strSql += "'" + CurrentMsg.Order.PayOrderNumber + "',";
            strSql += "" + recieveFee + ",";
            strSql += "" + CurrentMsg.PAY_TYPE_CASH + ",";
            strSql += "" + CurrentMsg.PAY_STATE_SUCCESS + ",";
            strSql += "datetime('now'),";
            strSql += "" + CurrentMsg.CLOUD_SATE_PAY_GENERATE_INIT + ",";
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
                MessageBox.Show("支付插入本地数据库失败:" + ex.ToString());
                return false;
            }

            if (0 == iRow)
            {
                MessageBox.Show("支付插入本地数据库失败");
                return false;
            }
            CommUiltl.Log("PayOrderByCash ok success");
            return true;
        }
        //UpdatePayCloudStae
        internal static bool UpdatePayCloudStae(int state)
        {
            CommUiltl.Log("Dao UpdatePayCloudStae");
            int iRow = 0;
            //插入订单
            string strSql = "update t2_cash_register_pay set   CloudState=" + state + " where  CashRegisterPayOrderNumber='" + CurrentMsg.Order.PayOrderNumber + "' ";
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

        public bool Daemone()
        {
            ConnecSql();
            //CurrentMsg
            // CurrentMsg.ProductPricing;
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
