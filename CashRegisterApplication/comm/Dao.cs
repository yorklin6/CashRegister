using CashRegisterApplication.model;
using CashRegiterApplication;
using Newtonsoft.Json;
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

        public const int STOCK_BASE_CANCEL_FLAG_INI = 0;//未取消订单
        public const int STOCK_BASE_CANCEL_FLAG_TRUE = 1;//取消订单

        public const int STOCK_BASE_DELETE_INI = 0;//未删除
        public const int STOCK_BASE_DELETE_TRUE = 99;//删除订单
        public const int DELETE_FLAG =1;
        /*********************初始化*********************/
        internal static bool CheckIsInit(ref int iCount)
        {
            ConnecSql();
            if (!GetTableCount(ref iCount))
            {
                MessageBox.Show("db 失败，系统出现异常");
                return false;
            }
        
           
            return true;
        }
        internal static void CreateTables()
        {
            ConnecSql();
            //丢掉表，然后再创建表
            CreateTableIfIsNotExist();
        }

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
        /******创建表*******************/
        internal static bool GetTableCount(ref int count)
        {
            string strSql = "";
            strSql += "select count(*) from sqlite_master where type='table' and name='tb_local_msg'  ";
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
                if (sqlite_datareader.IsDBNull(0))
                {
                    CommUiltl.Log("IsDBNull: " + strSql);
                    return false;
                }
                count=sqlite_datareader.GetInt32(0);
                CommUiltl.Log("count: " + count);
                return true;
            }
            return false;
        }
        internal static bool CreateTableIfIsNotExist()
        {
            string strSql = "";
            //丢掉之前的数据
            strSql += "DROP TABLE IF EXISTS[tb_checkout]; ";
            strSql += "DROP TABLE IF EXISTS[tb_local_goods]; ";
            strSql += "DROP TABLE IF EXISTS[tb_local_msg]; ";
            strSql += "DROP TABLE IF EXISTS[tb_member_recharge]; ";
            strSql += "DROP TABLE IF EXISTS[tb_stock_out_base]; ";
            strSql += "DROP TABLE IF EXISTS[tb_stock_out_detail]; ";

            //创建表
            strSql += "CREATE TABLE [tb_checkout](  [id] INT(10) NOT NULL, [store_id] INT(10) NOT NULL, [pos_id] INT(10) NOT NULL, [related_order] INT(10) NOT NULL, [pay_type] TINYINT(3) NOT NULL, [pay_amount] BIGINT(20) NOT NULL, [is_deleted] TINYINT(3) NOT NULL, [create_time] DATETIME NOT NULL, [update_time] DATETIME, [serial_number] VARCHAR(50), [PayCode] VARCHAR(20), [CloudState] INT, [check_out_data_json] TEXT, [CashRegisterPayOrderNumber] VARCHAR(50), [payStatus] INT, [reqMemberZfJson] TEXT ); ";
            strSql += "CREATE TABLE [tb_local_goods]( [goodsId] INT(20), [barcode] VARCHAR(100), [goods_name] VARCHAR2(100), [abbreviation] VARCHAR2, [data_json] TEXT, [old_data_flag] INT, [product_update_time] DATE); ";
            strSql += "CREATE TABLE [tb_member_recharge]( [member_id] INT, [name] VARCHAR(30), [member_account] VARCHAR(50), [berfore_balance] INT, [after_balance] INT, [create_time] DATETIME, [cloud_state] INT, [reqRechargeJson] TEXT);";
            strSql += "CREATE TABLE [tb_stock_out_base]( [stock_out_id] INT(10) NOT NULL, [serial_number] VARCHAR(50) PRIMARY KEY NOT NULL, [type] TINYINT(3) NOT NULL, [store_id] INT(10) NOT NULL, [whouse_id] INT(10) NOT NULL, [related_order] INT(10) NOT NULL, [client_id] INT(10) NOT NULL DEFAULT '0', [pos_id] INT(10) NOT NULL, [cashier_id] INT(10) NOT NULL, [order_amount] BIGINT(20) DEFAULT NULL, [creator] VARCHAR(20) DEFAULT NULL, [create_time] DATETIME NOT NULL, [update_time] DATETIME DEFAULT NULL, [stock_out_time] DATETIME DEFAULT NULL, [status] TINYINT(3) NOT NULL DEFAULT '0', [remark] VARCHAR(255) DEFAULT NULL, [recieve_fee] INT(20), [change_fee] INT(20), [cloud_state] INT(10), [base_data_json]  TEXT, [cloud_add_flag] INT(10) DEFAULT 0, [cloud_update_flag] INT(10) DEFAULT 0, [cloud_close_flag]  INT DEFAULT 0, [cloud_delete_flag] INT(0), [local_save_flag] INT(10) , [cancael_flag] INT(10) );";
            strSql += "CREATE TABLE [tb_stock_out_detail]( [id] INT(10) NOT NULL, [stock_out_id] INT(10) NOT NULL, [goods_id] INT(10) NOT NULL, [goods_name] VARCHAR(50) NOT NULL, [barcode] VARCHAR(50) NOT NULL, [specification] VARCHAR(20) NOT NULL, [baseUnit] VARCHAR(10) NOT NULL, [produce_time] DATETIME DEFAULT NULL, [expire_time] DATETIME DEFAULT NULL, [order_count] INT(10) NOT NULL, [actual_count] INT(10) DEFAULT NULL, [actual_difference] INT(11) DEFAULT NULL, [unit_price] BIGINT(20) DEFAULT NULL, [subtotal] BIGINT(20)  DEFAULT NULL, [remark] VARCHAR(255) DEFAULT NULL, [serial_number] VARBINARY(50), [cloud_state_add] INT(10), [cloud_state_update] INT(10), [cloud_state_delete] INT(10),[delete_flag] INT(10), [cloud_state] INT(10), [detail_data_json] TEXT);";

            strSql += "CREATE TABLE [tb_local_msg]( [store_whouse_default] TEXT, [pay_type_list] TEXT, [last_all_good_data_uinx_time] INT DEFAULT 0, [post_id] INT  , [system_info] TEXT );";


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
                
                return true;
            }
            return false;
        }
        
        /*********************下单*********************/
        public static bool GenerateOrder(DbStockOutDTO oStockOutDTO)
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
            strSql += "local_save_flag,cancael_flag,";
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
            strSql += "" + oStockOutDTO.Base.TotalPayFee + ",";
            strSql += "" + oStockOutDTO.Base.ChangeFee + ",";
            strSql += "'" + oStockOutDTO.Base.stockOutTime + "',";//以同步给后台的时间为主
            strSql += "'" + oStockOutDTO.Base.baseDataJson + "',";
            strSql += "" + oStockOutDTO.Base.cloudAddFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudUpdateFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudCloseFlag + ",";
            strSql += "" + oStockOutDTO.Base.cloudDeleteFlag + ",";

            strSql += "" + oStockOutDTO.Base.localSaveFlag + ",";
            strSql += "" + oStockOutDTO.Base.cancaelFlag+ ",";
            
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
                strSql += " (id,stock_out_id,serial_number,goods_id,goods_name,barcode,actual_count,cloud_state,specification,baseUnit,order_count,unit_price) VALUES (";
                strSql += " " + item .id + ",";
                strSql += " " + item.stockOutId + ",";
                strSql += " '" + oStockOutDTO.Base.serialNumber + "',";
                strSql += " " + item.goodsId + ",";
                strSql += " '" + item.goodsName + "',";
                strSql += "'" + item.barcode + "',";
                strSql += "" + item.orderCount + ",";
                strSql += "" + item.cloudState + ",";
                strSql += "'" + item.specification + "',";
                strSql += "'" + item.baseUnit + "',";
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
            CommUiltl.Log("本地下单成功");
            return true;
        }



        internal static bool UpdateOrderCloudState(DbStockOutDTO oStockOutDTO)
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



        public static bool updateRetailStock(DbStockOutDTO oStockOutDTO)
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
            strSql += " recieve_fee=" + oStockOutDTO.Base.TotalPayFee + ",";
            strSql += " change_fee=" + oStockOutDTO.Base.ChangeFee + ",";
            strSql += " remark='" + oStockOutDTO.Base.remark + "',";
            strSql += " base_data_json='" + oStockOutDTO.Base.baseDataJson + "',";
            strSql += " cloud_add_flag=" + oStockOutDTO.Base.cloudAddFlag + ",";
            strSql += " cloud_update_flag=" + oStockOutDTO.Base.cloudUpdateFlag + ",";
            strSql += " cloud_close_flag=" + oStockOutDTO.Base.cloudCloseFlag + ",";
            strSql += " cloud_delete_flag=" + oStockOutDTO.Base.cloudDeleteFlag + ",";
            strSql += " cancael_flag=" + oStockOutDTO.Base.cancaelFlag + ",";
            strSql += " local_save_flag=" + oStockOutDTO.Base.localSaveFlag + ",";
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
                strSql += " (id,stock_out_id,serial_number,goods_id,goods_name,barcode,actual_count,specification,baseUnit,order_count,unit_price) VALUES (";
                strSql += " " + item.id + ",";
                strSql += " " + item.stockOutId + ",";
                strSql += " '" + oStockOutDTO.Base.serialNumber + "',";
                strSql += " " + item.goodsId + ",";
                strSql += " '" + item.goodsName + "',";
                strSql += "'" + item.barcode + "',";
                strSql += "" + item.orderCount + ",";
                strSql += "'" + item.specification + "',";
                strSql += "'" + item.baseUnit + "',";
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
        internal static bool GetCloudStateFailedStockOutList(DbStockOutDTO oState,ref List<DbStockOutDTO> oJsonList)
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
                DbStockOutDTO oStockOutDTO = new DbStockOutDTO();
                oStockOutDTO.Base.stockOutId = sqlite_datareader.GetInt64(0);
                oStockOutDTO.Base.serialNumber = sqlite_datareader.GetString(1);
                oStockOutDTO.Base.baseDataJson = sqlite_datareader.GetString(2);
                oJsonList.Add(oStockOutDTO);
            }
            return true;
        }

        //取出某日订单
        internal static bool GetStockOutMsgByDate(DateTime oDate, ref List<DbStockOutDTO> oJsonList)
        {
            string strSql = "";
            strSql += "select stock_out_id,serial_number,base_data_json from tb_stock_out_base ";
            strSql += "where 1=1 ";
            strSql += " and  create_time ";
            strSql += "BETWEEN '"+oDate.ToString("yyyy-MM-dd")+"' AND '"+ oDate.AddDays(1).ToString("yyyy-MM-dd")+"'";
            strSql += " order by create_time desc ";
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
                CommUiltl.Log("sqlite_datareader:" );
                DbStockOutDTO oStockOutDTO = new DbStockOutDTO();
                oStockOutDTO.Base.stockOutId = sqlite_datareader.GetInt64(0);
                oStockOutDTO.Base.serialNumber = sqlite_datareader.GetString(1);
                oStockOutDTO.Base.baseDataJson = sqlite_datareader.GetString(2);
                oJsonList.Add(oStockOutDTO);
            }
            return true;
        }


        //取出最后一笔订单
        internal static bool GetLasStockOutOrder(ref DbStockOutDTO oJson)
        {
            string strSql = "";
            strSql += "select stock_out_id,serial_number,base_data_json from tb_stock_out_base order by create_time desc ";
            strSql += " limit 1 ";
           
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
                oJson.Base.stockOutId = sqlite_datareader.GetInt64(0);
                oJson.Base.serialNumber = sqlite_datareader.GetString(1);
                oJson.Base.baseDataJson = sqlite_datareader.GetString(2);
            }
            return true;
        }
        /*********************支付单*********************/
        internal static bool GeneratePay(DbPayment oPayWay)
        {
            CommUiltl.Log("Dao GenerateOrder");
           
            int iRow = 0;
            //插入订单
            string strSql = "insert into tb_checkout  ";
            strSql += " (id,pos_id,store_id,is_deleted,related_order,serial_number,CashRegisterPayOrderNumber,pay_amount,pay_type,payStatus,create_time,CloudState,reqMemberZfJson,PayCode) VALUES (";
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
            strSql += "'" + oPayWay.reqMemberZfJson + "',";
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
        internal static bool UpdatePayCloudStae(DbPayment oPayWay)
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
        internal static bool memberRecharge(DbPayment oRechargeMember, long beforeMberBalance, long afterMemberAccount, long recieveFee, Member oMermber)
        {
            CommUiltl.Log("Dao memberRecharge");
            int iRow = 0;
            //插入订单
            string strSql = "insert into tb_member_recharge  ";
            strSql += " (member_id,name,member_account,berfore_balance,after_balance,create_time,cloud_state,reqRechargeJson) VALUES (";
            strSql += "'" + oRechargeMember.memberId + "',";
            strSql += "'" + oMermber.name + "',";
            strSql += "'" + oMermber.memberAccount + "',";
            strSql += "" + beforeMberBalance + ",";
            strSql += "" + afterMemberAccount + ",";
            strSql += "datetime('now'),";
            strSql += "" + oRechargeMember.cloudState + ",";
            strSql += "'" + oRechargeMember.reqRechargeJson + "'";
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
        internal static bool GetPayTypeList(ref string json)
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
        //**********************postID
        internal static bool GetPostId(ref int  postId)
        {
            string strSql = "";
            strSql += "select post_id from tb_local_msg ";
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
                CommUiltl.Log("ex:" + ex.ToString());
                return false;
            }

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                if (sqlite_datareader.IsDBNull(0))
                {
                    return false;
                }
                postId = sqlite_datareader.GetInt32(0);
            }
            return true;
        }
        internal static bool SetPostId( int postId)
        {
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_msg set post_id='" + postId + "'";
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

        //**********************默认地址
        internal static bool GetSystemInfo(ref string strSystemInfo)
        {
            string strSql = "";
            strSql += "select system_info from tb_local_msg ";
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
                CommUiltl.Log("ex:" + ex.ToString());
                return false;
            }

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                if (sqlite_datareader.IsDBNull(0))
                {
                    return false;
                }
                strSystemInfo = sqlite_datareader.GetString(0);
            }
            return true;
        }
        internal static bool SetSystemInfo(string strSystemInfo)
        {
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_msg set system_info='" + strSystemInfo + "'";
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
        
        //更新门店信息
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

        //取出默认数据行数
        internal static bool GetLocalMsgDefaultCount(ref int iCount)
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
            strSql += " (store_whouse_default,pay_type_list,post_id,last_all_good_data_uinx_time,system_info) VALUES (";
            strSql += "'',";
            strSql += "'',";
            strSql += "'-1',";
            strSql += "0,";
            strSql += "'" + JsonConvert.SerializeObject(CenterContral.oSystem) + "'";
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
        //***********************本地商品数据*********************/
        internal static bool GetLocalMsgLastUpdateAllDataGoods(out int iLastAllGoodsUpdateTime)
        {
            iLastAllGoodsUpdateTime = 0;
            string strSql = "";
            strSql += "select last_all_good_data_uinx_time from tb_local_msg ";
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
                iLastAllGoodsUpdateTime = sqlite_datareader.GetInt32(0);
            }
            return true;
        }
        internal static bool UpdateLocalMsgLastUpdateAllDataGoods( long iLastAllGoodsUpdateTime)
        {
            int iRow = 0;
            string strSql = "update tb_local_msg set last_all_good_data_uinx_time=" + iLastAllGoodsUpdateTime + "";
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                CommUiltl.Log("UpdateLocalMsgLastUpdateAllDataGoods update fialed sql: " + strSql);
                CommUiltl.Log("UpdateLocalMsgLastUpdateAllDataGoods update fialed ex: " + ex);
                return false;
            }
            if (0 == iRow)
            {
                CommUiltl.Log("UpdateLocalMsgLastUpdateAllDataGoods 0 == iRow " );
                return false;
            }
            CommUiltl.Log("UpdateLocalMsgLastUpdateAllDataGoods ok success");
            return true;
        }
        internal static bool AddGoodsList(List<ProductPricing> list)
        {
            string strSql = "";
            int iRow = 0;
            //插入订单商品数据
            foreach (var item in list)
            {
                item.json= JsonConvert.SerializeObject(item);
                strSql = "INSERT INTO tb_local_goods ";
                strSql += " (goodsId,goods_name,abbreviation,barcode,data_json,old_data_flag,product_update_time) VALUES (";
                strSql += " '" + item.goodsId + "',";
                strSql += " '" + item.goodsName + "',";
                strSql += " '" + item.abbreviation + "',";
                strSql += " '" + item.barcode + "',";
                strSql += " '" + item.json + "',";
                strSql += "'" + 0 + "',";
                strSql += " '" + item.updateTime + "' ";
                strSql += ")";
                sqlite_cmd = sqlite_conn.CreateCommand();

                try
                {
                    sqlite_cmd.CommandText = strSql;
                    iRow = sqlite_cmd.ExecuteNonQuery();
                }

                catch (SQLiteException ex)
                {
                    CommUiltl.Log("AddAllGoods ex:" + ex.ToString());
                   continue;
                }

                if (0 == iRow)
                {
                    CommUiltl.Log("AddAllGoods iRow=0");
                    continue ;
                }
            }
            CommUiltl.Log("AddAllGoods ok count:"+list.Count);
            return true;
        }
        internal static bool UpdateAllGoodsToDelelete()
        {
            ConnecSql();
            CommUiltl.Log("Dao  UpdateAllGoodsToDelelete");
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_goods set   ";
            strSql += " old_data_flag=" + Dao.DELETE_FLAG + " ";

            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                CommUiltl.Log("更新本地数据库操作失败:" + ex.ToString());
                return false;
            }
            CommUiltl.Log("UpdateAllGoodsToDelelete ok");
            return true;
        }
        internal static bool DeleteGoodsWithDeleteFlag()
        {
            ConnecSql();
            CommUiltl.Log("Dao  UpdateAllGoodsToDelelete");
            int iRow = 0;
            //插入订单
            string strSql = "delete from tb_local_goods where   ";
            strSql += " old_data_flag=" + Dao.DELETE_FLAG + " ";

            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                CommUiltl.Log("DeleteAllGoods failded:" + ex.ToString());
                return false;
            }
            CommUiltl.Log("DeleteAllGoods ok");
            return true;
        }
        internal static bool GetGoodsLastUpdateTime(out string strLastUpdateTime)
        {
            strLastUpdateTime = "";
            string strSql = "";
            strSql += "select max(product_update_time) from tb_local_goods ";
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
                if (sqlite_datareader.IsDBNull(0))
                {
                    return false;
                }
                strLastUpdateTime = sqlite_datareader.GetString(0);
            }
            return true;
        }
        internal static bool UpdateGoodsToDeleleteByList(List<ProductPricing> list)
        {
            ConnecSql();
            CommUiltl.Log("Dao  UpdateAllGoodsToDelelete");
            int iRow = 0;
            //插入订单
            string strSql = "update tb_local_goods set   ";
            strSql += " old_data_flag=" + Dao.DELETE_FLAG + " ";
            strSql += " where goodsId in (";
            foreach (var item in list)
            {
                strSql += item.goodsId + ",";
            }
            strSql += "-1";//为了语法统一加上
            strSql += " )";
          
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                CommUiltl.Log("sql: " + strSql);
                sqlite_cmd.CommandText = strSql;
                iRow = sqlite_cmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                CommUiltl.Log("更新本地数据库操作失败:" + ex.ToString());
                return false;
            }
            CommUiltl.Log("UpdateAllGoodsToDelelete ok");
            return true;
        }
        internal static bool GetGoodsByBarcode(string barcode, ref List<String> strListJson )
        {
            string strSql = "";
            strSql += "select  data_json from tb_local_goods  ";
            strSql += "where ";
            strSql += " barcode  like '%" + barcode + "%' ";
            strSql += " or abbreviation like '%" + barcode + "%' ";
            strSql += " or goods_name like  '%" + barcode + "%' ";
            strSql += "   ";

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
                if (sqlite_datareader.IsDBNull(0))
                {
                    CommUiltl.Log("IsDBNull");
                    return false;
                }
                string strJson = sqlite_datareader.GetString(0);
                strListJson.Add(strJson);
            }
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
