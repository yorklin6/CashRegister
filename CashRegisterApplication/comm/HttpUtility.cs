﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using CashRegisterApplication.model;
using System.Windows.Forms;
using System.Security.Cryptography;
using CashRegisterApplication.comm;
/*    

* */
namespace CashRegiterApplication
{
    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public class HttpUtility
    {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private static readonly string CashRegistHost = "https://120.24.210.161:8686/jweb_sugu/";
        private static CookieContainer gCookies = null;//全局登录态cookie
        private static readonly string DefaultUser = "york";
        private static readonly string DefaultPassword = "york";
        private static int timeOutDefault = 10000;//1秒超时
        private static string gUserName;
        private static string gPassword;
        private static readonly string LoginFunc = "/user/login?";
        private static readonly string ProductCodeFunc = "goods";
        private static readonly string QueryMemberInfoFunc = "member?page=1&pageSize=1&memberAccount=";
        private static readonly string GenerateOrderFunc = "stockOut?";
        private static readonly string RetailSettlementFunc = "/retail/settlement";
        private static readonly string updateOrderFunc = "stockOut/retail/";
        private static readonly string userPayFunc = "/retail/checkout?";
        private static readonly string rechargeMember = "/member/balance/";
        private static readonly string storeFunc = "/store/?";
        private static readonly string payTypeFunc = "/payType?";

        private static UserLogin oLoginer;

        public const int CLOUD_SATE_HTTP_SUCESS = 0;
        public const int CLOUD_SATE_HTTP_FAILD = 1;
        public const int CLOUD_SATE_BUSSINESS_FAILD = 2;
        public static string lastErrorMsg;

        /***************************************登陆***************************************/
        public static bool Login(string user, string password)
        {
            gUserName = user;
            gPassword = password;
            gCookies = null;
            oLoginer = new UserLogin();

            string loginUrl = LoginFunc;
            // "account=" + gUserName + "&password=" + CommUiltl.HEX_MD5(gPassword);
            UserLoginMsg oUserLoginMsg = new UserLoginMsg();
            oUserLoginMsg.account = gUserName;
            oUserLoginMsg.password = CommUiltl.HEX_MD5(gPassword);
            oUserLoginMsg.rememberMe = true;

            string loginJson = JsonConvert.SerializeObject(oUserLoginMsg);
            loginJson= "rememberMe=true&account="+ gUserName+"&password="+ CommUiltl.HEX_MD5(gPassword);
            Console.WriteLine("Debug loginUrl:" + loginUrl);
            Console.WriteLine("Debug loginJson:" + loginJson);
            if (!PostUrlencoded<UserLogin>(loginUrl, loginJson, ref oLoginer))
            {
                Console.WriteLine("ERR:Get failed");
                MessageBox.Show("登录异常:请检查网络");
                //登录异常
                if (DefaultUser == user && DefaultPassword == password)//
                {
                    MessageBox.Show("使用临时用户登录");
                    return true;
                }
                return false;
            }
            if (0 != oLoginer.errorCode)
            {
                Console.WriteLine("ERR:Get OK but errorCode:" + oLoginer.errorCode);
                MessageBox.Show("帐号密码不对");
                return false;
            }
            Console.WriteLine("ERR:Get OK oLoginer errorCode: " + oLoginer.errorCode);
            return true;
        }



        private static User GetLoginUser()
                                                                                                                                                                                                                                {
            return oLoginer.data;
        }
        // MessageBox.Show();
        /***************************************生成订单***************************************/
        public static   int GenerateOrder(StockOutDTO oReq, ref StockOutDTORespone oRespond)
        {
            int iResult = CLOUD_SATE_HTTP_FAILD;
            lastErrorMsg = "";
            for (int i=0;i<3; ++i)
            {
                iResult=_GenerateOrder(oReq, ref oRespond);
                if (CLOUD_SATE_HTTP_SUCESS == iResult)
                {
                    return iResult;
                }
            }
            return iResult;
        }
        public static int _GenerateOrder(StockOutDTO oReq, ref StockOutDTORespone oRespond)
        {
            string funcUrl = GenerateOrderFunc ;
            String json = JsonConvert.SerializeObject(oReq);

            if (!Post<StockOutDTORespone>(funcUrl, json, ref oRespond))
            {
                CommUiltl.Log("ERR:Get GenerateOrder failed");
                lastErrorMsg = "异常:请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }
            if (oRespond.errorCode != 0)
            {
                CommUiltl.Log("ERR:Get failed oCashregisterOrderResp errorCode:[" + JsonConvert.SerializeObject(oRespond) + "] m");
                lastErrorMsg = "http生成订单异常:oCashregisterOrderResp errorCode:[" + JsonConvert.SerializeObject(oRespond) + "] ";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }

            CommUiltl.Log("http生成订单成功:[" + JsonConvert.SerializeObject(oRespond)  + "]");
            return CLOUD_SATE_HTTP_SUCESS;
        }



        //关闭订单
        internal static int RetailSettlement(StockOutDTO oReq, ref HttpBaseRespone oRespond)
        {
            int iResult = CLOUD_SATE_HTTP_FAILD;
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                iResult = _RetailSettlement(oReq, ref oRespond);
                if (CLOUD_SATE_HTTP_SUCESS == iResult)
                {
                    return iResult;
                }
            }
            return iResult;
        }
        internal static int _RetailSettlement(StockOutDTO oReq, ref HttpBaseRespone oRespond)
        {
            string funcUrl = RetailSettlementFunc;
            String json = JsonConvert.SerializeObject(oReq);

            if (!Post<HttpBaseRespone>(funcUrl, json, ref oRespond))
            {
                Console.WriteLine("ERR:Get GenerateOrder failed");
                CommUiltl.Log("ERR:Get GenerateOrder failed]");
                lastErrorMsg = "http生成订单异常:请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }
            if (oRespond.errorCode != 0)
            {
                CommUiltl.Log("ERR:Get failed oCashregisterOrderResp errorCode:[" + JsonConvert.SerializeObject(oRespond) + "] m");
                lastErrorMsg = "http:生成订单异常 errorCode:[" + JsonConvert.SerializeObject(oRespond) + "] ";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }
            CommUiltl.Log("http关闭订单成功:[" + JsonConvert.SerializeObject(oRespond) + "]");
            return CLOUD_SATE_HTTP_SUCESS;
        }
        //更新订单
        public static int updateRetailStock(StockOutDTO oReq, ref StockOutDTORespone oRespond)
        {
            int iResult = CLOUD_SATE_HTTP_FAILD;
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                iResult = _UpdateOrder(oReq, ref oRespond);
                if (CLOUD_SATE_HTTP_SUCESS == iResult)
                {
                    return iResult;
                }
            }
            return iResult;
        }
        internal static int _UpdateOrder(StockOutDTO oReq, ref StockOutDTORespone oRespond)
        {
            string funcUrl = updateOrderFunc+ oReq.Base.stockOutId;
            String json = JsonConvert.SerializeObject(oReq.Base);
            if (!Post<StockOutDTORespone>(funcUrl, json, ref oRespond))
            {
                Console.WriteLine("ERR:http Get GenerateOrder failed");
                lastErrorMsg = "http更新订单异常:请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }

            if (oRespond.errorCode != 0)
            {
                Console.WriteLine("ERR:Get failed oCashregisterOrderResp:" + oRespond);
                lastErrorMsg = "更新订单异常:oCashregisterOrderResp[" + oRespond.errorCode + " msg:" + oRespond.msg + "]";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }
            CommUiltl.Log("更新订单成功:[" + oRespond + "]");
            //MessageBox.Show("更新订单成功:p[" + oCashregisterOrderResp + "]");
            return CLOUD_SATE_HTTP_SUCESS;
        }
        /***************************************支付***************************************/
        public static int PayOrdr(PayWayHttpRequet oPayWay)
        {
            int iResult = CLOUD_SATE_HTTP_FAILD;
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                iResult = _PayOrder(oPayWay);
                if (CLOUD_SATE_HTTP_SUCESS == iResult)
                {
                    return iResult;
                }
            }
            return iResult;
        }
        public static int _PayOrder(PayWayHttpRequet oPayWay)
        {
            string funcUrl = userPayFunc ;
            PayOrderResp oPayOrderResp = new PayOrderResp();
            String json = JsonConvert.SerializeObject(oPayWay);
            if (!Post<PayOrderResp>(funcUrl, json,ref oPayOrderResp))
            {
                Console.WriteLine("ERR:Get GenerateOrder failed");
                lastErrorMsg = "支付异常：请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }

            if (oPayOrderResp.errorCode != 0)
            {
                Console.WriteLine("ERR:Get failed oCashregisterOrderResp:" + oPayOrderResp);
                lastErrorMsg = "支付异常:oCashregisterOrderResp[" + oPayOrderResp + "]";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }
            return CLOUD_SATE_HTTP_SUCESS;
        }

        /***************************************拉取商品***************************************/
        public static bool GetProductByBarcode(string productCode, ref ProductPricingInfoResp oProductPricingInfoResp)
        {
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                if (_GetProductByBarcode(productCode,ref oProductPricingInfoResp))
                {
                    return true;
                }
            }
            MessageBox.Show(lastErrorMsg);
      
            return false;
        }
        public static bool _GetProductByBarcode(string productCode,ref ProductPricingInfoResp oProductPricingInfoResp)
        {
            string funcUrl = ProductCodeFunc + "?page=1&pageSize=1&barcode=" + productCode;
            CommUiltl.Log("funcUrl:"+ funcUrl);
            if (!Get<ProductPricingInfoResp>(funcUrl, ref oProductPricingInfoResp))
            {
                Console.WriteLine("ERR:Get failed");
                lastErrorMsg = "异常:请检查网络";
                return false;
            }
            return true;
        }
        public static bool GetAllProduct(int page,int pageSize, ref ProductPricingInfoResp oProductPricingInfoResp)
        {
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                if (_GetAllProduct(page, pageSize, ref oProductPricingInfoResp))
                {
                    return true;
                }
            }
            MessageBox.Show(lastErrorMsg);

            return false;
        }
        public static bool _GetAllProduct(int page,int pageSize, ref ProductPricingInfoResp oProductPricingInfoResp)
        {
            string funcUrl = ProductCodeFunc + "?page="+ page + "&pageSize="+ pageSize;
            CommUiltl.Log("funcUrl:" + funcUrl);
            if (!Get<ProductPricingInfoResp>(funcUrl, ref oProductPricingInfoResp))
            {
                Console.WriteLine("ERR:Get failed");
                lastErrorMsg = "异常:请检查网络";
                return false;
            }
            if (oProductPricingInfoResp.errorCode != 0 )
            {
                lastErrorMsg = "返回异常";
                return false;
            }
            return true;
        }
        /***************************************会员信息***************************************/
        internal static int GetMemberByMemberAccount(string strMemberAccount,ref MemberHttpRespone oMember)
        {
            int iResult = CLOUD_SATE_HTTP_FAILD;
            lastErrorMsg = "";
            for (int i = 0; i < 3; ++i)
            {
                iResult = _GetMemberByMemberAccount(strMemberAccount,ref oMember);
                if (CLOUD_SATE_HTTP_SUCESS == iResult)
                {
                    return iResult;
                }
            }
            return iResult;
        }
        public static int _GetMemberByMemberAccount(string strMemberAccount, ref MemberHttpRespone oMemberHttpRespone)
        {
            string funcUrl = QueryMemberInfoFunc + strMemberAccount;
            CommUiltl.Log("funcUrl:" + funcUrl);
            if (!Get<MemberHttpRespone>(funcUrl, ref oMemberHttpRespone))
            {
                CommUiltl.Log("ERR:_GetMemberByMemberAccount Get FAILDED 网络异常：请检查网络 ");
                lastErrorMsg = "网络异常：请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }

            if (oMemberHttpRespone.errorCode != 0)
            {
                CommUiltl.LogObj("ERR:Get failed oCashregisterOrderResp:" , oMemberHttpRespone);
                lastErrorMsg = "支付异常:oMemberHttpRespone[" + CommUiltl.Jason(oMemberHttpRespone) + "]";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }
            if (oMemberHttpRespone.data.list.Count != 1)
            {
                CommUiltl.LogObj("oMemberHttpRespone.data.list.Count != 1 oMemberHttpRespone:", oMemberHttpRespone);
                return CLOUD_SATE_HTTP_SUCESS;
            }
            return CLOUD_SATE_HTTP_SUCESS;
        }
        //会员充值
        internal static int memberRecharge(Member oReq)
        {
            string funcUrl = rechargeMember+ oReq.memberId.ToString();
            HttpBaseRespone oResp = new HttpBaseRespone();
            String json = JsonConvert.SerializeObject(oReq);
            if (!Put<HttpBaseRespone>(funcUrl, json, ref oResp))
            {
                Console.WriteLine("ERR:Get GenerateOrder failed");
                lastErrorMsg = "支付异常：请检查网络";
                return CLOUD_SATE_HTTP_FAILD;
            }

            if (oResp.errorCode != 0)
            {
                Console.WriteLine("ERR:Get failed oResp:" + oResp);
                lastErrorMsg = "充值异常:oResp[" + oResp + "]";
                return CLOUD_SATE_BUSSINESS_FAILD;
            }
            return CLOUD_SATE_HTTP_SUCESS;
        }
        //门店信息
        internal static bool GetStoreMsg(ref List<StoreWhouse>  list)
        {
            string funcUrl = storeFunc + "page=1&pageSize=100&type=1";
            StoreWhouseRespone oResp = new StoreWhouseRespone();
            if (!Get<StoreWhouseRespone>(funcUrl, ref oResp))
            {
                Console.WriteLine("ERR:Get GetStoreMsg failed");
                lastErrorMsg = "门店信息异常：请检查网络";
                return false;
            }

            if (oResp.errorCode != 0)
            {
                Console.WriteLine("ERR:Get failed oResp:" + JsonConvert.SerializeObject( oResp));
                lastErrorMsg = "门店信息异常:oResp[" + JsonConvert.SerializeObject(oResp) + "]";
                return false;
            }
            list = oResp.data.list;
            CommUiltl.Log("list .size ="+ list.Count);
            return true;
        }
        /***************************************付款方式查询***************************************/
        internal static bool GetPayType(ref PayTypeData oPayTypeList)
        {
            string funcUrl = payTypeFunc + "page=1&pageSize=100";
            PayTypeHttpRespone oResp = new PayTypeHttpRespone();
            if (!Get<PayTypeHttpRespone>(funcUrl, ref oResp))
            {
                Console.WriteLine("ERR:Get GetStoreMsg failed");
                lastErrorMsg = "门店信息异常：请检查网络";
                return false;
            }

            if (oResp.errorCode != 0)
            {
                Console.WriteLine("ERR:Get failed oResp:" + JsonConvert.SerializeObject(oResp));
                lastErrorMsg = "付款方式查询:oResp[" + JsonConvert.SerializeObject(oResp) + "]";
                return false;
            }
            oPayTypeList = oResp.data;
            CommUiltl.Log("list .size =" + oPayTypeList.list.Count);
            return true;
        }
        /***************************************Post信息***************************************/
        public static bool PostUrlencoded<T>(string funcUrl, string json, ref T returnObj)
        {
            //https
            string url = CashRegistHost + funcUrl;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;

            // HttpWebRequest request = WebRequest.Create(CashRegistHost + funcUrl) as HttpWebRequest;
            CommUiltl.Log("url:" + url);
            request.Method = "POST";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeOutDefault;
            request.CookieContainer = gCookies;
            request.ContentType = "application/x-www-form-urlencoded";
            if (gCookies == null)
            {
                request.CookieContainer = new CookieContainer();
            }
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("网络异常");
                HandelWEbException(e);
                return false;
            }



            if (!HttpResp<T>(request, ref returnObj))
            {
                Console.WriteLine("ERR:HttpResp failed");
                return false;
            }
            return true;
        }
        /***************************************Post信息***************************************/
        public static bool Post<T>(string funcUrl,string json, ref T returnObj)
        {
            //https
            string url = CashRegistHost + funcUrl;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;

            // HttpWebRequest request = WebRequest.Create(CashRegistHost + funcUrl) as HttpWebRequest;
            CommUiltl.Log("url:" + url);
            request.Method = "POST";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeOutDefault;
            request.CookieContainer = gCookies;
            request.ContentType = "application/json";
            if (gCookies == null)
            {
                request.CookieContainer = new CookieContainer();
            }
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("网络异常");
                HandelWEbException(e);
                return false;
            }

        

