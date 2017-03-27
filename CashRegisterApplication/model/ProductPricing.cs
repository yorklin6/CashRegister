using System;
using System.Collections.Generic;
using System.Text;


using System.IO;
using System.Net;

namespace CashRegiterApplication
{
    public class  ProductPricingInfoResp
    {
        public int errorCode { get; set; }
        public string msg { get; set; }

        public ProductPricingData data;
    }

    public class ProductPricingData
    {
        public ProductPricing info;
    }

    public class ProductPricing
    {
        public long BarcodeId { get; set; }

        public String Barcode { get; set; }

        public long BarcodeType { get; set; }

        public long RetailPrice { get; set; }


        public long MemberPrice { get; set; } 

        public String UnitConversion { get; set; }

        public String RetailSpecification { get; set; } 

        public String Unit { get; set; }   

        public long GoodsId { get; set; }


        public String GoodsName { get; set; }

        public long RetailDetailCount { get; set; }
        public long ActualPrice { get; set; }
    }
}
