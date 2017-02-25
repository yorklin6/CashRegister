using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.model
{
    class UserLogin
    {
        public int errorCode { get; set; }
        public string msg { get; set; }
        public User data;
    }
    class UserData
    {
        public UserData()
        {
            info = new User();
        }
        public User info;
    }
    public class User
    {
        private int id { get; set; }
        private String mobile { get; set; }
        private String department { get; set; }
        private String job { get; set; }
        private String dsc { get; set; }
        private int status { get; set; }
        private int loginFailNum { get; set; }
        private int loginFailTime { get; set; }
        private String userRight { get; set; }
    }
}
