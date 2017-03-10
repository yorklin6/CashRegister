using CashRegisterApplication.window;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    public class CurrentMsg
    {
        public static OrderMsg Order =new OrderMsg();//全局订单
        public static ProductListWindow ProductListWindows =new ProductListWindow();//全局窗口
        public static RecieveMoneyWindow RecieveMoneyWindows = new RecieveMoneyWindow();//收款窗口
        public static ReceiveMoneyByCashWindow ReceiveMoneyByCash = new ReceiveMoneyByCashWindow();//现金收款窗口
        public static RecieveMoneyByWeixinWindow RecieveMoneyByWeixin = new RecieveMoneyByWeixinWindow();//微信收款窗口
    }
    
    public class OrderMsg
    {
        public  int RecieveFee { get; set; }//收款
        public  int OrderFee { get; set; }//订单价钱
        public  int ChangeFee { get; set; }//找零
        public  List<PayWay> listPayInfo;

        public OrderMsg()
        {
            RecieveFee = 0;
            OrderFee = 0;
            ChangeFee = 0;
        }
        public  void addPayWay(PayWay oPayWay)
        {
            RecieveFee += oPayWay.payFee;
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

        public int payWayType { get; set; }
        public int payFee { get; set; }
        public PayWay()
        {
            payWayType = 0;
            payFee = 0;
        }
    }
}
