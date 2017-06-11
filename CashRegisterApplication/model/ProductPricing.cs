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
        public int unitConversion { get; set; }
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
        public String creator { get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }

        public String json { get; set; }
        public String keyWord { get; set; }//keyword
        //        barcode: "9556247516480",
        //baseUnit: "盒",
        //bigUnit: "箱",
        //brand: "倍乐思",
        //categoryId: 1,
        //createTime: "2017-03-28 11:22:48",
        //goodsId: 64,
        //goodsName: "倍乐思提拉米苏杏仁白巧克力120g",
        //marketingType: 1,
        //memberExclusive: 0,
        //memberPrice: 220000,
        //produceAddress: "马来西亚",
        //purchasePrice: 220000,
        //remark: "",
        //retailPrice: 220000,
        //specification: "120*12",
        //status: 1,
        //supplierId: 86,
        //supplierName: "深圳市江山宏达工贸有限公司",
        //unitConversion: 12,
        //validity: 365

        //        public long goodsId;
        //        public String goodsName;
        //        public String abbreviation;
        //        public String baseUnit;
        //        public String bigUnit;
        //        public Short unitConversion;
        //        public String specification;
        //        public String barcode;
        //        public String brand;
        //        public String produceAddress;
        //        public long supplierId;
        //        public String supplierName;
        //        public long validity;
        //        public long categoryId;
        //        public String categoryName; //商品类别名称(在通过Id获取商品信息时查询设置)
        //        public long retailPrice;
        //        public long memberPrice;
        //        public long purchasePrice;
        //        public Double grossMargin;
        //        public long priceType;
        //        public Double incomeTaxRate;
        //        public long stockPrice;
        //        public long marketingType;
        //        public Double shoppeRate;
        //        public long memberExclusive;
        //        public Double pointCoefficient;
        //        public long weighType;
        //        public long safetyStock;
        //        public long status;
        //        public String remark;
        //        public String creator;
        //        public Timestamp createTime;
        //        public Timestamp updateTime;
    }
}
