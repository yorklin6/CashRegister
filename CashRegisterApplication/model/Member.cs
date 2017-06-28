using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    public class MemberHttpRespone
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public Member data;
    }
    public class MemberData
    {
        public List<Member> list;
    }
    public class Member
    {
        public long memberId { get; set; }

        public String memberAccount{ get; set; }

        public Byte memberType{ get; set; }

        public String phone{ get; set; }

        public String name{ get; set; }

        public Byte gender{ get; set; }

        public String birthday{ get; set; }

        public String address{ get; set; }

        public long consumePoint{ get; set; }


        public long point { get; set; }

        public long balance { get; set; }

        public String password{ get; set; }

        public String salt{ get; set; }

        public String invalidTime { get; set; }

        public long storeId{ get; set; }

        public String storeName{ get; set; }

        public Byte status{ get; set; }
        public Byte isDeleted{ get; set; }
        public String createTime { get; set; }
        public String updateTime { get; set; }
        public String goodsStringWithoutMemberPrice { get; set; }

        public int cloudState { get; set; }
        public String reqRechargeJson { get; set; }

    }

    public class WalletHistory
    {
        public long id { get; set; }
        public long memberId { get; set; }

        public String relatedOrder { get; set; }

        public String serialNumber { get; set; }

        public int type { get; set; }

        public long originalBalance { get; set; }

        public long changeValue { get; set; }

        public long newBalance { get; set; }

        public String tradeTime { get; set; }

        public long isDeleted { get; set; }

        public String createTime { get; set; }
        public String updateTime { get; set; }

        public Byte status { get; set; }

        public String goodsStringWithoutMemberPrice { get; set; }

        public int cloudState { get; set; }

        public String reqRechargeJson { get; set; }
        public String relatePayWaySerialNumber { get; set; }

        internal void generateRechargeSerialNamber()
        {
            serialNumber = "CZ-" + CenterContral.oStoreWhouse.storeWhouseId + "-"
                + 0 + "-" //会员充值支付，未做支付类型
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + CommUiltl.GetRandomNumber();
        }
        internal void generatePaySerialNamber()
        {
            serialNumber = "ZF-" + CenterContral.oStoreWhouse.storeWhouseId + "-"
                + CenterContral.iPostId + "-" //会员充值支付，未做支付类型
                + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + CommUiltl.GetRandomNumber();
        }
    }

}
