using CashRegisterApplication.window;
using CashRegiterApplication;
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
            //Application.Run(new ProductListWindow());
            // Application.Run(new LoginWindows());
            Application.Run(new RecieveMoneyWindow());
            //Console.ReadLine();
        }
    }
}
