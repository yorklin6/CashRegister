using CashRegisterApplication.model;
using CashRegisterApplication.window;
using CashRegiterApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.comm
{
    
    public static class CurrentMsg
    {
        public static bool initFlag=false;
        public static ProductListWindow Window_ProductList;//全局窗口
        public static RecieveMoneyWindow Window_RecieveMoney;//收款窗口
        public static ReceiveMoneyByCashWindow Window_ReceiveMoneyByCash;//现金收款窗口
        public static RecieveMoneyByWeixinWindow Window_RecieveMoneyByWeixin ;//微信收款窗口

        public static StockOutDTO oStockOutDTO ;//商品列表
        public static List<PayWay> listPayInfo ;
        public static StockOutDTORespone oStockOutDToRespond;
        public static HttpBaseRespone oHttpRespone;

        public static PayWay oPayWay = new PayWay();//商品列表
        
        public const int PAY_STATE_INIT=0;
        public const  int PAY_STATE_SUCCESS = 1;
        public const int PAY_TYPE_CASH = 1;

     

        public const int STOCK_BASE_STATUS_INIT = 0;
        public const int STOCK_BASE_STATUS_NORMAL = 1;
        public const int STOCK_BASE_STATUS_OUT = 2;



        public const int CLOUD_SATE_PAY_SUCESS = 0;
        public const int CLOUD_SATE_PAY_FAILD = 0;
        //public const int CLOUD_SATE_ORDER_GENERATE_INIT = 0;
        //public const int CLOUD_SATE_ORDER_GENERATE_SUCCESS = 1;//云端生成订单成功
        //public const int CLOUD_SATE_ORDER_GENERATE_FAILED = 2;

        //public const int CLOUD_SATE_ORDER_UPDATE_SUCCESS = 3;//云端更新订单成功
        //public const int CLOUD_SATE_ORDER_UPDATE_FAILED = 4;

        //public const int CLOUD_SATE_ORDER_CLOSE_SUCCESS = 5;//云端关闭订单成功
        //public const int CLOUD_SATE_ORDER_CLOSE_FAILED = 6;

        public const int CLOUD_SATE_PAY_GENERATE_INIT = 0;
        public const int CLOUD_SATE_PAY_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_PAY_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_PAY_UPDATE_SUCCESS = 3;
        public const int CLOUD_SATE_PAY_UPDATE_FAILED = 4;

        public static void Init()
        {
            if (initFlag)
            {
                return;
            }

            //Window_ProductList = new ProductListWindow();//全局窗口
            Window_RecieveMoney = new RecieveMoneyWindow();//收款窗口
            Window_ReceiveMoneyByCash = new ReceiveMoneyByCashWindow();//现金收款窗口
            Window_RecieveMoneyByWeixin = new RecieveMoneyByWeixinWindow();//微信收款窗口

            oStockOutDTO = new StockOutDTO();//商品列表
            listPayInfo = new List<PayWay>();
            oStockOutDToRespond = new StockOutDTORespone();
            oHttpRespone = new HttpBaseRespone();
            initFlag = true;
        }



        public static void Clean()
        {
            listPayInfo.Clear();
            oStockOutDTO.Base.Reset();
            oStockOutDTO.details.Clear();
            oStockOutDToRespond = new StockOutDTORespone();
        }


        public static void ControlWindowsAfterPay()
        {
            CommUiltl.Log("ControlWindowsAfterPay" );
            if (CurrentMsg.oStockOutDTO.Base.RecieveFee < CurrentMsg.oStockOutDTO.Base.orderAmount)
            {
                CommUiltl.Log("Window_RecieveMoney Show");
                Window_RecieveMoney.ShowPaidMsg();
                return;
            }
            //Order.RecieveFee >= Order.orderAmount 说明已经收钱完毕
            if (!CloseOrderWhenPayAllFee())
            {
                return ;
            }
            Window_ProductList.CloseOrderByControlWindow();
        }

        internal static bool CloseOrderWhenPayAllFee()
        {
            CurrentMsg.oStockOutDTO.Base.status = STOCK_BASE_STATUS_OUT;

            CurrentMsg.oStockOutDTO.Base.cloudCloseFlag = HttpUtility.CloseOrderWhenPayAllFee(CurrentMsg.oStockOutDTO, ref CurrentMsg.oHttpRespone);
            
            if (!Dao.UpdateOrderCloudState(CurrentMsg.oStockOutDTO))
            {
                return false;
            }
            return true;
        }

        internal static bool GenerateOrder(string strProductList, long orderFee)
        {
           
            CurrentMsg.oStockOutDTO.Base.orderAmount = orderFee;
            if (CurrentMsg.oStockOutDTO.Base.status == CurrentMsg.STOCK_BASE_STATUS_INIT)
            {
                CurrentMsg.oStockOutDTO.Base.ProductList = strProductList;
                CommUiltl.Log("Order.OrderCode ==  empty GenerateOrder ");
                CurrentMsg.oStockOutDTO.Base.generateSeariseNumber();

                CurrentMsg.oStockOutDTO.Base.cloudAddFlag = HttpUtility.GenerateOrder(CurrentMsg.oStockOutDTO, ref CurrentMsg.oStockOutDToRespond);

                if(CurrentMsg.oStockOutDTO.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS )
                {
                    CurrentMsg.oStockOutDTO.Base.stockOutId = CurrentMsg.oStockOutDToRespond.data.Base.stockOutId;
                    SetStockDetailByHttpRespone(oStockOutDToRespond.data,ref CurrentMsg.oStockOutDTO );

                }else
                {
                    CurrentMsg.oStockOutDTO.Base.cloudReqJson = JsonConvert.SerializeObject(CurrentMsg.oStockOutDTO);
                }
                //插入本地数据库表
                if (!Dao.GenerateOrder(CurrentMsg.oStockOutDTO))
                {
                    return false;
                }
                return true;
            }

            if (strProductList != null && 0 != CurrentMsg.oStockOutDTO.Base.ProductList.CompareTo(strProductList))
            {
                CommUiltl.Log(" strProductList is modify [" + CurrentMsg.oStockOutDTO.Base.ProductList + "] -> [" + strProductList + "]");
                CurrentMsg.oStockOutDTO.Base.ProductList = strProductList;
                CurrentMsg.oStockOutDTO.Base.cloudUpdateFlag = HttpUtility.updateRetailStock(CurrentMsg.oStockOutDTO, ref CurrentMsg.oStockOutDToRespond);

                if (CurrentMsg.oStockOutDTO.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    
                }else
                {
                    CurrentMsg.oStockOutDTO.Base.cloudReqJson = JsonConvert.SerializeObject(CurrentMsg.oStockOutDTO);
                }

                if (!Dao.updateRetailStock(CurrentMsg.oStockOutDTO))
                {
                    return false;
                }

                return true;
            }
            CommUiltl.Log(" not modify strProductList:"+ strProductList);
            return true;
        }
        internal static void SetStockDetailByHttpRespone(StockOutDTO http,ref StockOutDTO Db)
        {
            if (oStockOutDToRespond.data.details.Count != CurrentMsg.oStockOutDTO.details.Count)
            {
                //说明是有问题的
                CommUiltl.Log("oRespond.data.details.Count[" + oStockOutDToRespond.data.details.Count + "] != CurrentMsg.oStockOutDTO.details.Count [" + CurrentMsg.oStockOutDTO.details.Count + "]");
                MessageBox.Show("下单异常，请联系后台同学检查下单返回[" + oStockOutDToRespond.data.details.Count + "] != CurrentMsg.oStockOutDTO.details.Count [" + CurrentMsg.oStockOutDTO.details.Count + "]");
            }
            else
            {
                for (int i = 0; i < oStockOutDToRespond.data.details.Count; ++i)
                {
                    CurrentMsg.oStockOutDTO.details[i].id = oStockOutDToRespond.data.details[i].id;
                }
            }
        }
        internal static bool PayOrderByCash(long recieveFee)
        {
            CurrentMsg.oPayWay.payType = PAY_TYPE_CASH;
            CurrentMsg.oPayWay.payFee = recieveFee;
            CurrentMsg.oPayWay.generatePayOrderNumber();
            CurrentMsg.oPayWay.serialNumber = CurrentMsg.oStockOutDTO.Base.serialNumber;
            CurrentMsg.oPayWay.payStatus=  CurrentMsg.PAY_STATE_SUCCESS;
            CurrentMsg.oPayWay.cloudState = CurrentMsg.CLOUD_SATE_PAY_SUCESS ;

            CurrentMsg.oPayWay.cloudState = HttpUtility.PayOrdr(CurrentMsg.oPayWay);

            if (!Dao.GeneratePay(CurrentMsg.oPayWay))
            {
                return false;
            }
            //修改环境变量，表示这笔单支付成功
            PayWay oPayWay = new PayWay();
            CurrentMsg.oStockOutDTO.addPayWay(CurrentMsg.oPayWay);
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            return true;

        }

    }
  
}
