using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using CashRegisterApplication.window;
using CashRegisterApplication.window.Printer;
using CashRegisterApplication.window.Setting;
using CashRegiterApplication;
using SuperMarket;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CashRegiterApplication
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.Run(new Cash());
          Application.Run(new LoginWindows());
            // Application.Run(new SettingDefaultMsgWindow());
            //Application.Run(new ProductListWindow());
            // Application.Run(new RecieveMoneyWindow());
            //Console.ReadLine();
        }
    }
}
