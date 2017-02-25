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
        public int AutoId { get; set; }   //待定：跟整个商品设计有关系
        
        public int applyID { get; set; }
        
        public int PricingId { get; set; }   //待定：跟整个商品设计有关系 ---原申请单ID；
        
        public int ProductId { get; set; }   //待定：跟整个商品设计有关系
        
        public String ProductName { get; set; }   //待定：跟整个商品设计有关系
        
        public  String ProductSpecification{ get; set; }   //规格
        
        public int    CifPrice{ get; set; }   //价钱尽量以整数位单位！（最小单位为分）平均进货单价
        
        public String CustomerCode{ get; set; }   //客户名称
        
        public  int    ClientID{ get; set; }   //客户
        
        public  int    CoverPrice{ get; set; }   //建议销售价格
        
        public int    LowestPriceLimit { get; set; }   //最低销售价钱
        
        public String  ApplyTime{ get; set; }   // 申请时间
        
        public int             State{ get; set; }   // 审核状态
        
        public String  Dsc{ get; set; }

        
        public String  ProductCode{ get; set; }   //商品条码
        
        public String  SmallUnit{ get; set; }   //小单位
        
        public String  LargeUnit{ get; set; }   //大单位
        
        public int     ExchangeRate{ get; set; }   //换算比例
        
        public int     NormalPrice{ get; set; }   //正常价格
        
        public String  ProductOrigin { get; set; }   //来源地
        
        public int     SuggestedPrice { get; set; }   //建议价钱
        
        public int     TaxRate{ get; set; }   //税率
        
        public String  EffectieTime{ get; set; }   //生效日期
        
        public String  FailureTime{ get; set; }   //失效时期
        
        public String  Comments{ get; set; }   //备注


        //以下从从商品基础信息表中查询，供导出使用
        
        public int purchasePrice{ get; set; }    //采购价
        
        public String productBrand{ get; set; }
        
        public int supplierID{ get; set; }

        
        public String supplierName{ get; set; }


        public int Amount{ get; set; }   
    }
}
