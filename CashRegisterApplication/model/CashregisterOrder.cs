using System;
using System.Collections.Generic;
using System.Text;
using CashRegisterApplication.comm;
using CashRegiterApplication;

namespace CashRegisterApplication.model
{
    public class StockOutDTORespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public StockOutDTO data;
    }
    public class LocalSaveStock
    {
        public  List<StockOutDTO> listStock;
        public  int index { get; set; }
        public LocalSaveStock()
        {
            index = 0;
            listStock = new List<StockOutDTO>();
        }
    }

    public class StockOutDTO
    {
        public StockOutBase Base;
        public LocalBase local;
        public List<StockOutDetail> details;
        public List<Checkout> checkouts;

        public Member oMember;
        
        public StockOutDTO()
        {
            Base = new StockOutBase();
            details = new List<StockOutDetail>();
            checkouts = new List<Checkout>();
            //本地存储变量
            oMember = new Member();
            local = new LocalBase();
        }

        public void addChecout(Checkout oPayWay)
        {
            CommUiltl.Log("RecieveFee before:" + local.TotalPayFee);
            local.TotalPayFee += oPayWay.payAmount;
            CommUiltl.Log("RecieveFee after:" + local.TotalPayFee);
            CaculateFee();
            checkouts.Add(oPayWay);
          
        }

        public void CaculateFee()
        {
            //计算找零价钱和实收价钱
            local.ChangeFee = local.TotalPayFee - Base.orderAmount;
            local.RealRecieveFee = local.TotalPayFee;
            if (local.RealRecieveFee> Base.orderAmount)
            {
                local.RealRecieveFee = Base.orderAmount;
            }
        }
    }


    public class PayWayHttpRequet
    {
        public long memberId { get; set; }

        public int tradeTime { get; set; }

        public List<Checkout> list;
        public PayWayHttpRequet()
        {
            memberId = 0;
            tradeTime = 0;
            list = new List<Checkout>();
        }
    }

    public class Checkout
    {
        public const int PAY_TYPE_CASH = 1;
        public const string PAY_TYPE_CASH_DESC = "现金";

        public const int PAY_TYPE_WEIXIN = 2;
        public const string PAY_TYPE_WEIXIN_DESC = "微信支付";

        public const int PAY_TYPE_ZHIFUBAO = 3;
        public const string PAY_TYPE_ZHIFUBAO_DESC = "支付宝支付";

       
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

        public Checkout()
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
    public class LocalBase
    {
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

        // 折扣
        public long discountAmount { get; set; }
        public long discountRate { get; set; }
        // 全班商品累计价格
        public long allGoodsMoneyAmount { get; set; }
        public long stockOutId { get; set; }
        public Byte type { get; set; }
        public long relatedOrder { get; set; }
        public String creator { get; set; }
        public String updateTime { get; set; }
        public String stockOutTime { get; set; }
        public Byte status { get; set; }
    }
    public class StockOutBase
    {
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




        public void generateSeariseNumber()
        {
            CenterContral.oStockOutDTO.Base.serialNumber = "LS-" + CenterContral.oStoreWhouse.storeWhouseId + "-"
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + CommUiltl.GetRandomNumber();
            orderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");

        }
    }
    public class StockOutDetail
    {

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


    public long stockOutId { get; set; }
        public String unit { get; set; }
        public long actualDifference { get; set; }
        internal int cloudState { get; set; }


      

    public string goodsShowSpecification { get; set; }
        public ProductPricing cloudProductPricing;

        public String postKeyWord { get; set; }//postKeyWord，用户输入的关键词
        public String reqKeyWord { get; set; }//searchKeyWord向后台或者本地请求，输入的关键词

        public int isBarCodeMoneyGoods { get; set; }//是否是条码带金额类商品，默认0不是,1是代表是扫码商品
        public long barcodeSubTotalMoney { get; set; }//条码中自带的金额数，当isBarCodeMoneyGoods字段为1时候生效
        public long barcodeCount { get; set; }//条码中自带的金额数,需要重新计算计重数
    }



}
