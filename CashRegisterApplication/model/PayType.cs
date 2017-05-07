using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class PayTypeHttpRespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public PayTypeData data;
    }
    public class PayTypeData
    {
        public List<PayType> list;
    }
    public class PayType
    {
        public int payTypeId { get; set; }
        public String description { get; set; }
        public Byte isDeleted { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }

}
