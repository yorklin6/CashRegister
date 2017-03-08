using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    public class CurrentOrderMsg
    {
        public static OrderMsg order;
        public static void Clean()
        {
            order.RecieveFee = 0;
            order.OrderFee = 0;
            order.listPayInfo.Clear();
        }
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
