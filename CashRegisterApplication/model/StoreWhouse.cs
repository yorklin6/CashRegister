using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{

    public class StoreWhouseRespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public StoreWhouseData data;
    }
    public class StoreWhouseData
    {
        public List<StoreWhouse> list;
    }
    public class StoreWhouse
    {
        public long memberId { get; set; }


        public int storeWhouseId { get; set; }

        public int storeId { get; set; }

        public int type { get; set; }

        public String name { get; set; }

        public String storeName { get; set; }

        public String address { get; set; }

        public String phone { get; set; }

        public String fax { get; set; }

        public Byte negativeStock { get; set; }

        public String payType { get; set; }
        /** 支持的付款方式描述(只用于前端显示) */
        public String payTypeDesc { get; set; }

        public Byte isDeleted { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
    }
    public class ComboxItem
    {
        private string text;
        private string values;

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        public ComboxItem(string _Text, string _Values)
        {
            Text = _Text;
            Values = _Values;
        }


        public override string ToString()
        {
            return Text;
        }
    }

}
