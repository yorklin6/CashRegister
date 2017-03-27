using CashRegisterApplication.window;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.comm
{
    
    public class CurrentMsg
    {
        public static CashregisterOrderMsg Order =new CashregisterOrderMsg();//当前订单
        public static List<CashregisterOrderMsg> OrderList = new List<CashregisterOrderMsg>();//全局订单
        public static ProductListWindow Window_ProductList =new ProductListWindow();//全局窗口
        public static RecieveMoneyWindow Window_RecieveMoney = new RecieveMoneyWindow();//收款窗口
        public static ReceiveMoneyByCashWindow Window_ReceiveMoneyByCash = new ReceiveMoneyByCashWindow();//现金收款窗口
        public static RecieveMoneyByWeixinWindow Window_RecieveMoneyByWeixin = new RecieveMoneyByWeixinWindow();//微信收款窗口
        public static List<ProductPricing> ProductPricing = new List<ProductPricing>();//商品列表

        public const int PAY_STATE_INIT=0;
        public const  int PAY_STATE_SUCCESS = 1;

        public const int PAY_TYPE_CASH = 1;

        public const int CLOUD_SATE_ORDER_GENERATE_INIT = 0;
        public const int CLOUD_SATE_ORDER_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_ORDER_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_ORDER_UPDATE_SUCCESS = 3;
        public const int CLOUD_SATE_ORDER_UPDATE_FAILED = 4;

        public const int CLOUD_SATE_PAY_GENERATE_INIT = 0;
        public const int CLOUD_SATE_PAY_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_PAY_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_PAY_UPDATE_SUCCESS = 3;
        public const int CLOUD_SATE_PAY_UPDATE_FAILED = 4;

        public static void ControlWindowsAfterPay()
        {
            CommUiltl.Log("ControlWindowsAfterPay" );
            if (Order.RecieveFee < Order.OrderFee)
            {
                CommUiltl.Log("Window_RecieveMoney Show");
                Window_RecieveMoney.ShowPaidMsg();
                return;
            }
            //Order.RecieveFee >= Order.OrderFee 说明已经收钱完毕
            if (!Dao.CloseOrderWhenPayAllFee())
            {
                return ;
            }
            Window_ProductList.CloseOrderByControlWindow();
        }


        internal static bool GenerateOrder(string strProductList, long orderFee)
        {
           
            Order.OrderFee = orderFee;
            if (Order.OrderNumber == "")
            {
                Order.ProductList = strProductList;
                CommUiltl.Log("Order.OrderCode ==  empty GenerateOrder ");
                Order.generateOrderNumber();
                //插入本地数据库表
                if (!Dao.GenerateOrder())
                {
                    return false;
                }
                if (!HttpUtility.GenerateOrder())
                {
                    Dao.UpdateOrderCloudStae(CLOUD_SATE_ORDER_GENERATE_FAILED);
                    //return false;
                }
                else
                {
                    Dao.UpdateOrderCloudStae(CLOUD_SATE_ORDER_GENERATE_SUCCESS);
                }
               
                return true;
            }

            if ( 0 != Order.ProductList.CompareTo(strProductList)  )
            {
                CommUiltl.Log(" strProductList is modify [" + Order.ProductList + "] -> [" + strProductList + "]");
                Order.ProductList = strProductList;

                if (!Dao.updateOrder())
                {
                    return false;
                }
                if (!HttpUtility.UpdateOrder())
                {
                    Dao.UpdateOrderCloudStae(CLOUD_SATE_ORDER_UPDATE_SUCCESS);
                    //return false;
                }
                else
                {
                    Dao.UpdateOrderCloudStae(CLOUD_SATE_ORDER_UPDATE_FAILED);
                }
              

                return true;
            }
            CommUiltl.Log(" not modify strProductList:"+ strProductList);
            return true;
        }

        internal static bool PayOrderByCash(long recieveFee)
        {

            CurrentMsg.Order.generatePayOrderNumber();
            if (!Dao.PayOrderByCash(recieveFee))
            {
                return false;
            }
            if (!HttpUtility.PayOrderByCash(recieveFee))
            {
                Dao.UpdatePayCloudStae(CLOUD_SATE_ORDER_UPDATE_FAILED);
                //return false;
            }
            else
            {
                Dao.UpdateOrderCloudStae(CLOUD_SATE_ORDER_UPDATE_FAILED);
            }

            Dao.UpdatePayCloudStae(CLOUD_SATE_ORDER_UPDATE_FAILED);
            //修改环境变量，表示这笔单支付成功
            PayWay oPayWay = new PayWay();
            oPayWay.fee = recieveFee;
            oPayWay.payType = PayWay.PAY_TYPE_CASH;
            CurrentMsg.Order.addPayWay(oPayWay);
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            return true;

        }

    }
    
    public class CashregisterOrderMsg
    {
        public  long RecieveFee { get; set; }//已经收款
        public  long OrderFee { get; set; }//订单价钱
        public  long ChangeFee { get; set; }//
        public  int  PayState { get; set; }//
        public  string OrderNumber { get; set; }//订单号
        public  string PayOrderNumber { get; set; }//支付单号
        public  string ProductList { get; set; }//找零
        public  List<PayWay> listPayInfo=new List<PayWay>();

        public CashregisterOrderMsg()
        {
            RecieveFee = 0;
            OrderFee = 0;
            ChangeFee = 0;
            OrderNumber = "";
            PayState = CurrentMsg.PAY_STATE_INIT;
        }

        public  void addPayWay(PayWay oPayWay)
        {
            CommUiltl.Log("RecieveFee before:"+ RecieveFee);
            RecieveFee += oPayWay.fee;
            CommUiltl.Log("RecieveFee after:" + RecieveFee);
            if (RecieveFee > OrderFee)
            {
                ChangeFee = RecieveFee - OrderFee;
            }
          
            listPayInfo.Add(oPayWay);
        }

        public  void generateOrderNumber()
        {
            OrderNumber= "sell-" + DateTime.Now.ToString("yyMMdd-HHmmss");
        }

        public void generatePayOrderNumber()
        {
            PayOrderNumber = "pay-" + DateTime.Now.ToString("yyMMdd-HHmmss");
        }

        public  void Clean()
        {
            RecieveFee = 0;
            OrderFee = 0;
            ChangeFee = 0;
            OrderNumber = "";
            ProductList = "";
            listPayInfo.Clear();
        }

    }

    public class PayWay
    {
        public const int PAY_TYPE_CASH = 1;
        public const string PAY_TYPE_CASH_DESC = "现金";

        public  const int PAY_TYPE_WEIXIN = 2;
        public const string PAY_TYPE_WEIXIN_DESC = "微信支付";

        public  const int PAY_TYPE_ZHIFUBAO = 3;
        public const string PAY_TYPE_ZHIFUBAO_DESC = "支付宝支付";

        public int payType { get; set; }
        public long fee { get; set; }
        public PayWay()
        {
            payType = 0;
            fee = 0;
        }
    }
}
