using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class PayOrderResp
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public DbStockOutDTO data;
    }
  
}
