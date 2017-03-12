using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CashRegisterApplication.comm;
using CashRegiterApplication;

namespace CashRegisterApplication.window
{
    public partial class RecieveMoneyWindow : Form
    {
        public RecieveMoneyWindow()
        {
            InitializeComponent();
       
        }
      
        private void RecieveMoneyWindows_Shown(object sender, EventArgs e)
        {
            //注意，正常流程下面，这个窗体只有未收款的时候显示。
            CommUiltl.Log("RecieveMoneyWindows_Shown");
            this.ActiveControl = this.buttonCash;
            SetFeeForTextBox();
        }

        public void SetFeeForTextBox()
        {
           
            //显示未收款
            int leftMoney = CurrentMsg.Order.OrderFee - CurrentMsg.Order.RecieveFee;
            if (leftMoney < 0)
            {
                leftMoney = 0;
            }
            CommUiltl.Log("leftMoney:"+ leftMoney);
            this.textBox_LeftFee.Text = CommUiltl.CoverMoneyFenToString(leftMoney);
            //其他订单信息
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.OrderFee);
            this.textBox_RecieveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.RecieveFee);
        }

        public void ShowPaidMsg()
        {
            CommUiltl.Log("已支付列表");
            string strPaidInfo="已支付列表：\n";
            foreach (var item in CurrentMsg.Order.listPayInfo)
            {
                if (item.payType== PayWay.PAY_TYPE_CASH)
                {
                    strPaidInfo += PayWay.PAY_TYPE_CASH_DESC+":" + CommUiltl.CoverMoneyFenToString(item.fee)+"元\n";
                }
                else if (item.payType == PayWay.PAY_TYPE_WEIXIN)
                {
                    strPaidInfo += PayWay.PAY_TYPE_WEIXIN_DESC + ":" + CommUiltl.CoverMoneyFenToString(item.fee) + "元\n";
                }
                else if (item.payType == PayWay.PAY_TYPE_ZHIFUBAO)
                {
                    strPaidInfo += PayWay.PAY_TYPE_ZHIFUBAO_DESC + ":" + CommUiltl.CoverMoneyFenToString(item.fee) + "元\n";
                }
            }
            this.labelPaidMsg.Text = strPaidInfo;
            SetFeeForTextBox();
        }

        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
            CommUiltl.Log("RecieveMoneyWindows_Load");
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            CommUiltl.Log("button_Confirm_Click");
            _CheckFee();
        }
       
        private void textBox_ReceiveFee_Leave(object sender, EventArgs e)
        {
            CommUiltl.Log("textBox_ReceiveFee_Leave");
            _CheckFee();
 
        }

        private void _CheckFee()
        {
            CommUiltl.Log("_CheckFee");
            return;
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:"+ keyData);
            switch (keyData)
            {
        
                case System.Windows.Forms.Keys.Enter:
                case System.Windows.Forms.Keys.D1:
                case System.Windows.Forms.Keys.NumPad1:
                case System.Windows.Forms.Keys.Oem1:
                    {
                        buttonCash_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        buttonWeixin_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                case System.Windows.Forms.Keys.Delete:
                    {
                        this.Hide();
                        CurrentMsg.Window_ProductList.Show();
                        CurrentMsg.Window_ProductList.CloseOrder();
                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonCash_Click(object sender, EventArgs e)
        {
            _CheckFee();
            CurrentMsg.Window_ReceiveMoneyByCash.Show();
            CurrentMsg.Window_ReceiveMoneyByCash.SetTextBox();
            this.Hide();
        }

        private void buttonWeixin_Click(object sender, EventArgs e)
        {
            _CheckFee();
            CurrentMsg.Window_RecieveMoneyByWeixin.Show();
            this.Hide();
        }
    }
}
