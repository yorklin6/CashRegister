using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.Member
{
    public partial class RechargeMoneyForMember : Form
    {
        public RechargeMoneyForMember()
        {
            InitializeComponent();
        }

        internal void ShowWithMemberInfo()
        {
            this.textBox_memberAccount.Text = CurrentMsg.oMember.memberAccount;
            this.textBox_name.Text = CurrentMsg.oMember.name;
            this.textBox_memberBalance.Text = CommUiltl.CoverMoneyUnionToStrYuan((CurrentMsg.oMember.memberBalance));
            this.textBox_phone.Text = CurrentMsg.oMember.phone;

            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CurrentMsg.oStockOutDTO.Base.orderAmount - CurrentMsg.oStockOutDTO.Base.RecieveFee);

            this.textBox_ReceiveFee.Focus();
            this.textBox_ReceiveFee.SelectionStart = 0;
            this.textBox_ReceiveFee.SelectionLength = this.textBox_ReceiveFee.Text.Length;
            this.Show();
        }



        private void RechargeMoneyForMember_Load(object sender, EventArgs e)
        {
            ShowRechargeMoneyWindow();
        }
        private void RechargeMoneyForMember_Shown(object sender, EventArgs e)
        {
            ShowRechargeMoneyWindow();
        }
        
        public void ShowByProductListWindow()
        {
            ShowRechargeMoneyWindow();
        }
        public void ShowRechargeMoneyWindow()
        {
            this.Show();
            if (CurrentMsg.oMember.memberAccount == null || CurrentMsg.oMember.memberAccount == "")
            {
                CurrentMsg.Show_MemberInfoWindow_By_RechargeMoeneyByMember();
                return;
            }
            this.textBox_ReceiveFee.Focus();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        enterEvent();
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                    {
                        this.Hide();
                        CurrentMsg.Window_ProductList.Show();
                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
         protected void enterEvent()
        {
            buttonConfirm_Click(null, null);
        }
         protected void buttonConfirm_Click(object sender, EventArgs e)
        {
            //回车事件

        }
    }
}
