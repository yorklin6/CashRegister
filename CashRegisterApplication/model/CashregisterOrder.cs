using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class CashregisterOrderResp
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public CashRegisterModelOrderInfo data;
    }

    public class CashRegisterModelOrderInfo
    {
        public int CashRegisterOrderID { get; set; }
        public String CashRegisterOrderNumber { get; set; }
        public int OrderFee { get; set; }
        public int ChangeFee { get; set; }
        public int ReceiveFee { get; set; }
        public int PayType { get; set; }
        public int PayState { get; set; }
    }
}
