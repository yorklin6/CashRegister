using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class PostIdRespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public PostIdData data;
    }
    public class PostIdData
    {
        public int postId { get; set; }
    }
    
}
