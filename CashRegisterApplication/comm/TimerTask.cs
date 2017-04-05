using CashRegisterApplication.model;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    //异步处理数据库
    class TimerTask
    {
        public static void AddStaockOut()
        {
            Dao.GetCloudStateFailedStockOutList();
        }
    }
}
