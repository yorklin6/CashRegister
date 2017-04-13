using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    class Member
    {
        public long memberId{ get; set; }
        public String name{ get; set; }
        public int gender{ get; set; }
        public String phone{ get; set; }

        public String birthday{ get; set; }
        public String address{ get; set; }
        public long consumePoint{ get; set; }
        public long exchangePoint{ get; set; }
        public long memberBalance{ get; set; }
        public String memberAccount{ get; set; }//会员卡号
        public String password{ get; set; }
        public long invalidTime{ get; set; }
        public long storeId{ get; set; }
        public int status{ get; set; }
        public int isDeleted{ get; set; }
        public long createTime{ get; set; }
        public long updateTime{ get; set; }
    }
}
