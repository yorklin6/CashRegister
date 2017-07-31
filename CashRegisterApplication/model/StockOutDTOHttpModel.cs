using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    /*
     *这个文件字段，属于提交下单时候,向后台请求
     */
    public class StockOutDTO
    {
        public StockOutBase Base;
        public List<StockOutDetail> details;
        public List<Checkout> checkouts;
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

        public long discountAmount { get; set; } // 折扣额度
        public long discountRate { get; set; } // 折扣率

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
    }
    public class Checkout
    {

        public int payType { get; set; }
        public long payAmount { get; set; }

        public string stockOutSerialNumber { get; set; }

        public string serialNumber { get; set; }
        public int cloudState { get; set; }
        public int id { get; set; }
        public int posId { get; set; }
        public int payStatus { get; set; }
        public long relatedOrder { get; set; }
        public long storeId { get; set; }
        public int isDeleted { get; set; }

        public string reqMemberZfJson { get; set; }

        public string payTypeDesc { get; set; }


    }
   

}
