using CashRegisterApplication.model;
using CashRegisterApplication.window;
using CashRegisterApplication.window.function;
using CashRegisterApplication.window.History;
using CashRegisterApplication.window.member;
using CashRegisterApplication.window.Member;
using CashRegisterApplication.window.Printer;
using CashRegisterApplication.window.productList;
using CashRegisterApplication.window.ProductList;
using CashRegisterApplication.window.Setting;
using CashRegiterApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CashRegisterApplication.comm
{

    public static class CenterContral
    {

        public static bool initFlag = false;
        public static ProductListWindow Window_ProductList;//全局窗口
        public static RecieveMoneyWindow Window_RecieveMoney;//收款窗口
        public static ReceiveMoneyByPayTypeWindow Window_ReceiveMoneyByPayType;//现金收款窗口
        public static ReceiveMoneyByMember Window_ReceiveMoneyByMember;//会员收款窗口

        public static SettingDefaultMsgWindow Windows_SettingDefaultMsgWindow ;

        public static RechargeMoneyForMember Window_RechargeMoneyForMember;//充值会员窗口


        public static MemberInfoWindows Window_MemberInfoWindows;//输入会员弹窗
        public static DiscountWindows Window_DiscountWindows;//折扣

        public static FunctionMenuWindow Window_FunctionMenuWindow;

        public static Printer_Hostory_Select_Windows Window_Printer_Hostory_Select_Windows;

        public static HistoryListWindow Window_HistoryListWindow;

        public static HistoryDetailWindow Window_HistoryDetailWindow;
        public static StockOutDTO oStockOutDTO;//当前单据信息

       

        public static SelectGoodWindows Window_SelectGood;

        public static StockOutDTORespone oStockOutDToRespond;
        public static HttpBaseRespone oHttpRespone;

 


        public static LocalSaveStock oLocalSaveStock;//挂单信息

        public static PayTypeData oPayTypeList;



        public static Checkout oCheckout;//支付信息
        //public static PayType oCurrentPayType;// 支付类型全局

        public static UserLogin oLoginer;//登录用户
        public static LoginWindows Windows_Login;

        public static string CloseMoneyBoxComm = "ESC p 0  10  100 ";//钱箱关闭命令

        public const int PAY_STATE_INIT = 0;
        public const int PAY_STATE_SUCCESS = 1;
        public const int PAY_TYPE_CASH = 1;
        public const int MEMBER_PAY_TYPE = 0;


        public const int STOCK_BASE_STATUS_INIT = 0;
        public const int STOCK_BASE_STATUS_NORMAL = 1;
        public const int STOCK_BASE_STATUS_OUT = 2;



        public const int CLOUD_SATE_PAY_SUCESS = 0;
        public const int CLOUD_SATE_PAY_FAILD = 0;

    
        public const int STOCK_BASE_DB_GENERATE_INIT = 0;
        public const int STOCK_BASE_DB_GENERATE_DONE = 1;//已经存在DB


        public const int CLOUD_SATE_PAY_GENERATE_INIT = 0;
        public const int CLOUD_SATE_PAY_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_PAY_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_PAY_UPDATE_SUCCESS = 3;

       

        public static int FLAG_PRODUCTlIST_WINDOW = 0;//商品列表页
        public static int FLAG_MEMBER_RECHAREGE_WINDOWS = 1;//支付页面
        public static int FLAG_MEMBER_RECIEVE_MONEY_WINDOWS = 2;//会员收款页面
        public static int FLAG_LOGIN_WINDOW = 3;//登陆
        public static int FLAG_FUNCTION_MENU_WINDOW = 4;//功能菜单页面

        public static int flagCallShowMember = FLAG_MEMBER_RECIEVE_MONEY_WINDOWS;

        public static int flagCallShowRecharge = FLAG_PRODUCTlIST_WINDOW;

        public static int flagCallDefault = FLAG_PRODUCTlIST_WINDOW;

        public static int flagCallSetting = FLAG_LOGIN_WINDOW;

        public static StoreWhouse oStoreWhouse;
        public static int iPostId = 0;
        public static int store_house_selete_flag;
        public static StoreListWithUser oStoreListWithUser;
        public static int store_whouse_id = 0;
        public const int CLOUD_SATE_PAY_UPDATE_FAILED = 4;

        public const int STORE_HOUSE_UNSET_SELETED = 0;
        public const int STORE_HOUSE_SELETED = 1;
        public const int STOCK_OUT_BASE_TYPE = 21;

        //登录使用

        public static string DefaultUserName = "york";
        public static long   DefaultUserId = 28;
        public static string DefaultPassword = "york";

        public static LocalSystemInfo oSystem;

        internal static void CallWindowsBySettingDefaulMsgWindow()
        {
            if (CenterContral.flagCallSetting == FLAG_LOGIN_WINDOW)
            {
                CenterContral.Windows_Login.UpdateSetttingDefaultMsg();
                return;
            }
            if (CenterContral.flagCallSetting == FLAG_PRODUCTlIST_WINDOW)
            {
                CenterContral.Window_ProductList.CallShow();
                return;
            }
            if (CenterContral.flagCallSetting == FLAG_FUNCTION_MENU_WINDOW)
            {
                CenterContral.Window_ProductList.CallShow();
                CenterContral.Window_FunctionMenuWindow.HideByCenter();
                return;
            }
        }

        internal static void CallSettingDefaultMsgWindow(int flat)
        {
            CenterContral.flagCallSetting = flat;
            CenterContral.Windows_SettingDefaultMsgWindow.ShowByCenter();
        }

        public static long DefaultStoreId = 5;//临时分配门店

        public static int NOT_BARCODE_MOENY_GOODS = 0;//
        public static int IS_BARCODE_MOENY_GOODS = 1;//条码中自带价格商品

        public static string strPrintFilePath = Application.StartupPath.ToString() + "\\print_order.txt";//exe程序所在的路径

        public static void Init()
        {
            CommUiltl.Log("InitWindows "+ initFlag);
            if (initFlag == true)
            {
                return;
            }
            initFlag = true;
            //Window_ProductList = new ProductListWindow();//全局窗口
            Windows_Login = new LoginWindows();
            Window_ProductList = new ProductListWindow();
            Window_RecieveMoney = new RecieveMoneyWindow();//收款窗口
            Window_ReceiveMoneyByPayType = new ReceiveMoneyByPayTypeWindow();//现金收款窗口
            Window_ReceiveMoneyByMember = new ReceiveMoneyByMember();
            Window_RechargeMoneyForMember = new RechargeMoneyForMember();

            Window_MemberInfoWindows = new MemberInfoWindows();
            Window_DiscountWindows = new DiscountWindows();

            Window_FunctionMenuWindow = new FunctionMenuWindow();

            Window_Printer_Hostory_Select_Windows = new Printer_Hostory_Select_Windows();

            Window_HistoryListWindow = new HistoryListWindow();
            Window_HistoryDetailWindow = new HistoryDetailWindow();

            oStockOutDTO = new StockOutDTO();//商品列表

            oStockOutDToRespond = new StockOutDTORespone();
            oHttpRespone = new HttpBaseRespone();
            oCheckout = new Checkout();
            oStoreWhouse = new StoreWhouse();
            store_house_selete_flag = STORE_HOUSE_UNSET_SELETED;
            oStoreListWithUser = new StoreListWithUser();
            oLoginer = new UserLogin();
            Windows_SettingDefaultMsgWindow = new SettingDefaultMsgWindow();
            CenterContral.Window_ProductList = new ProductListWindow();

            oSystem = new LocalSystemInfo();
            oSystem.IpHostAddress = "https://120.24.210.161:8686/branch/";
            oSystem.ClouWebAddress = "https://ec.cdsugu.com/main/views/main/product-list.html";

            oLocalSaveStock = new LocalSaveStock();

            Window_SelectGood = new SelectGoodWindows();
            oPayTypeList = new PayTypeData();
            oPayTypeList.list = new List<PayType>();


            //先默认登陆，取可信任的登陆态
            // CenterContral.InitDefaultLogin();
            CommUiltl.Log("CheckIsInit ");
            if (!CheckIsInit())
            {
                CommUiltl.Log("CheckIsInit false");
                CenterContral.flagCallSetting = FLAG_LOGIN_WINDOW;//默认返回是登陆界面
                Windows_SettingDefaultMsgWindow.ShowByLogin();
                return;

            }
            CenterContral.GetDefaultMsgFromDb();
        }

        public static bool CheckIsInit()
        {
            CommUiltl.Log("CheckIsInit ");
            int iCount = 0;
            if (!Dao.CheckIsInit(ref iCount))
            {
                CommUiltl.Log("CheckIsInit Dao.CheckIsInit");
                return false;
            }
            if (iCount == 0)
            {
                Dao.CreateTables();
                Dao.InsertLocalMsgDefault();
                return false;
            }
            CommUiltl.Log("Dao.CheckIsInit:"+ iCount);
            int postId = 0;
            if (!Dao.GetPostId(ref postId))
            {
                CommUiltl.Log("CheckIsInit Dao.GetPostId ");
                return false;
            }
            if (-1 == postId)
            {
                CommUiltl.Log("-1 == postId");
                return false;
            }
            return true;
        }
        internal static void LoginSuccess()
        {
            CenterContral.Init();
            CenterContral.GetPayTypeList();
            SetTimerTask();
            CenterContral.Window_ProductList.CallShow();
            return;
        }
        public static void SetTimerTask()
        {
            CommUiltl.Log("SetTimerTask ");
            //先执行一把
            MyTimerTask oMyTime = new MyTimerTask();
           // oMyTime.MyTimer_Tick(null,null);
            //再执行异步数据
            Timer MyTimer = new Timer();
            MyTimer.Interval = (5 * 60 * 1000); // 1 mins
            
            MyTimer.Tick += new EventHandler(oMyTime.MyTimer_Tick);
            MyTimer.Start();
        }
       
        public static void GetDefaultMsgFromDb()
        {
            GetDbMsgToCenterConalMsg();//设置默认数据
        }


        public static void GetDbMsgToCenterConalMsg()
        {
            //_InitDbLocalMsg();
            GetSaveStock();//挂单数据
            //门店信息
            GetStoreMsgFromDb();
            //Post机Id设置
            GetPostIdFromDb();

            GetSystemInfoFromDb();
        }

       

        public static void InitDefaultLogin()
        {
            HttpUtility.LoginDefault();
        }

        public static void GetSaveStock()
        {
            //查出挂单的单据
            StockOutDTO oState = new StockOutDTO();
            oState.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_SAVING;
            List<StockOutDTO> oJsonList = new List<StockOutDTO>();
            Dao.GetCloudStateFailedStockOutList(oState, ref oJsonList);
            CommUiltl.Log("GetCloudStateFailedStockOutList：" + oJsonList.Count);
            if (0 == oJsonList.Count)
            {
                return;
            }
            foreach (var item in oJsonList)
            {
                try
                {
                    StockOutDTO oTmp = JsonConvert.DeserializeObject<StockOutDTO>(item.Base.baseDataJson);
                    oLocalSaveStock.listStock.Add(oTmp);
                }
                catch (Exception e)
                {
                    CommUiltl.Log("DeserializeObject content error ,and coanot parse:" + e + " conten:" + item.Base.baseDataJson);
                    continue;
                }
            }
        }

        public static void CallFunctionMenuWindow()
        {
            Window_FunctionMenuWindow.CallShowByCenter();
        }
        //查询某天历史单据
        internal static bool GetStockOutMsgByDate(DateTime oDate, ref List<StockOutDTO> listStockOutDTO)
        {
            List<StockOutDTO> oJsonList = new List<StockOutDTO>();
            if (!Dao.GetStockOutMsgByDate( oDate, ref oJsonList) )
            {
                return false;
            }
       
            CommUiltl.Log("GetStockOutMsgByDate  oJsonList.Count：" + oJsonList.Count);
            if (0 == oJsonList.Count)
            {
                return true;
            }
            foreach (var item in oJsonList)
            {
                try
                {
                    StockOutDTO oTmp = JsonConvert.DeserializeObject<StockOutDTO>(item.Base.baseDataJson);
                    listStockOutDTO.Add(oTmp);
                }
                catch (Exception e)
                {
                    CommUiltl.Log("DeserializeObject content error ,and coanot parse:" + e + " conten:" + item.Base.baseDataJson);
                    continue;
                }
            }
            CommUiltl.Log("listStockOutDTO.Count：" + oJsonList.Count);
            return true;
        }
        /******************门店信息******************/
        internal static void GetStoreMsg(string strUserName)
        {
            if (!HttpUtility.GetStoreMsgByUserName( strUserName,ref CenterContral.oStoreListWithUser))
            {
                return;
            }
            return;
        }
        internal static void GetStoreMsgFromDb()
        {
            string strLoacalJson = "";
            if (!Dao.GetStoreWhouseDefault(ref strLoacalJson))
            {
                return;
            }
            if (strLoacalJson != "")
            {
                store_house_selete_flag = STORE_HOUSE_SELETED;
                CenterContral.oStoreWhouse = JsonConvert.DeserializeObject<StoreWhouse>(strLoacalJson);
            }
            return;
        }
        /******************登陆**********************/
        internal static bool Login(string userName, string password, long storeId)
        {
            if (!HttpUtility.LoginBoss(userName, password,  storeId))
            {
                return false;
            }

            return true;
        }
        internal static bool LoginByUser(string userName, string password, long storeId)
        {
            if (!HttpUtility.LoginByUser(userName, password, storeId))
            {
                return false;
            }

            return true;
        }

        //****************************会员收款和充值
        //显示会员收款
        internal static void Show_MemberInfoWindow_By_RecieveMoeneyByMember()
        {
            flagCallShowMember = FLAG_MEMBER_RECIEVE_MONEY_WINDOWS;
            if (CenterContral.Window_MemberInfoWindows == null)
            {
                CommUiltl.Log("CenterContral.Window_MemberInfoWindows == null");
            }
            CenterContral.Window_MemberInfoWindows.ShowWhithMember();
            
        }
        internal static void Show_MemberInfoWindow_By_RechargeMoeneyByMember()
        {
            flagCallShowMember = FLAG_MEMBER_RECHAREGE_WINDOWS;
            CenterContral.Window_MemberInfoWindows.ShowWhithMember();
        }
        internal static void Show_MemberInfoWindow_By_ProductList()
        {
            flagCallShowMember = FLAG_PRODUCTlIST_WINDOW;
            CenterContral.Window_MemberInfoWindows.ShowWhithMember();
        }

        //当获取会员信息成功后进行显示页面
        internal static void ShowWindowWhenGetMemberSuccess()
        {
            CenterContral.Window_ProductList.SetMemberInfo();
            if (flagCallShowMember == FLAG_MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CenterContral.Window_ReceiveMoneyByMember.ShowWithMemberInfo();
                return;
            }
            if (flagCallShowMember == FLAG_MEMBER_RECHAREGE_WINDOWS)
            {
                CenterContral.Window_RechargeMoneyForMember.ShowWithMemberInfo();
                return;
            }
            if (flagCallShowMember == FLAG_PRODUCTlIST_WINDOW)
            {
                CenterContral.Window_ProductList.CallShow();
                return;
            }
        }

        //更新会员价(废弃，因为会员价暂时定位整单折扣)
        //internal static void UpdateStockOrderByMemberInfo()
        //{
        //    //StockOutDTO
        //    _CaculateMemberPrice();
        //    CenterContral.GetGoodsStringWithoutMemberPrice();
        //    return;
        //}
        //internal static void _CaculateMemberPrice()
        //{
        //    long totalPrice = 0;
        //    for (var i = 0; i < CenterContral.oStockOutDTO.details.Count; ++i)
        //    {
        //        //设置会员价
        //        if (CenterContral.oStockOutDTO.details[i].unitPrice == CenterContral.oStockOutDTO.details[i].cloudProductPricing.retailPrice)
        //        {
        //            CenterContral.oStockOutDTO.details[i].unitPrice = CenterContral.oStockOutDTO.details[i].cloudProductPricing.memberPrice;
        //        }
        //        totalPrice += CenterContral.oStockOutDTO.details[i].unitPrice;
        //    }
        //    CenterContral.oStockOutDTO.Base.orderAmount = totalPrice;
        //    CenterContral.Window_ProductList.SetProductListWindowByStockOut(CenterContral.oStockOutDTO);
        //    //更新数据库里面订单信息
        //    if (!Dao.updateRetailStock(CenterContral.oStockOutDTO))
        //    {
        //        return;
        //    }
        //}

        internal static bool SetCurrentPayTypeById(int payTypeId)
        {
            //找出支付类型为paytypid元素
            for(int index=0; index < CenterContral.oPayTypeList.list.Count; ++index)
            {
                if (CenterContral.oPayTypeList.list[index].payTypeId == payTypeId)
                {
                    var oPayType = CenterContral.oPayTypeList.list[index];
                    //支付信息预设
                    CenterContral.oCheckout = new Checkout();
                    CenterContral.oCheckout.payType = oPayType.payTypeId;
                    CenterContral.oCheckout.payTypeDesc = oPayType.description;
                    CenterContral.oCheckout.generatePayOrderNumber();
                    CenterContral.oCheckout.stockOutSerialNumber = CenterContral.oStockOutDTO.Base.serialNumber;
                    CenterContral.oCheckout.payStatus = CenterContral.PAY_STATE_SUCCESS;
                    CenterContral.oCheckout.cloudState = CenterContral.CLOUD_SATE_PAY_SUCESS;
             
                    return true;
                }
            }
            return false;
        }
        internal static PayType GetPayTyIndexByPayTypeId( int index)
        {
            return CenterContral.oPayTypeList.list[index];
        }



        internal static void GetGoodsStringWithoutMemberPrice()
        {
            string strTmp = "";
            for (var i = 0; i < CenterContral.oStockOutDTO.details.Count; ++i)
            {
                //设置会员价
                if (CenterContral.oStockOutDTO.details[i].unitPrice != CenterContral.oStockOutDTO.details[i].cloudProductPricing.retailPrice)
                {
                    //strTmp +="id:"+Main.oStockOutDTO.details[i].goodsId+" ";
                    strTmp += CenterContral.oStockOutDTO.details[i].goodsName;
                    strTmp += " 会员价:" + CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.details[i].cloudProductPricing.memberPrice);
                    strTmp += " 现价:" + CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.details[i].unitPrice);
                    strTmp += "\n";
                }

            }
            CenterContral.oStockOutDTO.oMember.goodsStringWithoutMemberPrice = strTmp;

        }
        //***************************充值相关
        internal static void ShowWindows_RechargeMoneyForMember()
        {
            flagCallShowRecharge = FLAG_PRODUCTlIST_WINDOW;
            Window_RechargeMoneyForMember.ShowByProductListWindow();
        }

        //充值后返回
        internal static void ControlWindowsAfterRecharge()
        {
           
            if (flagCallShowRecharge == FLAG_PRODUCTlIST_WINDOW)
            {
                CenterContral.Window_FunctionMenuWindow.HideByCenter();
                CenterContral.Window_ProductList.CallShow();
            }
            if (flagCallShowRecharge == FLAG_MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CenterContral.Window_ProductList.CallShow();
            }
        }
        
        //当会员取消界面
        internal static void ShowWindowWhenMemberInfoCancel()
        {

            if (flagCallShowMember == FLAG_MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CenterContral.Window_RecieveMoney.Show();
                return;
            }
            if (flagCallShowMember == FLAG_MEMBER_RECHAREGE_WINDOWS)
            {
                CenterContral.Window_ProductList.CallShow();
                return;
            }
        }

        internal static bool GeneratePostId(int storeWhouseId,string strMac)
        {
            if (!HttpUtility.GeneratePostId(storeWhouseId, strMac, ref CenterContral.iPostId))
            {
                return false;
            }
            return true;
        }

        public static void Clean()
        {
            CenterContral.oStockOutDTO = new StockOutDTO();//商品列表
            CenterContral.oStockOutDToRespond = new StockOutDTORespone();

            CenterContral.oStockOutDTO.Base.generateSeariseNumber();
            CenterContral.oStockOutDTO.Base.RecieveFee = 0;
            CenterContral.oStockOutDTO.Base.orderAmount = 0;
            CenterContral.oStockOutDTO.Base.ChangeFee = 0;
            CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount = 0;

            CenterContral.oStockOutDTO.Base.type = CenterContral.STOCK_OUT_BASE_TYPE;
            CenterContral.oStockOutDTO.Base.storeId = CenterContral.oStoreWhouse.storeWhouseId;
            CenterContral.oStockOutDTO.Base.whouseId = CenterContral.oStoreWhouse.storeWhouseId;
            CenterContral.oStockOutDTO.Base.relatedOrder = 0;
            CenterContral.oStockOutDTO.Base.posId = CenterContral.iPostId;
            CenterContral.oStockOutDTO.Base.clientId = 1;
            CenterContral.oStockOutDTO.Base.stockOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
          //  CenterContral.oStockOutDTO.Base.cashierId = CenterContral.oLoginer.data.id;

            //  CenterContral.oStockOutDTO.Base.creator = CenterContral.oLoginer.data.userName;
            CenterContral.oStockOutDTO.Base.status = CenterContral.STOCK_BASE_STATUS_INIT;
            CenterContral.oStockOutDTO.Base.remark = "";

            CenterContral.oStockOutDTO.Base.creator = CenterContral.DefaultUserName;
            CenterContral.oStockOutDTO.Base.cashierId = CenterContral.DefaultUserId;

            CenterContral.oStockOutDTO.Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;
            CenterContral.oStockOutDTO.Base.cloudUpdateFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;

            CenterContral.oStockOutDTO.Base.cloudCloseFlag = HttpUtility.CLOUD_SATE_HTTP_INIT;
            CenterContral.oStockOutDTO.Base.cloudDeleteFlag = Dao.STOCK_BASE_DELETE_INI;

            CenterContral.oStockOutDTO.Base.baseDataJson = "";

            CenterContral.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_INIT;
            CenterContral.oStockOutDTO.Base.dbGenerateFlag = CenterContral.STOCK_BASE_DB_GENERATE_INIT;
            CenterContral.oStockOutDTO.Base.cancaelFlag = Dao.STOCK_BASE_CANCEL_FLAG_INI;

            //收款折扣
            CenterContral.oStockOutDTO.Base.discountRate = 100;
            CenterContral.oStockOutDTO.Base.discountAmount =0;
            
            CenterContral.Window_ProductList.UpdateDiscount();
            //**********收银台界面*****
            CenterContral.Window_ProductList.SetSerialNumber(CenterContral.oStockOutDTO.Base.serialNumber);
            CenterContral.Window_ProductList.SetStoreName(CenterContral.oStoreWhouse.name);

            //会员信息清空
            CenterContral.oStockOutDTO.oMember = new Member();
            CenterContral.Window_ProductList.SetMemberInfo();

            //挂单数据情况
            CenterContral.Window_ProductList.SetLocalSaveDataNumber();
        }


        public static void updateOrderAmount(long orderPrice)
        {
            CommUiltl.Log(" updateOrderAmount:" + orderPrice);
            CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount = orderPrice;
            CenterContral.UpdateDiscountRate(CenterContral.oStockOutDTO.Base.discountRate);
        }
        public static void UpdateDiscountRate(long discountRate)
        {
            CenterContral.oStockOutDTO.Base.orderAmount = GetMoneyAmountByDiscountRate(discountRate);
            CenterContral.oStockOutDTO.Base.ChangeFee = CenterContral.oStockOutDTO.Base.RecieveFee - CenterContral.oStockOutDTO.Base.orderAmount;
            CenterContral.oStockOutDTO.Base.discountRate = discountRate;
            CenterContral.oStockOutDTO.Base.discountAmount = CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount - CenterContral.oStockOutDTO.Base.orderAmount;
            CenterContral.Window_ProductList.UpdateDiscount();
        }

        internal static void CallWindowsSelectGooodByProudctList(List<ProductPricing> list)
        {
            Window_SelectGood.ShowByProductList(list);
        }
        internal static void CallBackBySelectGoodWindow(ProductPricing productPricing)
        {
            CenterContral.Window_ProductList.CallBackBySelectGoodWindow(productPricing);
        }
        internal static void EecBySelectGoodWindow()
        {
            CenterContral.Window_ProductList.EecBySelectGoodWindow();
        }
        public static long GetMoneyAmountByDiscountRate(long discountRate)
        {
            //CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount本来是4位长度
            return (long)( (double)(CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount) /100 * discountRate);
        }
        public static void ControlWindowsAfterPay()
        {
            CommUiltl.Log("ControlWindowsAfterPay");
            if (CenterContral.oStockOutDTO.Base.RecieveFee < CenterContral.oStockOutDTO.Base.orderAmount)
            {
                CommUiltl.Log("Window_RecieveMoney Show");
                Window_RecieveMoney.ShowPaidMsg();
                return;
            }
            //Order.RecieveFee >= Order.orderAmount 说明已经收钱完毕
            if (!CloseOrderWhenPayAllFee())
            {
                return;
            }
            //打印小票
            //打印本单
            Window_ProductList.CallShow();
            Window_RecieveMoney.CallHide();
            CenterContral.printOrderMsgToFile(CenterContral.oStockOutDTO);//写入打印文件
            Window_ProductList.CloseOrderAndPrintOrderByCenter();
            Window_ProductList.ExePrint();
        }

        //***********************************关闭订单***************************
        internal static bool CloseOrderWhenPayAllFee()
        {
            CenterContral.oStockOutDTO.Base.status = STOCK_BASE_STATUS_OUT;
            SetSaveFlag();//挂单->关单
            CenterContral.oStockOutDTO.Base.baseDataJson = "";//请求之前先把这个字段清空，减少请求空间
            //关单请求                                                  
            CenterContral.oStockOutDTO.Base.cloudCloseFlag
                           = HttpUtility.RetailSettlement(CenterContral.oStockOutDTO, ref CenterContral.oHttpRespone);

            if (CenterContral.oStockOutDTO.Base.cloudCloseFlag != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                var confirmPayApartResult = MessageBox.Show("后台下单失败，系统需要自动重试",
                                  "提示",
                                  MessageBoxButtons.YesNo);

                if (confirmPayApartResult != DialogResult.Yes)
                {
                    return false;
                }

            }
            CenterContral.oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CenterContral.oStockOutDTO);

            if (!Dao.updateRetailStock(CenterContral.oStockOutDTO))
            {
                return false;
            }
            RemoveSaveStock();//挂单->关单
            return true;
        }
        internal static void RemoveSaveStock()
        {
            if (CenterContral.oStockOutDTO.Base.localSaveFlag == Dao.STOCK_BASE_SAVE_FLAG_CLOSE)
            {
                //挂单给关闭掉
                for (int i = 0; i < CenterContral.oLocalSaveStock.listStock.Count; ++i)
                {
                    if (oStockOutDTO.Base.serialNumber == CenterContral.oLocalSaveStock.listStock[i].Base.serialNumber)
                    {
                        CenterContral.oLocalSaveStock.listStock.RemoveAt(i);
                        break;
                    }
                }
                CenterContral.Window_ProductList.SetLocalSaveDataNumber();
            }
        }
        internal static void SetSaveFlag()
        {
            if (CenterContral.oStockOutDTO.Base.localSaveFlag == Dao.STOCK_BASE_SAVE_FLAG_SAVING)
            {
                CenterContral.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_CLOSE;
            }
        }
        //***********************************取消当前订单***************************
        internal static bool CanCelOrder(StockOutDTO oStockOutDTO)
        {
            if (oStockOutDTO.Base.RecieveFee == 0 && oStockOutDTO.Base.orderAmount==0 )
            {
                CommUiltl.Log("Main.oStockOutDTO.details.Count == 0]");
                return true;
            }
            //挂单的要变成关单
            SetSaveFlag();
            RemoveSaveStock();
       
            //关单标记位
            oStockOutDTO.Base.cloudCloseFlag = Dao.STOCK_BASE_DELETE_TRUE;
            //取消标记位
            oStockOutDTO.Base.cancaelFlag = Dao.STOCK_BASE_CANCEL_FLAG_TRUE;
            oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(oStockOutDTO);
            if (!Dao.updateRetailStock(oStockOutDTO))
            {
                return false;
            }
            return true;
        }
        //***********************************删除当前订单***************************
        internal static bool DeleteOrder(StockOutDTO oStockOutDTO)
        {
          
            //挂单的要变成关单
            SetSaveFlag();
            RemoveSaveStock();
            //取消标记位
            oStockOutDTO.Base.cloudCloseFlag = Dao.STOCK_BASE_DELETE_TRUE;
            oStockOutDTO.Base.cloudDeleteFlag = Dao.STOCK_BASE_DELETE_TRUE;
            oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CenterContral.oStockOutDTO);
            if (!Dao.updateRetailStock(CenterContral.oStockOutDTO))
            {
                return false;
            }
            return true;
        }
        //***********************************生成订单***************************
        internal static bool IsCurrentOrderInit()
        {
            return CenterContral.oStockOutDTO.Base.dbGenerateFlag == CenterContral.STOCK_BASE_DB_GENERATE_INIT;
        }

        internal static bool GenerateOrder(string strProductList)
        {
            if (CenterContral.oStockOutDTO.Base.RecieveFee == 0 && CenterContral.oStockOutDTO.Base.orderAmount == 0)
            {
                CommUiltl.Log("Main.oStockOutDTO.details.Count == 0");
                return true;
            }
            CommUiltl.Log("CenterContral.oStockOutDTO.Base.dbGenerateFlag:"+CenterContral.oStockOutDTO.Base.dbGenerateFlag);
            if (IsCurrentOrderInit())
            {
                
                CenterContral.oStockOutDTO.Base.ProductList = strProductList;
                CommUiltl.Log("Order.OrderCode ==  empty GenerateOrder ");

                // CenterContral.oStockOutDTO.Base.cloudAddFlag = HttpUtility.GenerateOrder(CenterContral.oStockOutDTO, ref CenterContral.oStockOutDToRespond);
                CenterContral.oStockOutDTO.Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_SUCESS;
                CenterContral.oStockOutDTO.Base.dbGenerateFlag = CenterContral.STOCK_BASE_DB_GENERATE_DONE;//新增

                CenterContral.oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CenterContral.oStockOutDTO);
                //插入本地数据库表
                if (!Dao.GenerateOrder(CenterContral.oStockOutDTO))
                {
                    return false;
                }
                return true;
            }
            //更新订单
            if (strProductList != null && 0 != CenterContral.oStockOutDTO.Base.ProductList.CompareTo(strProductList))
            {
                CommUiltl.Log(" strProductList is modify [" + CenterContral.oStockOutDTO.Base.ProductList + "] -> [" + strProductList + "]");
                CenterContral.oStockOutDTO.Base.ProductList = strProductList;
                //先去掉，只有结算的时候，向后台请求下单 CenterContral.oStockOutDTO.Base.cloudUpdateFlag = HttpUtility.updateRetailStock(CenterContral.oStockOutDTO, ref CenterContral.oStockOutDToRespond);

                CenterContral.oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CenterContral.oStockOutDTO);
                if (!Dao.updateRetailStock(CenterContral.oStockOutDTO))
                {
                    return false;
                }

                return true;
            }
            CommUiltl.Log(" not modify strProductList:" + strProductList);
            return true;
        }
        
        internal static bool GetGoodsByGoodsKey(string strGoodsKeyWord, ref ProductPricingInfoResp oStockOutDetailInfoResp  )
        {
            //先判断是否是记重类商品
            string strKeyWord = strGoodsKeyWord;//真正请求后台和商品的信息
            long subTotalPrice = 0;
            bool isWeight= _ConverKeywordIfIsWeight(strGoodsKeyWord, out strKeyWord , out subTotalPrice);

            //请求后台取出商户商品信息
            if (!HttpUtility.GetGoodsByKeyWord(strKeyWord, ref oStockOutDetailInfoResp))
            {
                //网络出现错误，要访问本地
                List<String> strListJson = new List<string>();
                if (! Dao.GetGoodsByBarcode(strKeyWord, ref strListJson))
                {
                    MessageBox.Show("本地未找到商品资料");
                    return false;
                }
                oStockOutDetailInfoResp.data = new ProductPricingData();
                oStockOutDetailInfoResp.data.list = new List<ProductPricing>();
                for (int i=0;i< strListJson.Count; ++i)
                {
                    ProductPricing productInfo = JsonConvert.DeserializeObject<ProductPricing>(strListJson[i]);
                    CommUiltl.Log("GetGoodsByProductCode get goods ok:" + productInfo.barcode);
                    oStockOutDetailInfoResp.data.list.Add(productInfo);
                }
                MessageBox.Show("网络不稳定，使用本地商品信息");
                oStockOutDetailInfoResp.errorCode = 0;
                //处理下返回信息
                _HandleGoodsRespone(isWeight,  subTotalPrice , strKeyWord, ref oStockOutDetailInfoResp);
                return true;
            }
            if (oStockOutDetailInfoResp.errorCode != 0 )
            {
                MessageBox.Show("后台返回错误:"+HttpUtility.lastErrorMsg);
                return false;
            }
            //处理下返回信息
            _HandleGoodsRespone(isWeight, subTotalPrice,strKeyWord, ref oStockOutDetailInfoResp);
            CommUiltl.Log("http GetGoodsByProductCode get goods ok:" + strKeyWord);
            return true;
        }

        private static void _HandleGoodsRespone(bool isWeight, long subTotalPrice ,string strKeyWord, ref ProductPricingInfoResp oStockOutDetailInfoResp)
        {
            if (!isWeight)
            {
                return;
            }
            //处理返回信息
            //原因：计重类的商品，字符串太短了，比如正常条码13位，计重类的条码才6位，怕出现模糊匹配，所以就把计重类的商品条码重新fix下
            var goodList = oStockOutDetailInfoResp.data.list;
            for (int i=0;i< goodList.Count; ++i)
            {
                if (strKeyWord== goodList[i].barcode)
                {
                    //找到
                    goodList[i].isBarCodeMoneyGoods = CenterContral.IS_BARCODE_MOENY_GOODS;
                    goodList[i].barcodeSubTotalMoney = subTotalPrice;
                    goodList[i].barcodeCount = CommUiltl.CaculateBarCodeCount(goodList[i].barcodeSubTotalMoney, goodList[i].retailPrice);
                }
               
            }
        }

        private static bool _ConverKeywordIfIsWeight(string strGoodsKeyWord, out string strKeyWord, out long subTotalPrice)
        {
            strKeyWord = strGoodsKeyWord;
            subTotalPrice = 0;
            //计重商品满足下面特点
            //1.长度13位
            //2.是数字
            //3.开头是2
            if (strGoodsKeyWord.Length != 13 || !Regex.IsMatch(strGoodsKeyWord, @"^\d+$") || strGoodsKeyWord.Substring(0,1) != "2")
            {
                CommUiltl.Log("strGoodsKeyWord is not weight:" + strGoodsKeyWord + "  strGoodsKeyWord.Substring:"+ strGoodsKeyWord.Substring(0, 1));
                //不满足情况
                return false;
            }

            string strKeyWordMsg = strGoodsKeyWord.Substring(1, strGoodsKeyWord.Length-1);
            //除去第一位是2,前面6位是商品号
            strKeyWord = strGoodsKeyWord.Substring(1, 6);
            CommUiltl.Log("strKeyWord:" + strKeyWord);
            //后面6位是：5位金额+1位校验码
            string strSubTotalPrice = strGoodsKeyWord.Substring(7, 5);
            CommUiltl.Log("strSubTotalPrice:" + strSubTotalPrice);
            //金额要去掉前面的0？
            if (!CommUiltl.ConverStrBardCodeTolong(strSubTotalPrice, out subTotalPrice))
            {
                MessageBox.Show("条码金额错误");
                return false;
            }

            CommUiltl.Log("strGoodsKeyWord is  weight:" + strGoodsKeyWord+ " subTotalPrice:" + subTotalPrice);
            return true;
        }

        internal static void ProductTostockDetail(ProductPricing productInfo, ref StockOutDetail detail)
        {
            detail.barcode = productInfo.barcode;
            detail.goodsName = productInfo.goodsName;
            detail.unitPrice = (productInfo.retailPrice);
            detail.remark = productInfo.remark;
            detail.specification = productInfo.specification;
            detail.categoryId = productInfo.categoryId;
            detail.unit = productInfo.baseUnit;

            // detail.goodsShowSpecification = productInfo.baseUnit + "/" + productInfo.bigUnit + "/" + productInfo.specification;
            detail.goodsShowSpecification = productInfo.baseUnit;

            detail.postKeyWord = productInfo.postKeyWord;
            detail.reqKeyWord = productInfo.reqKeyWord;
            detail.postKeyWord = productInfo.postKeyWord;

            detail.isBarCodeMoneyGoods = productInfo.isBarCodeMoneyGoods;
            detail.barcodeSubTotalMoney = productInfo.barcodeSubTotalMoney;

            detail.actualCount = 1;
            detail.subtotal = detail.actualCount * detail.unitPrice;

            if (detail.isBarCodeMoneyGoods == CenterContral.IS_BARCODE_MOENY_GOODS)
            {
                //计重类,总价
                detail.subtotal = productInfo.barcodeSubTotalMoney;
                detail.barcodeCount = productInfo.barcodeCount;
            }

            CommUiltl.Log("_ProductTostockDetail   detail.goodsShowSpecification :" + detail.goodsShowSpecification);
            detail.cloudProductPricing = productInfo;
        }
        internal static string  GetGoodsCount(StockOutDetail detail)
        {
            if (detail.isBarCodeMoneyGoods == CenterContral.IS_BARCODE_MOENY_GOODS)
            {
                //条码带有金额的商品,数量=总价/单价
                return CommUiltl.CoverUnionTo3rd(detail.barcodeCount);
            }
            return detail.actualCount.ToString();
        }


        //************************挂单***********************
        internal static bool SaveStock(string strProductList)
        {
            //生成订单，状态为挂单
            CenterContral.oStockOutDTO.Base.ProductList = strProductList;
            CenterContral.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_SAVING;
            if (!CenterContral.GenerateOrder(strProductList))
            {
                return false;
            }
            addStockToLocal(CenterContral.oStockOutDTO);
            
            return true;
        }
        internal static void addStockToLocal(StockOutDTO oStockOutDTO)
        {
            CommUiltl.Log("addStockToLocal CenterContral.oStockOutDTO.Base.dbGenerateFlag:" + oStockOutDTO.Base.dbGenerateFlag);
            CommUiltl.Log("addStockToLocal Main.oSaveSotckOut.listStock.Count:" + CenterContral.oLocalSaveStock.listStock.Count);
            for (int i = 0; i < CenterContral.oLocalSaveStock.listStock.Count; ++i)
            {
                if (oStockOutDTO.Base.serialNumber == CenterContral.oLocalSaveStock.listStock[i].Base.serialNumber)
                {
                    CommUiltl.Log("addStockToLocal found");
                    CenterContral.oLocalSaveStock.listStock[i] = oStockOutDTO;//如果是已经存在挂单中的订单，那么就替换下
                    return;
                }
            }
            CenterContral.oLocalSaveStock.listStock.Add(oStockOutDTO);
            CenterContral.Window_ProductList.SetLocalSaveDataNumber();
        }
        public static int CurrentStockIndex = -1;

  

        internal static void GetSaveOrderToCurrentMsg()
        {
            if (CenterContral.oLocalSaveStock.listStock.Count == 0)
            {
                return;
            }
            ++CurrentStockIndex;
            CurrentStockIndex = CurrentStockIndex % CenterContral.oLocalSaveStock.listStock.Count;
            CenterContral.oStockOutDTO = CenterContral.oLocalSaveStock.listStock[CurrentStockIndex];
        }

        internal static void SetStockDetailByHttpRespone(StockOutDTO http, ref StockOutDTO Db)
        {
            if (oStockOutDToRespond.data.details.Count != CenterContral.oStockOutDTO.details.Count)
            {
                //说明是有问题的
                CommUiltl.Log("oRespond.data.details.Count[" + oStockOutDToRespond.data.details.Count + "] != Main.oStockOutDTO.details.Count [" + CenterContral.oStockOutDTO.details.Count + "]");
                MessageBox.Show("下单异常，请联系后台同学检查下单返回[" + oStockOutDToRespond.data.details.Count + "] != Main.oStockOutDTO.details.Count [" + CenterContral.oStockOutDTO.details.Count + "]");
            }
            else
            {
                for (int i = 0; i < oStockOutDToRespond.data.details.Count; ++i)
                {
                    CenterContral.oStockOutDTO.details[i].id = oStockOutDToRespond.data.details[i].id;
                }
            }
        }
        internal static bool PayOrder(long recieveFee)
        {
            oCheckout.payAmount = recieveFee;
            if (!Dao.GeneratePay(CenterContral.oCheckout))
            {
                return false;
            }
            //修改环境变量，表示这笔单支付成功
            CenterContral.oStockOutDTO.addChecout(CenterContral.oCheckout);
            CenterContral.Window_ProductList.UpdateProductListWindowsMoneyLabel();
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            return true;
        }
        internal static bool PayOrderByMember(long recieveFee)
        {
            oCheckout.payAmount = recieveFee;

            WalletHistory oRecharge = new WalletHistory();
            
            oRecharge.memberId = CenterContral.oStockOutDTO.oMember.memberId;
            oRecharge.changeValue = recieveFee;
            oRecharge.generatePaySerialNamber();
            oRecharge.tradeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            if ( HttpUtility.MemberPay(oRecharge) != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                MessageBox.Show("支付失败:" + HttpUtility.lastErrorMsg);
                return false;
            }
            //本地记录支付信息
            oCheckout.reqMemberZfJson = JsonConvert.SerializeObject(oRecharge);
            if (!Dao.GeneratePay(oCheckout))
            {
                return false;
            }
            CenterContral.oStockOutDTO.addChecout(CenterContral.oCheckout);
            CenterContral.Window_ProductList.UpdateProductListWindowsMoneyLabel();
            //重新拉会员信息
            CenterContral.GetMemberByMemberAccount(CenterContral.oStockOutDTO.oMember.memberAccount);
            CenterContral.Window_ProductList.SetMemberInfo();
            return true;
        }
        //充值
        internal static bool RechargeMoneyByMember(long recieveFee)
        {
            //充值金
            WalletHistory oRecharge = new WalletHistory();
            oRecharge.memberId = CenterContral.oStockOutDTO.oMember.memberId;
            oRecharge.changeValue = recieveFee;
            oRecharge.generateRechargeSerialNamber();
            oRecharge.tradeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            //请求后台充值
            oRecharge.cloudState = HttpUtility.memberRecharge(oRecharge);
            if (HttpUtility.CLOUD_SATE_HTTP_SUCESS != oRecharge.cloudState)
            {
                MessageBox.Show("充值失败" + HttpUtility.lastErrorMsg );
                return false;
            }
            oRecharge.reqRechargeJson = JsonConvert.SerializeObject(oRecharge);
            long beforeMberBalance = CenterContral.oStockOutDTO.oMember.balance ;
            //重新拉会员信息
            CenterContral.GetMemberByMemberAccount(CenterContral.oStockOutDTO.oMember.memberAccount);
            long afterMemberAccount = CenterContral.oStockOutDTO.oMember.balance ;
            //记录流水
            Dao.memberRecharge(oRecharge, beforeMberBalance, afterMemberAccount, recieveFee, CenterContral.oStockOutDTO.oMember);
            //CenterContral.Window_ProductList.SetMemberInfo();
            return true;
        }

        //************************会员信息***********************
        internal static bool GetMemberByMemberAccount(string strMemberAccount)
        {
            MemberHttpRespone oMember = new MemberHttpRespone();
            int iMemberRet = HttpUtility.GetMemberByMemberAccount(strMemberAccount, ref oMember);
            if (iMemberRet == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                if (oMember.data== null)
                {
                    MessageBox.Show("未找到会员信息");
                    return false;
                }
                CenterContral.oStockOutDTO.oMember = oMember.data;
                return true;
            }
            if (iMemberRet == HttpUtility.CLOUD_SATE_HTTP_FAILD)
            {
                MessageBox.Show(HttpUtility.lastErrorMsg);
                return false;
            }
           
            MessageBox.Show("业务错误：" + HttpUtility.lastErrorMsg);
           
            return false;
        }
        //************************支付类型***********************
              
        internal static bool GetPayTypeList()
        {
            string json = "";
            if (!HttpUtility.GetPayType(ref CenterContral.oPayTypeList))
            {
                //取网络失败，那么就取数据库里面的
                if (!Dao.GetPayTypeList(ref json))
                {
                    MessageBox.Show("获取支付类型失败：" + HttpUtility.lastErrorMsg);
                    return false;
                }

                CenterContral.oPayTypeList = JsonConvert.DeserializeObject<PayTypeData>(json);
                return true;
            }
            json = JsonConvert.SerializeObject(CenterContral.oPayTypeList);
            //取网络成功，则更新本地数据库
            if (!Dao.SetPayType(ref json))
            {
                return false;
            }

            return false;
        }
        //post 机id
        internal static void GetSystemInfoFromDb()
        {
            string strJson="";
            if (!Dao.GetSystemInfo(ref strJson))
            {
                CommUiltl.Log("Dao.GetSystemInfo err");
                iPostId = -1;
                return;
            }
            CommUiltl.Log("strJson:"+ strJson);
            CenterContral.oSystem = JsonConvert.DeserializeObject<LocalSystemInfo>(strJson);
        }
        internal static void SetSystemInfoToDb()
        {
            string strJson = JsonConvert.SerializeObject(CenterContral.oSystem);
            if (!Dao.SetSystemInfo(strJson))
            {
                CommUiltl.Log("Dao.SetSystemInfo err");
                return;
            }
        }

        //post 机id
        internal static void GetPostIdFromDb()
        {
            string strMac = CommUiltl.GetMacInfo();
            if (!Dao.GetPostId(ref CenterContral.iPostId))
            {
                CommUiltl.Log("Dao.GetPostId err");
                iPostId = -1;
                return;
            }
            CommUiltl.Log("CenterContral.iPostId:"+ CenterContral.iPostId);
        }
        internal static void SetPostIdFromDb()
        {
            if (!Dao.SetPostId( CenterContral.iPostId))
            {
                CommUiltl.Log("Dao.SetPostId err");
                return;
            }
        }


        //打印
        internal static void UpdateStoreWhouseDefault(string strStoreWhouseDefult)
        {
            Dao.UpdateStoreWhouseDefault(strStoreWhouseDefult);
        }

        internal static void CloseMoneyBox(string closeMoneyBoxComm)
        {
            PrintDialog pd = new PrintDialog();
            bool bResult = RawPrinterHelper.CloseMoneyBox(pd.PrinterSettings.PrinterName);
            CommUiltl.Log("RawPrinterHelper bResult:" + bResult);
        }

        internal static void printOrderMsgToFile(StockOutDTO oStockOutDTO)
        {
            //#region 按格式生成一个txt文件，方便第三步打印
            StreamWriter sw = new StreamWriter(CenterContral.strPrintFilePath, true);

            //#region 拼出小票格式
            sw.WriteLine("欢迎光临速顾优先选鲜食材馆！");
            sw.WriteLine(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            sw.WriteLine("POST机号:" + CenterContral.iPostId);
            sw.WriteLine("单号:" + oStockOutDTO.Base.serialNumber);
            sw.WriteLine("收银员:" + CenterContral.DefaultUserId);

            sw.WriteLine("==============销售==============");
            sw.WriteLine("名称/条码    单价   数量   金额");
            int nums = 20;
            int prices = 12;

            List<StockOutDetail> list = oStockOutDTO.details;
            for (int i = 0; i < list.Count; i++)
            {
                string name = list[i].goodsName.Trim();//获取该行的物品名称
                string num = list[i].actualCount.ToString().Trim();//数量
                string price = list[i].unitPrice.ToString().Trim();//单价

                int numlength = System.Text.Encoding.Default.GetBytes(num).Length;
                if (numlength < nums)
                {
                    num = AddSpace(num, nums - numlength);
                }

                int pricelength = System.Text.Encoding.Default.GetBytes(price).Length;
                if (pricelength < prices)
                {
                    price = AddSpace(price, prices - pricelength);
                }
                sw.WriteLine(name);
                sw.WriteLine("12134                    " + num + "        " + price);

            }

            sw.WriteLine("-----------------------------------------------------");
            //计算合计金额：
            sw.WriteLine("总件数" + "");//合计金额
            sw.WriteLine("应收:" + CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.RecieveFee));//实收现金
            sw.WriteLine("已优惠:" + CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.discountAmount));
            sw.WriteLine("找零:" + CommUiltl.CoverMoneyUnionToStrYuan(oStockOutDTO.Base.ChangeFee));
            if (oStockOutDTO.oMember.memberId > 0)
            {
                sw.WriteLine("会员卡号:");
                sw.WriteLine("本单交易积分:");
                sw.WriteLine("会员卡余额:");
            }
            sw.WriteLine("会员卡号:");
            sw.WriteLine("本单 " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            sw.Close();
            //第三部，进行打印
           
            // 开始打印 
            //this.printDocument.Print();
        }

        internal static void Call_PrinterHistoryWindow()
        {
            CenterContral.Window_Printer_Hostory_Select_Windows.ShowByCenterContral();
        }

        //#region 该函数动态添加空格，对齐小票
        public static string AddSpace(string text, int length)
        {
            text = text.PadRight(length, ' ');
            return text;
        }

        public static string GetTicketInfo()
        {
            string val = "";

            try
            {
                FileStream fsFile = new FileStream(CenterContral.strPrintFilePath, FileMode.Open);

                /* 
                 * 讀取數據最簡單的方法是Read()。此方法將流的下一個字符作為正整數值返回， 
                 * 如果達到了流的結尾處，則返回-1。 
                 */
                StreamReader srReader = new StreamReader(fsFile);
                int iChar;
                iChar = srReader.Read();
                while (iChar != -1)
                {
                    val += (Convert.ToChar(iChar));
                    iChar = srReader.Read();
                }
                srReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return val;
        }
        internal static void CallProductListWindow()
        {
            CenterContral.Window_ProductList.CallShow();
        }
        internal static void PrintLastSotckOutOrder()
        {

            StockOutDTO oJsonList = new StockOutDTO();
            //取出数据
            if (!Dao.GetLasStockOutOrder( ref oJsonList))
            {
                MessageBox.Show("本地查找失败");
                return;
            }
            if (oJsonList.Base.baseDataJson == "")
            {
                MessageBox.Show("未找到订单");
                return;
            }
            StockOutDTO oLastStockmsg = JsonConvert.DeserializeObject<StockOutDTO>(oJsonList.Base.baseDataJson);

            CenterContral.PrintOrder(oLastStockmsg);
            CommUiltl.Log("PrintLastSotckOutOrder ok 打印结束");
        }
       
        internal static void PrintOrder(StockOutDTO oStockOutDTO)
        {
            CenterContral.Window_ProductList.PrintOrder(oStockOutDTO);
        }

        internal static void ShowMoreStockMsg()
        {
            CenterContral.Window_HistoryListWindow.ShowByCenterControl();
            
        }
        internal static string GetStateDscByStockOutBase(StockOutBase oStockOutBase)
        {
            if (oStockOutBase.cloudCloseFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                return "成功";
            }
            if (oStockOutBase.cloudCloseFlag == HttpUtility.CLOUD_SATE_HTTP_FAILD)
            {
                return "同步网络失败";
            }
            if (oStockOutBase.cloudCloseFlag == HttpUtility.CLOUD_SATE_BUSSINESS_FAILD)
            {
                return "同步业务失败";
            }
            if (oStockOutBase.cloudCloseFlag == HttpUtility.CLOUD_SATE_HTTP_INIT)
            {
                return "未同步";
            }
            if (oStockOutBase.cloudCloseFlag == Dao.STOCK_BASE_DELETE_TRUE)
            {
                return "已经删除";
            }
            return "失败";
        }
    }

}
