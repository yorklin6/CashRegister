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
        public long RetailBaseId { get; set; }
        public String RetailBaseSerialNumber { get; set; }
        public long PayState { get; set; }
        public long StoreId { get; set; }
        public long WhouseId { get; set; }
        public long CashierId { get; set; }
        public long PosId { get; set; }
        public long RetailTotalFee { get; set; }
        public long ReceiveFee { get; set; }
    }
}
