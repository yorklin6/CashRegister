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
    public class GooodsLastUpdateResp
    {
        public int errorCode { get; set; }
        public string msg { get; set; }

        public List<ProductPricing> data;
    }
    public class ProductPricingData
    {
        public List<ProductPricing> list;
    }

    public class ProductPricing
    {
       

        //public long goodsId { get; set; }
        //public String Barcode { get; set; }

        //public long BarcodeType { get; set; }

        //public long retailPrice { get; set; }


        //public long memberPrice { get; set; } 

        //public String UnitConversion { get; set; }

        //public String specification { get; set; } 

        //public String bigUnit { get; set; }
        //public String baseUnit { get; set; }

        //public String goodsName { get; set; }

        //public long RetailDetailCount { get; set; }
        //public long ActualPrice { get; set; }


        public long goodsId { get; set; }
        public String goodsName { get; set; }
        public String abbreviation { get; set; }
        public String baseUnit { get; set; }
        public String bigUnit { get; set; }
        public long unitConversion { get; set; }
        public String specification { get; set; }
        public String barcode { get; set; }
        public String brand { get; set; }
        public String produceAddress { get; set; }
        public long supplierId { get; set; }
        public String supplierName { get; set; }
        public long validity { get; set; }
        public long categoryId { get; set; }
        public String categoryName { get; set; } //商品类别名称(在通过Id获取商品信息时查询设置)
        public long retailPrice { get; set; }
        public long memberPrice { get; set; }
        public long purchasePrice { get; set; }
        public Double grossMargin { get; set; }
        public long priceType { get; set; }
        public Double incomeTaxRate { get; set; }
        public long stockPrice { get; set; }
        public long marketingType { get; set; }
        public Double shoppeRate { get; set; }
        public long memberExclusive { get; set; }
        public Double pointCoefficient { get; set; }
        public long weighType { get; set; }
        public long safetyStock { get; set; }
        public long status { get; set; }

        public String remark { get; set; }
        public long isDeleted { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }

        public String creator { get; set; }
        public String json { get; set; }

        public String postKeyWord { get; set; }//postKeyWord，用户输入的关键词
        public String reqKeyWord { get; set; }//searchKeyWord向后台或者本地请求，输入的关键词

        public int isBarCodeMoneyGoods { get; set; }//是否是条码带金额类商品，默认0不是,1是代表是扫码商品
        public long barcodeSubTotalMoney { get; set; }//条码中自带的金额数，当isBarCodeMoneyGoods字段为1时候生效
        public long barcodeCount { get; set; }//条码中自带的金额数,需要重新计算计重数

    }
}
