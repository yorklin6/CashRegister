using CashRegisterApplication.window;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    
    public class CurrentMsg
    {
        public static OrderMsg Order =new OrderMsg();//当前订单
        public static List<OrderMsg> OrderList = new List<OrderMsg>();//全局订单
        public static ProductListWindow Window_ProductList =new ProductListWindow();//全局窗口
        public static RecieveMoneyWindow Window_RecieveMoney = new RecieveMoneyWindow();//收款窗口
        public static ReceiveMoneyByCashWindow Window_ReceiveMoneyByCash = new ReceiveMoneyByCashWindow();//现金收款窗口
        public static RecieveMoneyByWeixinWindow Window_RecieveMoneyByWeixin = new RecieveMoneyByWeixinWindow();//微信收款窗口

        public static void ControlWindowsAfterPay()
        {
            CommUiltl.Log("ControlWindowsAfterPay" );
            if (Order.RecieveFee < Order.OrderFee)
            {
                CommUiltl.Log("Window_RecieveMoney Show");
                Window_RecieveMoney.Show();
                Window_RecieveMoney.ShowPaidMsg();
                return;
            }
            //Order.RecieveFee >= Order.OrderFee
            Window_ProductList.Show();
            Window_ProductList.CloseOrder();
        }


    }
    
    public class OrderMsg
    {
        public  int RecieveFee { get; set; }//已经收款
        public  int OrderFee { get; set; }//订单价钱
        public  int ChangeFee { get; set; }//找零
        public  List<PayWay> listPayInfo=new List<PayWay>();

        public OrderMsg()
        {
            RecieveFee = 0;
            OrderFee = 0;
            ChangeFee = 0;
        }
        public  void addPayWay(PayWay oPayWay)
        {
            CommUiltl.Log("RecieveFee before:"+ RecieveFee);
            RecieveFee += oPayWay.fee;
            CommUiltl.Log("RecieveFee after:" + RecieveFee);
            ChangeFee = RecieveFee - OrderFee;
            listPayInfo.Add(oPayWay);
        }
        public  void Clean()
        {
            RecieveFee = 0;
            OrderFee = 0;
            ChangeFee = 0;
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
        public int fee { get; set; }
        public PayWay()
        {
            payType = 0;
            fee = 0;
        }
    }
}
