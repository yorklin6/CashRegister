using CashRegisterApplication.model;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    //异步处理数据库
    class TimerTask
    {
        public static void AddStaockOut()
        {
            StockOutBase Base = new StockOutBase();
            List<StockOutDTO> oJsonList = new List<StockOutDTO>();

            Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            if (!Dao.GetCloudStateFailedStockOutList(Base, ref oJsonList))
            {
               
            }
        }
    }
}