            if (!HttpResp<T>(request, ref returnObj))
            {
                Console.WriteLine("ERR:HttpResp failed");
                return false;
            }
            return true;
        }
        /***************************************PUT信息***************************************/
        public static bool Put<T>(string funcUrl, string json, ref T returnObj)
        {
            string url = CashRegistHost + funcUrl;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;

            // HttpWebRequest request = WebRequest.Create(CashRegistHost + funcUrl) as HttpWebRequest;
            CommUiltl.Log("url:" + url);

            request.Method = "PUT";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeOutDefault;
            request.CookieContainer = gCookies;
            request.ContentType = "application/json";
            if (gCookies == null)
            {
                request.CookieContainer = new CookieContainer();
            }
            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("网络异常");
                HandelWEbException(e);
                return false;
            }



            if (!HttpResp<T>(request, ref returnObj))
            {
                Console.WriteLine("ERR:HttpResp failed");
                return false;
            }
            return true;
        }
        public static bool Get<T>(string funcUrl, ref T returnObj)
        {
            string url = CashRegistHost + funcUrl;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;

            // HttpWebRequest request = WebRequest.Create(CashRegistHost + funcUrl) as HttpWebRequest;
            CommUiltl.Log("url:" + url);
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeOutDefault;
            request.CookieContainer = gCookies;
            if (gCookies == null)
            {
                request.CookieContainer = new CookieContainer();
            }

            if (!HttpResp<T>(request, ref returnObj))
            {
                return false;
            }
            return true;
        }
        public static bool HttpResp<T>(HttpWebRequest request, ref T returnObj)
        {
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("网络异常");
                HandelWEbException(e);
                return false;
            }
            Console.WriteLine("DEBUG:response.StatusCode : {0}", (int)response.StatusCode);
            StreamReader streamReader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));
            string content = streamReader.ReadToEnd();
         
            try
            {
                returnObj = JsonConvert.DeserializeObject<T>(content);
               
            }
            catch (Exception e)
            {
                Console.WriteLine("content error ,and coanot parse:"+e+" conten:"+content);
                return false;
            }
       
            if (gCookies == null)
            {
                SetCookiet(response.Cookies);
            }
            if (response != null)
            {
                response.Close();
            }
            return true;
        }

        public static void SetCookiet(CookieCollection oCookieCollection)
        {
            gCookies = new CookieContainer();
            for (int i = 0; i < oCookieCollection.Count; ++i)
            {
                gCookies.Add(oCookieCollection[i]);
            }
        }

        public static void HandelWEbException(WebException e)
        {
            HttpWebResponse response = (HttpWebResponse)e.Response;
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                Console.WriteLine("ERR:response.StatusCode : {0}", (int)response.StatusCode);
            }
            else
            {
                Console.WriteLine("ERR:e.Status: {0}", e.Status);
            }
            if (response != null)
            {
                response.Close();
            }
        }


        public static HttpWebResponse Get(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            request.Timeout = timeOutDefault;
            request.CookieContainer = gCookies;
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="gCookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection gCookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (gCookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(gCookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="gCookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection gCookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (gCookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(gCookies);
            }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }



    }
}