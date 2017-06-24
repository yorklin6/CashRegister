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
        public void MyTimer_Tick(object sender, EventArgs e)
        {
            CommUiltl.Log("SetTimerTask ");
            MyTimerTask.Run();
        }
        public static void Run()
        {
            CommUiltl.Log("UpdateLocalGoodsMsg ");
            _UpdateAllGoodsdate();
            _UpdateLastGoodMsg();
            CloseStaockOut();
        }
        public static void _UpdateLastGoodMsg()
        {
            string strLastUpdateTime = "";
            if (!Dao.GetGoodsLastUpdateTime(out strLastUpdateTime))
            {
                CommUiltl.Log("_UpdateLastGoodMsg GetGoodsLastUpdateTime error");
                return;
            }
            if (strLastUpdateTime =="")
            {
                return;
            }
            CommUiltl.Log("_UpdateLastGoodMsg strLastUpdateTime:"+ strLastUpdateTime);
            List<ProductPricing> list = new List<ProductPricing>();
            if (!HttpUtility.GetGoodsLastUpdate(strLastUpdateTime,ref list))
            {
                CommUiltl.Log("_UpdateLastGoodMsg GetGoodSlastUpdate error");
                return;
            }
            if (list.Count ==0 )
            {
                CommUiltl.Log("_UpdateLastGoodMsg list.Count ==0");
                return;
            }
            //老数据打上 老数据标志
            Dao.UpdateGoodsToDeleleteByList(list);
            //插入新数据
            Dao.AddGoodsList(list);
            //删除 老数据标志 的商品
            Dao.DeleteGoodsWithDeleteFlag();
        }
        public static void _UpdateAllGoodsdate()
        {
            //查db里面,最后一次更新时间是多少
            int iLastAllGoodsUpdateTime = 0;
            if (!Dao.GetLocalMsgLastUpdateAllDataGoods(out iLastAllGoodsUpdateTime))
            {
                CommUiltl.Log("GetLocalMsgLastUpdateAllDataGoods error");
                return;
            }
            long iNow = CommUiltl.GetTimeStamp();
            long diff = iNow - iLastAllGoodsUpdateTime;
            CommUiltl.Log("diff:" + diff + " iNow:" + iNow + " iLastAllGoodsUpdateTime:" + iLastAllGoodsUpdateTime);
            //一天拉一次全量
            if (iLastAllGoodsUpdateTime != 0 && diff < 24 * 60 * 60)
            {
                CommUiltl.Log("UpdateLocalGoodsMsg:no need update data");
                return;
            }
            _UpdateAllGoods();
            //记录今天已经更新全量信息
            Dao.UpdateLocalMsgLastUpdateAllDataGoods(iNow);
        }
        public static void _UpdateAllGoods()
        {
            //拉出全量商品数据
            int page = 1, pageSize=100;
            List<ProductPricing> list = new List<ProductPricing>();
            for (; page<10000; ++page)
            {
                //拉商品定价信息
                ProductPricingInfoResp oProductPricingInfoResp = new ProductPricingInfoResp();
                if (!HttpUtility.GetAllProduct(page, pageSize, ref oProductPricingInfoResp))
                {
                    CommUiltl.Log("_UpdateAllGoodsdate GetAllProduct err ");
                    //拉取错误
                    continue;
                }
                CommUiltl.Log("oProductPricingInfoResp.data.list count " + oProductPricingInfoResp.data.list.Count);
                CommUiltl.Log("list count " + list.Count);
                //等到list为空
                if (oProductPricingInfoResp.data.list.Count == 0)
                {
                    break;
                }
                list.AddRange(oProductPricingInfoResp.data.list);
                CommUiltl.Log("oProductPricingInfoResp.data.list count " + oProductPricingInfoResp.data.list.Count);
             
            }

            //全量数据商品少于5个的时候，表示数据有问题，不删除
            if (list.Count < 2)
            {
                return;
            }
            //老数据打上 老数据标志
            Dao.UpdateAllGoodsToDelelete();
            //插入新数据
            Dao.AddGoodsList(list);
            //删除 老数据标志 的商品
            Dao.DeleteGoodsWithDeleteFlag();
            return;
        }

        //关闭单(结算订单)
        public static void CloseStaockOut()
        {
            List<StockOutDTO> oStockList = new List<StockOutDTO>();
            StockOutDTO oState = new StockOutDTO();
            oState.Base.cloudCloseFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            GetStockOutPutByDbWithCloudeState(oState, ref oStockList);
            //http redo
            foreach (var oStock in oStockList)
            {
                CommUiltl.Log("CloseStaockOut serialNumber:" + oStock.Base.serialNumber);
                HttpBaseRespone oRespond = new HttpBaseRespone();
                string strDataJson = oStock.Base.baseDataJson;
                oStock.Base.baseDataJson = "";
                oStock.Base.cloudCloseFlag = HttpUtility.RetailSettlementByTask(oStock, ref oRespond);
                if (oStock.Base.cloudCloseFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    oStock.Base.baseDataJson = JsonConvert.SerializeObject(oStock);
                    Dao.UpdateOrderCloudState(oStock);
                }
                else
                {
                    //重试失败，则不管，后面队列继续重试
                }
            }
        }//CloseStaockOut

        public static void AddStaockOut()
        {
            List<StockOutDTO> oStockList = new List<StockOutDTO>();
            StockOutDTO oState = new StockOutDTO();
            oState.Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;

            GetStockOutPutByDbWithCloudeState(oState, ref oStockList);

            //http redo
            foreach (var oStock in oStockList)
            {
                StockOutDTORespone oResp =new StockOutDTORespone();
               oStock.Base.cloudAddFlag = HttpUtility.GenerateOrder(oStock, ref oResp);

                if (oStock.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    //重试成功
                    oStock.Base.stockOutId = oResp.data.Base.stockOutId;
                    if (oResp.data.details.Count != oStock.details.Count)
                    {
                        //说明是有问题的
                        CommUiltl.Log("oRespond.data.details.Count[" + oResp.data.details.Count + "] != Main.oStockOutDTO.details.Count [" + oStock.details.Count + "]");
                        continue;
                    }

                    for (int i = 0; i < oStock.details.Count; ++i)
                    {
                        //更新数据库，这个流水单下面的id全部变成云端返回的id，以云端的为主。
                        oStock.details[i].id = oResp.data.details[i].id;
                    }
                    oStock.Base.cloudUpdateFlag = HttpUtility.CLOUD_SATE_HTTP_SUCESS;//新增成功，相当于无需更新
                    Dao.updateRetailStock(oStock);
                }
                else
                {
                    //重试失败，则不管，后面队列继续重试
                }
               
            }

        }//AddStaockOut

        //修改零售单
        public static void UpdateStaockOut()
        {
            List<StockOutDTO> oStockList = new List<StockOutDTO>();

            StockOutDTO oState = new StockOutDTO();
            oState.Base.cloudUpdateFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;

            GetStockOutPutByDbWithCloudeState(oState, ref oStockList);
            //http redo
            foreach (var oStock in oStockList)
            {
                StockOutDTORespone oResp = new StockOutDTORespone();
                oStock.Base.cloudUpdateFlag = HttpUtility.updateRetailStock(oStock, ref oResp);

                if (oStock.Base.cloudUpdateFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    for (int i = 0; i < oStock.details.Count; ++i)
                    {

                       // oStock.details[i].id = oResp.data.details[i].id;
                    }
                    Dao.updateRetailStock(oStock);
                }
                else
                {
                    //重试失败，则不管，后面队列继续重试
                }
            }

        }//UpdateStaockOut

        //删除零售单
        public static void DeleteStaockOut()
        {
            //List<StockOutDTO> oStockList = new List<StockOutDTO>();
            //StockOutBase Base = new StockOutBase();
            //Base.cloudDeleteFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            //GetStockOutPutByDbWithCloudeState(Base, ref oStockList);
            ////http redo
            //foreach (var oStock in oStockList)
            //{
            //    StockOutDTORespone oResp = new StockOutDTORespone();
            //    oStock.Base.cloudUpdateFlag = HttpUtility.updateRetailStock(oStock, ref oResp);

            //    if (oStock.Base.cloudUpdateFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            //    {
            //        for (int i = 0; i < oStock.details.Count; ++i)
            //        {

            //            // oStock.details[i].id = oResp.data.details[i].id;
            //        }
            //        Dao.updateRetailStock(oStock);
            //    }
            //    else
            //    {
            //        //重试失败，则不管，后面队列继续重试
            //    }
            //}

        }//DeleteStaockOut

     

        public static void GetStockOutPutByDbWithCloudeState(StockOutDTO oState, ref List<StockOutDTO> oStockList)
        {
            List<StockOutDTO> oJsonList = new List<StockOutDTO>();
            //取出数据
            if (!Dao.GetCloudStateFailedStockOutList(oState, ref oJsonList))
            {
                return;
            }
            CommUiltl.Log("Count:" + oJsonList.Count);
            if (0 == oJsonList.Count)
            {
                return;
            }
            //把json数据还原成obj
            foreach (var item in oJsonList)
            {
                try
                {
                    StockOutDTO oTmp = JsonConvert.DeserializeObject<StockOutDTO>(item.Base.baseDataJson);
                    oStockList.Add(oTmp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("DeserializeObject content error ,and coanot parse:" + e + " conten:" + item.Base.baseDataJson);
                    continue;
                }
            }
        }

    }
}
