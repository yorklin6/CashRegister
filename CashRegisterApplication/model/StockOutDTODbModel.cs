using System;
using System.Collections.Generic;
using System.Text;
using CashRegisterApplication.comm;
using CashRegiterApplication;

namespace CashRegisterApplication.model
{
    //这个文件是保存db里面的结构，如果添加字段，有必要修改修改StockOutDTOHttpModel
    public class DbStockOutDTORespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public DbStockOutDTO data;
    }

    public class LocalSaveStock
    {
        public List<DbStockOutDTO> listStock;
        public int index { get; set; }
        public LocalSaveStock()
        {
            index = 0;
            listStock = new List<DbStockOutDTO>();
        }
    }

    public class DbSaveStock
    {
        public  List<DbStockOutDTO> listStock;
        public  int index { get; set; }
        public DbSaveStock()
        {
            index = 0;
            listStock = new List<DbStockOutDTO>();
        }
    }

    public class DbStockOutDTO
    {
        //这个文件是保存db里面的结构，如果添加字段，有必要修改修改StockOutDTOHttpModel
        public DbStockOutBase Base;

        public List<DbStockOutDetail> details;
        public List<DbCheckout> checkouts;
        public Member oMember;
        
        public DbStockOutDTO()
        {
            Base = new DbStockOutBase();
            details = new List<DbStockOutDetail>();
            checkouts = new List<DbCheckout>();
         
            oMember = new Member();
 
        }

        public void addChecout(DbCheckout oPayWay)
        {
            CommUiltl.Log("RecieveFee before:" + Base.TotalPayFee);
            Base.TotalPayFee += oPayWay.payAmount;
            CommUiltl.Log("RecieveFee after:" + Base.TotalPayFee);
            CaculateFee();
            checkouts.Add(oPayWay);
          
        }

        public void CaculateFee()
        {
            //计算找零价钱和实收价钱
            Base.ChangeFee = Base.TotalPayFee - Base.orderAmount;
            Base.RealRecieveFee = Base.TotalPayFee;
            if (Base.RealRecieveFee> Base.orderAmount)
            {
                Base.RealRecieveFee = Base.orderAmount;
            }
        }
    }


    public class PayWayHttpRequet
    {
        public long memberId { get; set; }

        public int tradeTime { get; set; }

        public List<DbCheckout> list;
        public PayWayHttpRequet()
        {
            memberId = 0;
            tradeTime = 0;
            list = new List<DbCheckout>();
        }
    }

    public class DbCheckout
    {
        //这个文件是保存db里面的结构，如果添加字段，有必要修改修改StockOutDTOHttpModel
        public int payType { get; set; }
        public long payAmount { get; set; }

        public string stockOutSerialNumber { get; set; }

        public string serialNumber { get;  set; }
        public int cloudState { get; set; }
        public int id { get; set; }
        public int posId { get; set; }
        public int payStatus { get; set; }
        public long relatedOrder { get; set; }
        public long storeId { get; set; }
        public int isDeleted { get; set; }

        public string reqMemberZfJson { get; set; }

        public string  payTypeDesc { get; set; }

        public DbCheckout()
        {
            id = 0;
            payType = 0;
            payAmount = 0;
            payStatus = 0;
            cloudState = 0;
            serialNumber = "";
            stockOutSerialNumber = "";
            posId = CenterContral.iPostId;
        }

        internal void generatePayOrderNumber()
        {
            serialNumber = "JZ-"+CenterContral.oStoreWhouse.storeWhouseId + "-"
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") +"-"+ CommUiltl.GetRandomNumber();
        }
    }
  
    public class DbStockOutBase
    {

        //这个文件是保存db里面的结构，如果添加字段，有必要修改修改StockOutDTOHttpModel
        public String serialNumber { get; set; }
        public long storeId { get; set; }
        public long whouseId { get; set; }
        public String whouseName { get; set; }
        public long clientId { get; set; }//会员id
        public String clientName { get; set; }//会员id
        public long posId { get; set; }
        public long cashierId { get; set; }//收银员id，也就是登陆者
        public String cashierName { get; set; }//收银员，也就是登陆者
        public String deskNumber { get; set; }
        public long orderAmount { get; set; }//订单总金额
        public long walletHistoryId { get; set; }//关联的钱包支付Id
        public String remark { get; set; }
        public String orderTime { get; set; }
        public String createTime { get; set; }
       
        public long discountAmount { get; set; } // 折扣额度
        public long discountRate { get; set; } // 折扣率

        //************本地缓存数据
        public long TotalPayFee { get; set; }
        public long RealRecieveFee { get; set; }//实收多少钱
        public String ProductList { get; set; }//辅助变量，帮助查看商品列表是否有修改
        public long ChangeFee { get; set; }

        public long totalProductCount { get; set; }//总件数

        public String baseDataJson { get; set; }
        public int cloudAddFlag { get; set; }
        public int cloudCloseFlag { get; set; }
        public int cloudDeleteFlag { get; set; }
        public int cloudUpdateFlag { get; set; }
        public String cloudRespJson { get; set; }


        public int dbGenerateFlag { get; set; }
        public int localSaveFlag { get; set; }//挂单字段

        public int cancaelFlag { get; set; }


        // 全班商品累计价格
        public long allGoodsMoneyAmount { get; set; }
        public long stockOutId { get; set; }
        public Byte type { get; set; }
        public long relatedOrder { get; set; }
        public String creator { get; set; }
        public String updateTime { get; set; }
        public String stockOutTime { get; set; }
        public Byte status { get; set; }

        public void generateSeariseNumber()
        {
            CenterContral.oStockOutDTO.Base.serialNumber = "LS-" + CenterContral.oStoreWhouse.storeWhouseId + "-"
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + CommUiltl.GetRandomNumber();
            orderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");

        }
    }
    public class DbStockOutDetail
    {
        //这个文件是保存db里面的结构，如果添加字段，有必要修改修改StockOutDTOHttpModel
        public long id { get; set; }
        public long retailId { get; set; }
        public long goodsId { get; set; }//商品Id
        public String goodsName { get; set; }//商品名称
        public String barcode { get; set; }//商品条码
        public long categoryId { get; set; }// 商品类别Id
        public String specification { get; set; }//零售规格
        public String produceTime { get; set; }
        public String expireTime { get; set; }
        public String baseUnit { get; set; }
        public String bigUnit { get; set; }
        public long unitConversion { get; set; }
        public long unitPrice { get; set; }
        public long orderCount { get; set; }
        public long subtotal { get; set; }
        public String remark { get; set; }
        public long spaceId { get; set; }/** 加工位Id，仅用于零售需要现场加工场景 */



        internal int cloudState { get; set; }
        public long stockOutId { get; set; }



        public string goodsShowSpecification { get; set; }
        public ProductPricing cloudProductPricing;

        public String postKeyWord { get; set; }//postKeyWord，用户输入的关键词
        public String reqKeyWord { get; set; }//searchKeyWord向后台或者本地请求，输入的关键词

        public int isBarCodeMoneyGoods { get; set; }//是否是条码带金额类商品，默认0不是,1是代表是扫码商品
        public long barcodeSubTotalMoney { get; set; }//条码中自带的金额数，当isBarCodeMoneyGoods字段为1时候生效
        public long barcodeCount { get; set; }//条码中自带的金额数,需要重新计算计重数

    }


}
