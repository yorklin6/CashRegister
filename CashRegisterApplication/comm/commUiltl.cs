using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CashRegisterApplication.model;
using System.Diagnostics;
using System.IO;

namespace CashRegisterApplication.comm
{
    public class CommUiltl
    {
        public static string HEX_MD5(string str)
        {
            //实例化一个md5对像   
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　   
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得   
            return binl2hex(s);
        }
        public static string binl2hex(byte[] buffer)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }
            return builder.ToString();
        }

        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
        public class CallerMemberNameAttribute : Attribute
        {
        }

        internal static string GetMacInfo()
        {
            string macAddress = "02-00-4C-4F-4F-51";
            return macAddress;
            //Process p = null;
            //StreamReader reader = null;
            //try
            //{
            //    ProcessStartInfo start = new ProcessStartInfo("cmd.exe");

            //    start.FileName = "ipconfig";
            //    start.Arguments = "/all";

            //    start.CreateNoWindow = true;

            //    start.RedirectStandardOutput = true;

            //    start.RedirectStandardInput = true;

            //    start.UseShellExecute = false;

            //    p = Process.Start(start);

            //    reader = p.StandardOutput;

            //    string line = reader.ReadLine();

            //    while (!reader.EndOfStream)
            //    {
            //        if (line.ToLower().IndexOf("physical address") > 0 || line.ToLower().IndexOf("物理地址") > 0)
            //        {
            //            int index = line.IndexOf(":");
            //            index += 2;
            //            macAddress = line.Substring(index);
            //            macAddress = macAddress.Replace('-', ':');
            //            break;
            //        }
            //        line = reader.ReadLine();
            //    }
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    if (p != null)
            //    {
            //        p.WaitForExit();
            //        p.Close();
            //    }
            //    if (reader != null)
            //    {
            //        reader.Close();
            //    }
            //}
            //return macAddress;
        }

        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
        public class CallerFilePathAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
        public class CallerLineNumberAttribute : Attribute
        {
        }

        public static bool IsObjEmpty(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return true;
            }
            return false;
        }

        public static bool ConverStrYuanToUnion(object value, out long number)
        {
            number = 0;
            if (CommUiltl.IsObjEmpty(value))
            {
                return false;
            }
            decimal decimalNumber = 0;
            bool isNumber = decimal.TryParse(value.ToString(), out decimalNumber);
            if (!isNumber) return false;
            if (decimalNumber > 100000) return false;
            number = Convert.ToInt32(decimalNumber * 10000);
            return true;

        }

        public static bool CoverStrToLong(object value, out long number)
        {
            number = 0;
            if (CommUiltl.IsObjEmpty(value))
            {
                return false;
            }
            return long.TryParse(value.ToString(), out number);
        }
        public static bool CoverStrToInt(object value, out int number)
        {
            number = 0;
            if (CommUiltl.IsObjEmpty(value))
            {
                return false;
            }
            return int.TryParse(value.ToString(), out number);
        }
        

        public static string CoverMoneyUnionToStrYuan(long money)
        {
            //保留小数点后两位
            return Convert.ToDecimal((double)money / 10000).ToString("0.00");
        }

        public static void Log(string message,
                     [CallerFilePath] string file = null,
                     [CallerLineNumber] int line = 0,
                      [CallerMemberName] string fun = null)
        {

            Console.WriteLine("{0} {1}msg:{2}",  fun, line, message);
        }
        public static void  LogObj(string message,object obj,
             [CallerFilePath] string file = null,
             [CallerLineNumber] int line = 0,
              [CallerMemberName] string fun = null)
        {
            Console.WriteLine("{0} {1} {2}:[{3}]", fun, line, message, JsonConvert.SerializeObject(obj));
        }
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        internal static string Jason(object obj)
        {
           return JsonConvert.SerializeObject(obj);
        }

        internal static string GetRandomNumber()
        {
            Random rnd = new Random();
            int card = rnd.Next(100, 999);
            return card.ToString();
        }
    }
   
}
