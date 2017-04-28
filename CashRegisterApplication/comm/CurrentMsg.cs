using CashRegisterApplication.model;
using CashRegisterApplication.window;
using CashRegisterApplication.window.member;
using CashRegisterApplication.window.Member;
using CashRegiterApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.comm
{
    
    public static class CurrentMsg
    {
        public static bool initFlag=false;
        public static ProductListWindow Window_ProductList;//全局窗口
        public static RecieveMoneyWindow Window_RecieveMoney;//收款窗口
        public static ReceiveMoneyByCashWindow Window_ReceiveMoneyByCash;//现金收款窗口
        public static RecieveMoneyByWeixinWindow Window_RecieveMoneyByWeixin ;//微信收款窗口
        public static ReceiveMoneyByMember Window_ReceiveMoneyByMember;//会员收款窗口
        public static RechargeMoneyForMember Window_RechargeMoneyForMember;//充值会员窗口
        public static MemberInfoWindows Window_MemberInfoWindows;//输入会员弹窗



        public static StockOutDTO oStockOutDTO ;//当前单据信息
        public static StockOutDTORespone oStockOutDToRespond;
        public static HttpBaseRespone oHttpRespone;

        public static LocalSaveStock oLocalSaveStock;//挂单信息



        public static Member oMember ;//用户账户

        public static PayWay oPayWay ;//商品列表

        public const int POST_ID = 12345;

        public const int PAY_STATE_INIT = 0;
        public const  int PAY_STATE_SUCCESS = 1;
        public const int PAY_TYPE_CASH = 1;

     

        public const int STOCK_BASE_STATUS_INIT = 0;
        public const int STOCK_BASE_STATUS_NORMAL = 1;
        public const int STOCK_BASE_STATUS_OUT = 2;



        public const int CLOUD_SATE_PAY_SUCESS = 0;
        public const int CLOUD_SATE_PAY_FAILD = 0;



        public const int STOCK_BASE_DB_GENERATE_INIT = 0;
        public const int STOCK_BASE_DB_GENERATE_DONE= 1;//已经存在DB


        public const int CLOUD_SATE_PAY_GENERATE_INIT = 0;
        public const int CLOUD_SATE_PAY_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_PAY_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_PAY_UPDATE_SUCCESS = 3;


        public static int PRODUCTlIST_WINDOW = 0;//商品列表页
        public static int MEMBER_RECHAREGE_WINDOWS = 1;//支付页面
        public static int MEMBER_RECIEVE_MONEY_WINDOWS = 2;//会员收款页面


        public static int flagCallShowMember = MEMBER_RECIEVE_MONEY_WINDOWS;

        public static int flagCallShowRecharge = PRODUCTlIST_WINDOW;
        //****************************会员收款和充值
        //显示会员收款
        internal static void Show_MemberInfoWindow_By_RecieveMoeneyByMember()
        {
            flagCallShowMember = MEMBER_RECIEVE_MONEY_WINDOWS;
            CurrentMsg.Window_MemberInfoWindows.ShowWhithMember();
        }
        internal static void Show_MemberInfoWindow_By_RechargeMoeneyByMember()
        {
            flagCallShowMember = MEMBER_RECHAREGE_WINDOWS;
            CurrentMsg.Window_MemberInfoWindows.ShowWhithMember();
        }


        //当获取会员信息成功后进行显示页面
        internal static void ShowWindowWhenGetMemberSuccess()
        {
            if (flagCallShowMember == MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CurrentMsg.Window_ReceiveMoneyByMember.ShowWithMemberInfo();
                return;
            }
            if (flagCallShowMember == MEMBER_RECHAREGE_WINDOWS)
            {
                CurrentMsg.Window_RechargeMoneyForMember.ShowWithMemberInfo();
                return;
            }
        }
        //更新会员价
        internal static void UpdateStockOrderByMemberInfo()
        {
            //StockOutDTO
            _CaculateMemberPrice();
            CurrentMsg.GetGoodsStringWithoutMemberPrice();
            return;
        }
        internal static void _CaculateMemberPrice()
        {
            long totalPrice = 0;
            for (var i=0;i< CurrentMsg.oStockOutDTO.details.Count;++i)
            {
                //设置会员价
                if (CurrentMsg.oStockOutDTO.details[i].unitPrice == CurrentMsg.oStockOutDTO.details[i].cloudProductPricing.retailPrice)
                {
                    CurrentMsg.oStockOutDTO.details[i].unitPrice = CurrentMsg.oStockOutDTO.details[i].cloudProductPricing.memberPrice;
                }
                totalPrice += CurrentMsg.oStockOutDTO.details[i].unitPrice;
            }
            //
            CurrentMsg.oStockOutDTO.Base.orderAmount = totalPrice;
            CurrentMsg.Window_ProductList.SetProductListWindowByStockOut(CurrentMsg.oStockOutDTO);
            //更新数据库里面订单信息
            if(!Dao.updateRetailStock(CurrentMsg.oStockOutDTO))
            {
                return;
            }
        }
        internal static void GetGoodsStringWithoutMemberPrice()
        {
            string strTmp = "";
            for (var i = 0; i < CurrentMsg.oStockOutDTO.details.Count; ++i)
            {
                //设置会员价
                if (CurrentMsg.oStockOutDTO.details[i].unitPrice != CurrentMsg.oStockOutDTO.details[i].cloudProductPricing.retailPrice)
                {
                    //strTmp +="id:"+CurrentMsg.oStockOutDTO.details[i].goodsId+" ";
                    strTmp += CurrentMsg.oStockOutDTO.details[i].goodsName;
                    strTmp += " 会员价:" + CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.oStockOutDTO.details[i].cloudProductPricing.memberPrice);
                    strTmp += " 现价:" + CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.oStockOutDTO.details[i].unitPrice);
                    strTmp += "\n";
                }
               
            }
            CurrentMsg.oMember.goodsStringWithoutMemberPrice = strTmp;

        }
        //***************************充值相关

        internal static void ShowWindows_RechargeMoneyForMember()
        {
            flagCallShowRecharge = PRODUCTlIST_WINDOW;
            Window_RechargeMoneyForMember.ShowByProductListWindow();
        }

        //充值后返回
        internal static void ControlWindowsAfterRecharge()
        {
            if (flagCallShowRecharge == PRODUCTlIST_WINDOW)
            {
                CurrentMsg.Window_ProductList.Show();
            }
            if (flagCallShowRecharge == MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CurrentMsg.Window_ProductList.Show();
            }
        }

        //当会员取消界面
        internal static void ShowWindowWhenMemberInfoCancel()
        {
           
            if (flagCallShowMember == MEMBER_RECIEVE_MONEY_WINDOWS)
            {
                CurrentMsg.Window_RecieveMoney.Show();
                return;
            }
            if (flagCallShowMember == MEMBER_RECHAREGE_WINDOWS)
            {
                CurrentMsg.Window_ProductList.Show();
                return;
            }
        }

        public const int CLOUD_SATE_PAY_UPDATE_FAILED = 4;

        public static void Init()
        {
            if (initFlag)
            {
                return;
            }

            //Window_ProductList = new ProductListWindow();//全局窗口
            Window_RecieveMoney = new RecieveMoneyWindow();//收款窗口
            Window_ReceiveMoneyByCash = new ReceiveMoneyByCashWindow();//现金收款窗口
            Window_RecieveMoneyByWeixin = new RecieveMoneyByWeixinWindow();//微信收款窗口
            Window_ReceiveMoneyByMember = new ReceiveMoneyByMember();
            Window_RechargeMoneyForMember = new RechargeMoneyForMember();

            Window_MemberInfoWindows = new MemberInfoWindows();

            oStockOutDTO = new StockOutDTO();//商品列表
            oStockOutDToRespond = new StockOutDTORespone();
            oHttpRespone = new HttpBaseRespone();
            oMember = new Member();
            oPayWay = new PayWay();


            initFlag = true;
            
            oLocalSaveStock = new LocalSaveStock();

            Dao.ConnecSql();
            _GetSaveStock();
        }


        public static void _GetSaveStock()
        {
            //查出挂单的单据
            StockOutDTO oState =new StockOutDTO();
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



        public static void Clean()
        {
            oStockOutDTO = new StockOutDTO();//商品列表
            oStockOutDToRespond = new StockOutDTORespone();
        }


        public static void ControlWindowsAfterPay()
        {
            CommUiltl.Log("ControlWindowsAfterPay" );
            if (CurrentMsg.oStockOutDTO.Base.RecieveFee < CurrentMsg.oStockOutDTO.Base.orderAmount)
            {
                CommUiltl.Log("Window_RecieveMoney Show");
                Window_RecieveMoney.ShowPaidMsg();
                return;
            }
            //Order.RecieveFee >= Order.orderAmount 说明已经收钱完毕
            if (!CloseOrderWhenPayAllFee())
            {
                return ;
            }
            Window_ProductList.CloseOrderByControlWindow();
        }
        //***********************************关闭订单***************************
        internal static bool CloseOrderWhenPayAllFee()
        {
            CurrentMsg.oStockOutDTO.Base.status = STOCK_BASE_STATUS_OUT;
            SetSaveFlag();//挂单->关单
            CurrentMsg.oStockOutDTO.Base.cloudCloseFlag = HttpUtility.CloseOrderWhenPayAllFee(CurrentMsg.oStockOutDTO, ref CurrentMsg.oHttpRespone);
            if (!Dao.UpdateOrderCloudState(CurrentMsg.oStockOutDTO))
            {
                return false;
            }
            return true;
        }

        internal static void SetSaveFlag()
        {
            if (CurrentMsg.oStockOutDTO.Base.localSaveFlag == Dao.STOCK_BASE_SAVE_FLAG_SAVING)
            {
                CurrentMsg.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_CLOSE;
            }
        }
        //***********************************生成订单***************************
        internal static bool IsCurrentOrderInit()
        {
            return CurrentMsg.oStockOutDTO.Base.dbGenerateFlag == CurrentMsg.STOCK_BASE_DB_GENERATE_INIT;
        }
                                                                                                                                        
        internal static bool GenerateOrder(string strProductList)
        {
            if (CurrentMsg.oStockOutDTO.details.Count == 0)
            {
                CommUiltl.Log("CurrentMsg.oStockOutDTO.details.Count == 0]");
                return true;
            }
            if (IsCurrentOrderInit())
            {
                CurrentMsg.oStockOutDTO.Base.ProductList = strProductList;
                CommUiltl.Log("Order.OrderCode ==  empty GenerateOrder ");
                CurrentMsg.oStockOutDTO.Base.generateSeariseNumber();

                CurrentMsg.oStockOutDTO.Base.cloudAddFlag = HttpUtility.GenerateOrder(CurrentMsg.oStockOutDTO, ref CurrentMsg.oStockOutDToRespond);
                CurrentMsg.oStockOutDTO.Base.cloudAddFlag = HttpUtility.CLOUD_SATE_HTTP_FAILD;

                if (CurrentMsg.oStockOutDTO.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS )
                {
                    CurrentMsg.oStockOutDTO.Base.stockOutId = CurrentMsg.oStockOutDToRespond.data.Base.stockOutId;
                    SetStockDetailByHttpRespone(oStockOutDToRespond.data,ref CurrentMsg.oStockOutDTO );
                }
                CurrentMsg.oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CurrentMsg.oStockOutDTO);
                CurrentMsg.oStockOutDTO.Base.dbGenerateFlag = CurrentMsg.STOCK_BASE_DB_GENERATE_DONE;//新增
                //插入本地数据库表
                if (!Dao.GenerateOrder(CurrentMsg.oStockOutDTO))
                {
                    return false;
                }
                return true;
            }
            //更新订单
            if (strProductList != null && 0 != CurrentMsg.oStockOutDTO.Base.ProductList.CompareTo(strProductList))
            {
                CommUiltl.Log(" strProductList is modify [" + CurrentMsg.oStockOutDTO.Base.ProductList + "] -> [" + strProductList + "]");
                CurrentMsg.oStockOutDTO.Base.ProductList = strProductList;
                CurrentMsg.oStockOutDTO.Base.cloudUpdateFlag = HttpUtility.updateRetailStock(CurrentMsg.oStockOutDTO, ref CurrentMsg.oStockOutDToRespond);

                if (CurrentMsg.oStockOutDTO.Base.cloudAddFlag == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
                {
                    
                }else
                {
                    CurrentMsg.oStockOutDTO.Base.baseDataJson = JsonConvert.SerializeObject(CurrentMsg.oStockOutDTO);
                }

                if (!Dao.updateRetailStock(CurrentMsg.oStockOutDTO))
                {
                    return false;
                }

                return true;
            }
            CommUiltl.Log(" not modify strProductList:"+ strProductList);
            return true;
        }

        //************************挂单***********************
        internal static bool SaveStock(string strProductList)
        {
            //生成订单，状态为挂单
            CurrentMsg.oStockOutDTO.Base.ProductList = strProductList;
            CurrentMsg.oStockOutDTO.Base.localSaveFlag = Dao.STOCK_BASE_SAVE_FLAG_SAVING;
            if (!CurrentMsg.GenerateOrder(strProductList))
            {
                return false;
            }
            addStockToLocal(CurrentMsg.oStockOutDTO);
            return true;
        }
        internal static void addStockToLocal(StockOutDTO oStockOutDTO)
        {
            CommUiltl.Log("addStockToLocal CurrentMsg.oSaveSotckOut.listStock.Count:" + CurrentMsg.oLocalSaveStock.listStock.Count);
            for (int i=0;i< CurrentMsg.oLocalSaveStock.listStock.Count;++i)
            {
                if (oStockOutDTO.Base.serialNumber == CurrentMsg.oLocalSaveStock.listStock[i].Base.serialNumber)
                {
                    CommUiltl.Log("addStockToLocal found" );
                    CurrentMsg.oLocalSaveStock.listStock[i] = oStockOutDTO;//如果是已经存在挂单中的订单，那么就替换下
                    return;
                }
            }
            CurrentMsg.oLocalSaveStock.listStock.Add(oStockOutDTO);
        }
        public static int CurrentStockIndex = -1;



        internal static void GetSaveOrderToCurrentMsg()
        {
            if (CurrentMsg.oLocalSaveStock.listStock.Count == 0)
            {
                return;
            }
            ++CurrentStockIndex;
            CurrentStockIndex = CurrentStockIndex % CurrentMsg.oLocalSaveStock.listStock.Count;
            CurrentMsg.oStockOutDTO = CurrentMsg.oLocalSaveStock.listStock[CurrentStockIndex];
        }

        internal static void SetStockDetailByHttpRespone(StockOutDTO http,ref StockOutDTO Db)
        {
            if (oStockOutDToRespond.data.details.Count != CurrentMsg.oStockOutDTO.details.Count)
            {
                //说明是有问题的
                CommUiltl.Log("oRespond.data.details.Count[" + oStockOutDToRespond.data.details.Count + "] != CurrentMsg.oStockOutDTO.details.Count [" + CurrentMsg.oStockOutDTO.details.Count + "]");
                MessageBox.Show("下单异常，请联系后台同学检查下单返回[" + oStockOutDToRespond.data.details.Count + "] != CurrentMsg.oStockOutDTO.details.Count [" + CurrentMsg.oStockOutDTO.details.Count + "]");
            }
            else
            {
                for (int i = 0; i < oStockOutDToRespond.data.details.Count; ++i)
                {
                    CurrentMsg.oStockOutDTO.details[i].id = oStockOutDToRespond.data.details[i].id;
                }
            }
        }
        internal static bool PayOrderByCash(long recieveFee)
        {
            CurrentMsg.oPayWay.payType = PAY_TYPE_CASH;
            CurrentMsg.oPayWay.payAmount = recieveFee;
            CurrentMsg.oPayWay.generatePayOrderNumber();
            CurrentMsg.oPayWay.serialNumber = CurrentMsg.oStockOutDTO.Base.serialNumber;
            CurrentMsg.oPayWay.payStatus=  CurrentMsg.PAY_STATE_SUCCESS;
            CurrentMsg.oPayWay.cloudState = CurrentMsg.CLOUD_SATE_PAY_SUCESS ;
            PayWayHttpRequet oPayWayHttpRequet = new PayWayHttpRequet();
            oPayWayHttpRequet.memberId = CurrentMsg.oMember.memberId;
            oPayWayHttpRequet.list.Add(CurrentMsg.oPayWay);
            CurrentMsg.oPayWay.cloudState = HttpUtility.PayOrdr(oPayWayHttpRequet);
            if (!Dao.GeneratePay(CurrentMsg.oPayWay))
            {
                return false;
            }
            //修改环境变量，表示这笔单支付成功
            PayWay oPayWay = new PayWay();
            CurrentMsg.oStockOutDTO.addPayWay(CurrentMsg.oPayWay);
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            return true;
        }
        internal static bool PayOrderByMember(long recieveFee)
        {
            CurrentMsg.oPayWay.payType = PAY_TYPE_CASH;
            CurrentMsg.oPayWay.payAmount = recieveFee;
            CurrentMsg.oPayWay.generatePayOrderNumber();
            CurrentMsg.oPayWay.serialNumber = CurrentMsg.oStockOutDTO.Base.serialNumber;
            CurrentMsg.oPayWay.payStatus = CurrentMsg.PAY_STATE_SUCCESS;
            CurrentMsg.oPayWay.cloudState = CurrentMsg.CLOUD_SATE_PAY_SUCESS;
            PayWayHttpRequet oPayWayHttpRequet = new PayWayHttpRequet();
            oPayWayHttpRequet.memberId = CurrentMsg.oMember.memberId;
            oPayWayHttpRequet.list.Add(CurrentMsg.oPayWay);
            CurrentMsg.oPayWay.cloudState = HttpUtility.PayOrdr(oPayWayHttpRequet);
            if (!Dao.GeneratePay(CurrentMsg.oPayWay))
            {
                return false;
            }
            //修改环境变量，表示这笔单支付成功
            PayWay oPayWay = new PayWay();
            CurrentMsg.oStockOutDTO.addPayWay(CurrentMsg.oPayWay);
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            return true;
        }
        //充值
        internal static bool RechargeMoneyByMember(long recieveFee)
        {
            //充值金
            Member oRechargeMember = new Member();
            oRechargeMember.memberId= CurrentMsg.oMember.memberId;
            oRechargeMember.memberBalance = recieveFee;
            oRechargeMember.name = CurrentMsg.oMember.name;
            oRechargeMember.memberAccount=CurrentMsg.oMember.memberAccount;
            oRechargeMember.reqJson = JsonConvert.SerializeObject(oRechargeMember);
            //请求后台充值
            oRechargeMember.cloudState = HttpUtility.memberRecharge(oRechargeMember);

            long beforeMberBalance = CurrentMsg.oMember.memberBalance;
            //重新拉会员信息
            CurrentMsg.GetMemberByMemberAccount(CurrentMsg.oMember.memberAccount);
            long afterMemberAccount = CurrentMsg.oMember.memberBalance;
            //记录流水
            Dao.memberRecharge(oRechargeMember, beforeMberBalance, afterMemberAccount, recieveFee);

            if (oRechargeMember.cloudState != HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                return false;
            }
            return true;
        }
        
        //************************会员信息***********************
        internal static bool GetMemberByMemberAccount(string strMemberAccount)
        {
            MemberHttpRespone oMember = new MemberHttpRespone();
            int iMemberRet=HttpUtility.GetMemberByMemberAccount(strMemberAccount,ref oMember);
            if (iMemberRet == HttpUtility.CLOUD_SATE_HTTP_SUCESS)
            {
                CurrentMsg.oMember = oMember.data.list[0];
                return true;
            }
            if (iMemberRet == HttpUtility.CLOUD_SATE_HTTP_FAILD)
            {
                MessageBox.Show(HttpUtility.lastErrorMsg);
                return false;
            }
            MessageBox.Show("业务错误："+HttpUtility.lastErrorMsg);
            return false;
        }

    }

}
