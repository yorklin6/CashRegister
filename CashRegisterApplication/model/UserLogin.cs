using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{

    public class UserLogin
    {
        public int errorCode { get; set; }
        public String msg { get; set; }
        public User data;
    }
    public class UserMsg
    {
        public String userName { get; set; }
        public String mobile { get; set; }
    }
    public class UserLoginMsg
    {
        public string account { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }

    }

    public class User
    {
        public int id { get; set; }
        public String userName { get; set; }
        public String mobile { get; set; }
        public String department { get; set; }
        public String job { get; set; }
        public String dsc { get; set; }
        public int status { get; set; }
        public int loginFailNum { get; set; }
        public int loginFailTime { get; set; }
        public String userRight { get; set; }
    }

}
