using CashRegisterApplication.model;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    //异步处理数据库
    class MyTimerTask
    {
        public static void AddStaockOut()
        {
            StockOutBase Base = new StockOutBase();
            List<StockOutDTO> oJsonList = new List<StockOutDTO>();

            Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            //取出数据
            if (!Dao.GetCloudStateFailedStockOutList(Base, ref oJsonList))
            {
                return;
            }
            CommUiltl.Log("Count:" + oJsonList.Count);
            if (0 == oJsonList.Count)
            {
                return;
            }
            //把json数据还原成obj
            List<StockOutDTO> oStockList = new List<StockOutDTO>();
            foreach(var item in oJsonList)
            {
                StockOutDTO oProductPricing = JsonConvert.DeserializeObject<StockOutDTO>(strJson);
            }
        }
    }
}
