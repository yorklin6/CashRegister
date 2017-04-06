using CashRegisterApplication.model;
using CashRegiterApplication;
using Newtonsoft.Json;
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
                try
                {
                    StockOutDTO oTmp = JsonConvert.DeserializeObject<StockOutDTO>(item.Base.cloudReqJson);
                    oStockList.Add(oTmp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("DeserializeObject content error ,and coanot parse:" + e + " conten:" + item.Base.cloudReqJson);
                }
            }
            //http redo
            foreach (var oStock in oStockList)
            {
                StockOutDTORespone oResp =new StockOutDTORespone();
                oStock.Base.cloudAddFlag = HttpUtility.GenerateOrder(oStock, ref oResp);

                if (oStock.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    oStock.Base.stockOutId = oResp.data.Base.stockOutId;
                    if (oResp.data.details.Count != oStock.details.Count)
                    {
                        //说明是有问题的
                        CommUiltl.Log("oRespond.data.details.Count[" + oResp.data.details.Count + "] != CurrentMsg.oStockOutDTO.details.Count [" + oStock.details.Count + "]");
                        continue;
                    }

                    for (int i = 0; i < oStock.details.Count; ++i)
                    {
                        oStock.details[i].id = oResp.data.details[i].id;
                    }
                    //更新数据库，这个流水单下面的id全部变成云端返回的id，以云端的为主。
                    oStock.Base.cloudUpdateFlag = HttpUtility.CLOUD_SATE_HTTP_SUCESS;
                    Dao.updateRetailStock(oStock);
                }
                else
                {
                    CurrentMsg.oStockOutDTO.Base.cloudReqJson = JsonConvert.SerializeObject(CurrentMsg.oStockOutDTO);
                }
               
            }
          
        }
    }
}
