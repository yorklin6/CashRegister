using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class ReturnRespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public RetailReturnDTO data;
    }
    public class RetailReturnDTO
    {
        public RetailReturnBase Base;
        public List<RetailReturnDetail> details;

    }
    public class RetailReturnBase
    {
        public String serialNumber { get; set; }

        public long storeId { get; set; }

        public long whouseId { get; set; }

        public String whouseName { get; set; }

        public long relatedOrder { get; set; }

        public long clientId { get; set; }

        public long orderAmount { get; set; }

        public int payType { get; set; }

        public long posId { get; set; }
        public long cashierId { get; set; }
        public String cashierName { get; set; }

        public String remark { get; set; }
        public long createTime { get; set; }

        internal void generateSerialNum()
        {
             serialNumber = "LSTH-" + CenterContral.oStoreWhouse.storeWhouseId + "-"
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + CommUiltl.GetRandomNumber();
        }
    }
    public class RetailReturnDetail
    {
        public long id { get; set; }
        public long retailReturnId { get; set; }

        public long goodsId { get; set; }

        public String goodsName { get; set; }

        public String barcode { get; set; }

        public long categoryId { get; set; }

        public String specification { get; set; }

        public String produceTime { get; set; }

        public String expireTime { get; set; }

        public String unit { get; set; }

        public long unitPrice { get; set; }

        public long returnCount { get; set; }

        public long subtotal { get; set; }

    }
}
