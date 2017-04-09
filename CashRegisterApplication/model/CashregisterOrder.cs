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
        public List<StockOutDetail> details;
        public List<PayWay> payList;
        
        public StockOutDTO()
        {
            Base = new StockOutBase();
            details = new List<StockOutDetail>();
            payList = new List<PayWay>();
        }

        internal void addPayWay(PayWay oPayWay)
        {
            CommUiltl.Log("RecieveFee before:" + Base.RecieveFee);
            Base.RecieveFee += oPayWay.payFee;
            CommUiltl.Log("RecieveFee after:" + Base.RecieveFee);
            if (Base.RecieveFee > Base.orderAmount)
            {
                Base.ChangeFee = Base.RecieveFee - Base.orderAmount;
            }
            payList.Add(oPayWay);
        }
    }

    public class PayWay
    {
        public const int PAY_TYPE_CASH = 1;
        public const string PAY_TYPE_CASH_DESC = "现金";

        public const int PAY_TYPE_WEIXIN = 2;
        public const string PAY_TYPE_WEIXIN_DESC = "微信支付";

        public const int PAY_TYPE_ZHIFUBAO = 3;
        public const string PAY_TYPE_ZHIFUBAO_DESC = "支付宝支付";

        public int payType { get; set; }
        public long payFee { get; set; }
        public string PayOrderNumber { get; internal set; }
        public String serialNumber { get; set; }
        public int payStatus { get; set; }
        public int cloudState { get; set; }
        public PayWay()
        {
            payType = 0;
            payFee = 0;
            payStatus = 0;
            cloudState = 0;
            PayOrderNumber = "";
            serialNumber = "";
        }


        internal void generatePayOrderNumber()
        {
            PayOrderNumber = "pay-" + DateTime.Now.ToString("yyMMdd-HHmmss");
        }
    }

    public class StockOutBase
    {
        public long stockOutId { get; set; }
        public String serialNumber { get; set; }
        public Byte type { get; set; }
        public long storeId { get; set; }
        public long whouseId { get; set; }
        public long relatedOrder { get; set; }
        public long clientId { get; set; }
        public long posId { get; set; }
        public long cashierId { get; set; }
        public long orderAmount { get; set; }
        public String creator { get; set; }
        public long createTime { get; set; }
        public long updateTime { get; set; }
        public long stockOutTime { get; set; }
        public Byte status { get; set; }
        public String remark { get; set; }


        public long RecieveFee { get; set; }
        public String ProductList { get; set; }
        public long ChangeFee { get; set; }


        public String cloudReqJson { get; set; }
        public int cloudAddFlag { get; set; }
        public int cloudCloseFlag { get; set; }
        public int cloudDeleteFlag { get; set; }
        public int cloudUpdateFlag { get; set; }
        public String cloudRespJson { get; set; }

        public int dbGenerateFlag { get; set; }
        public int localSaveFlag { get; set; }

        public void generateSeariseNumber()
        {
            CurrentMsg.oStockOutDTO.Base.serialNumber = "retail-" + DateTime.Now.ToString("yyMMdd-HHmmss");
        }


        internal void Reset()
        {

            CurrentMsg.oStockOutDTO.Base.serialNumber = "";
            CurrentMsg.oStockOutDTO.Base.stockOutId = 0;
            CurrentMsg.oStockOutDTO.Base.RecieveFee = 0;
            CurrentMsg.oStockOutDTO.Base.orderAmount = 0;
            CurrentMsg.oStockOutDTO.Base.ChangeFee = 0;

            CurrentMsg.oStockOutDTO.Base.type = 1;
            CurrentMsg.oStockOutDTO.Base.storeId = 1;
            CurrentMsg.oStockOutDTO.Base.whouseId = 1;
            CurrentMsg.oStockOutDTO.Base.relatedOrder = 0;
            CurrentMsg.oStockOutDTO.Base.posId = 1;
            CurrentMsg.oStockOutDTO.Base.clientId = 1;
            CurrentMsg.oStockOutDTO.Base.cashierId = 1;
            CurrentMsg.oStockOutDTO.Base.orderAmount = 0;
            CurrentMsg.oStockOutDTO.Base.creator = "sys";
            CurrentMsg.oStockOutDTO.Base.status = CurrentMsg.STOCK_BASE_STATUS_INIT;
            CurrentMsg.oStockOutDTO.Base.remark = "";

            CurrentMsg.oStockOutDTO.Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            CurrentMsg.oStockOutDTO.Base.cloudUpdateFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            CurrentMsg.oStockOutDTO.Base.cloudReqJson = "";
            CurrentMsg.oStockOutDTO.Base.cloudCloseFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            CurrentMsg.oStockOutDTO.Base.cloudDeleteFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;

            CurrentMsg.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_INIT;
            CurrentMsg.oStockOutDTO.Base.dbGenerateFlag = CurrentMsg.STOCK_BASE_DB_GENERATE_INIT;

        }

    }
    public class StockOutDetail
    {

        public long id { get; set; }
        public long stockOutId { get; set; }
        public long goodsId { get; set; }
        public String goodsName { get; set; }
        public String barcode { get; set; }
        public String specification { get; set; }
        public String unit { get; set; }
        public long produceTime { get; set; }
        public long expireTime { get; set; }
        public long orderCount { get; set; }
        public long actualCount { get; set; }
        public long actualDifference { get; set; }
        public long unitPrice { get; set; }
        public long subtotal { get; set; }
        public String remark { get; set; }


        public   int status { get; set; }
        internal int cloudState { get; set; }

        public string goodsReqJson { get; set; }
        public string goodsShowSpecification { get; set; }


    }



}
