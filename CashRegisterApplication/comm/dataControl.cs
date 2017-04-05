using CashRegisterApplication.model;
using CashRegiterApplication;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegisterApplication.comm
{
    class DataControl
    {
        public const int PAY_STATE_INIT = 0;
        public const int PAY_STATE_SUCCESS = 1;

        public const int PAY_TYPE_CASH = 1;

        public const int STOCK_BASE_STATUS_INIT = 0;
        public const int STOCK_BASE_STATUS_NORMAL = 1;
        public const int STOCK_BASE_STATUS_OUT = 2;

        public const int CLOUD_SATE_ORDER_GENERATE_INIT = 0;
        public const int CLOUD_SATE_ORDER_GENERATE_SUCCESS = 1;//云端生成订单成功
        public const int CLOUD_SATE_ORDER_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_ORDER_UPDATE_SUCCESS = 3;//云端更新订单成功
        public const int CLOUD_SATE_ORDER_UPDATE_FAILED = 4;

        public const int CLOUD_SATE_ORDER_CLOSE_SUCCESS = 5;//云端关闭订单成功
        public const int CLOUD_SATE_ORDER_CLOSE_FAILED = 6;

        public const int CLOUD_SATE_PAY_GENERATE_INIT = 0;
        public const int CLOUD_SATE_PAY_GENERATE_SUCCESS = 1;
        public const int CLOUD_SATE_PAY_GENERATE_FAILED = 2;

        public const int CLOUD_SATE_PAY_UPDATE_SUCCESS = 3;
        public const int CLOUD_SATE_PAY_UPDATE_FAILED = 4;


        //public static bool GenerateOrder(StockOutDTO oStockOutDTO, ref StockOutDTORespone oRespond)
        //{
        //    if (!Dao.GenerateOrder(oStockOutDTO))
        //    {
        //        return false;
        //    }

        //    if (!HttpUtility.GenerateOrder(oStockOutDTO, ref oRespond))
        //    {
        //        oStockOutDTO.Base.cloudStaus = CLOUD_SATE_ORDER_GENERATE_FAILED;
        //        Dao.UpdateOrderCloudState(oStockOutDTO);
        //        //return false;
        //    }
        //    else
        //    {
        //        oStockOutDTO.Base.stockOutId = oRespond.data.Base.stockOutId;
        //        Dao.UpdateStockId(oStockOutDTO);
        //        oStockOutDTO.Base.cloudStaus = CLOUD_SATE_ORDER_GENERATE_SUCCESS;
        //        Dao.UpdateOrderCloudState(oStockOutDTO);
        //    }
        //    return true;
        //}
    }
}
