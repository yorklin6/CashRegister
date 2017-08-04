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
        public List<Payment> payments;
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
        public long paymentId { get; set; }//关联的钱包支付Id
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

    public class Payment
    {
        public int id { get; set; }
        public string stockOutSerialNumber { get; set; }

        public string serialNumber { get; set; }//支付流水号不能为空！
        public long storeId { get; set; }
        public int posId { get; set; }
        private int orderType { get; set; }//新增
        public long relatedOrder { get; set; }
        public int payType { get; set; }
        public long memberId { get; set; } //新增
        public long originalBalance { get; set; } //新增
        public long payAmount { get; set; } //新增 支付金额必须大于0
        public long  newBalance { get; set; } //新增 
        public string tradeTime { get; set; } //新增 


        //public int cloudState { get; set; }
        //public int payStatus { get; set; }
        //public int isDeleted { get; set; }
        //public string reqMemberZfJson { get; set; }
        //public string payTypeDesc { get; set; }




    /** 支付单流水格式：JZ/TH/CZ-storeId-yyyyMMddHHmmssSSS-randomNum(3位) */
//    @NotBlank(message = "支付流水号不能为空！", groups = { InsertCheck.class})
//    @Pattern(regexp = "^((JZ)|(TH)|(CZ))-(\\d+-)\\d{17}-\\d{3}$", message = "支付流水号格式不合法！", groups = { InsertCheck.class})
//    private String serialNumber;
//private Integer storeId;
//private Integer posId;
//private Byte orderType;
//private Integer relatedOrder;

//    @NotNull(message = "支付方式不能为空！", groups = { InsertCheck.class})
//    @Min(value = 0, message = "支付方式参数非法！", groups = { InsertCheck.class})
//    private Byte payType;
//private Integer memberId;
//private Long originalBalance;

//    @NotNull(message = "支付金额不能为空！", groups = { InsertCheck.class})
//    @Min(value = 1, message = "支付金额必须大于0！", groups = { InsertCheck.class})
//    private Long payAmount;
//private Long newBalance;

//    @NotNull(message = "支付时间不能为空！", groups = { InsertCheck.class})
//    private Timestamp tradeTime;
//private Timestamp createTime;
//private Timestamp updateTime;
    }
   

}
