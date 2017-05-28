using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.member
{
    public partial class ReceiveMoneyByMember : Form
    {
        public ReceiveMoneyByMember()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MemberBuy_Load(object sender, EventArgs e)
        {

        }


        private void ReceiveMoneyByMember_Shown(object sender, EventArgs e)
        {
            ShowByReceiveMoneyWindows();
        }

        public void ShowByReceiveMoneyWindows()
        {
            this.Show();
            if (CenterContral.oMember.memberAccount == null || CenterContral.oMember.memberAccount =="")
            {
                //输入会员信息
                CenterContral.Show_MemberInfoWindow_By_RecieveMoeneyByMember();
                this.Hide();
                return;
            }
            //成功后，需要更新订单信息，按照会员价来计算订单总价
            // CenterContral.UpdateStockOrderByMemberInfo();
            ShowWithMemberInfo();
            this.textBox_ReceiveFee.Focus();
        }

        internal void ShowWithMemberInfo()
        {
            UpdateMemberInfor();
           
            _SelectRecieve();
            _ShowGoodsMemberInfo();
            this.Show();
        }
        public void  UpdateMemberInfor(){
            this.textBox_memberAccount.Text = CenterContral.oMember.memberAccount;
            this.textBox_name.Text = CenterContral.oMember.name;
            this.textBox_memberBalance.Text = CommUiltl.CoverMoneyUnionToStrYuan((CenterContral.oMember.balance));
            this.textBox_phone.Text = CenterContral.oMember.phone;
        }
        private void _SelectRecieve()
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount - CenterContral.oStockOutDTO.Base.RecieveFee);
            this.textBox_SupportFee.Text = this.textBox_ReceiveFee.Text;
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(0);

            this.textBox_ReceiveFee.Focus();
            this.textBox_ReceiveFee.SelectionStart = 0;
            this.textBox_ReceiveFee.SelectionLength = this.textBox_ReceiveFee.Text.Length;
        }
        private void _ShowGoodsMemberInfo()
        {
            string str = "\n";
            if (CenterContral.oMember.goodsStringWithoutMemberPrice != "")
            {
                str += "未参加会员价的商品:\n";
                str += CenterContral.oMember.goodsStringWithoutMemberPrice;
            }
            this.lable_goodsStringWithoutMemberPrice.Text = str;
        }
        private void ReceiveMoneyByCashWindow_Enter(object sender, EventArgs e)
        {
            CommUiltl.Log("ReceiveMoneyByCashWindow_Enter");
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
                        returnPreventWindows();
                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //回车事件
        private void enterEvent()
        {
            if (this.textBox_ReceiveFee.Focused)
            {
                //付款
                buttonConfirm_Click(null, null);
            }
        }



        private void textBox_ReceiveFee_TextChanged(object sender, EventArgs e)
        {
            //检查小数点后两位
            string word = this.textBox_ReceiveFee.Text.Trim();
            string[] wordArr = word.Split('.');
            if (wordArr.Length > 1)
            {
                string afterDot = wordArr[1];
                if (afterDot.Length > 2)
                {
                    this.textBox_ReceiveFee.Text = wordArr[0] + "." + afterDot.Substring(0, 2);
                    this.textBox_ReceiveFee.SelectionStart = this.textBox_ReceiveFee.Text.Length;
                }
            }

            if (CommUiltl.IsObjEmpty(this.textBox_ReceiveFee.Text))
            {
                return;
            }
            //金额发生变化就改变下找零多少
            long recieveFee = 0;
            if (!CommUiltl.ConverStrYuanToUnion(this.textBox_ReceiveFee.Text, out recieveFee))
            {
                MessageBox.Show("总价错误:" + this.textBox_ReceiveFee.Text);
                return;
            }
            long change = recieveFee - CenterContral.oStockOutDTO.Base.orderAmount;
            if (change > 0)
            {
                this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(change);
            }
        }
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            long recieveFee = 0;
            if (!CommUiltl.ConverStrYuanToUnion(this.textBox_ReceiveFee.Text, out recieveFee))
            {
                MessageBox.Show("收款错误:" + this.textBox_ReceiveFee.Text);
                return;
            }
            if (recieveFee > CenterContral.oMember.balance )
            {
                MessageBox.Show("余额不足" );
                //跳转到充值页面
                //hide()
                return;
            }

            long change = recieveFee + CenterContral.oStockOutDTO.Base.RecieveFee - CenterContral.oStockOutDTO.Base.orderAmount;
            string showTips = "确认收现金：" + this.textBox_ReceiveFee.Text + " 元";
            if (change < 0)
            {
                long leftFee = 0 - change;
                showTips = "确认只收现金：" + this.textBox_ReceiveFee.Text + " 元"
                 + "\n还剩：" + CommUiltl.CoverMoneyUnionToStrYuan(leftFee) + " 元未收";
            }
            else if (change > 0)
            {
                showTips = "确认收现金：" + this.textBox_ReceiveFee.Text + " 元"
                + "\n应找零：" + CommUiltl.CoverMoneyUnionToStrYuan(change) + " 元";
            }

            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "现金确认",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                //确认支付
                CommUiltl.Log("DialogResult.No recieveFee:" + recieveFee);
                _SelectRecieve();
                return;
            }
            //下单支付
            CommUiltl.Log("DialogResult.Yes recieveFee:" + recieveFee);

            if (!CenterContral.PayOrderByMember(recieveFee))
            {
                return;
            }

            this.UpdateMemberInfor();
            CommUiltl.Log("PayOrderByCash end:" + recieveFee);
            MessageBox.Show("支付" + CommUiltl.CoverMoneyUnionToStrYuan(recieveFee) + "元现金成功");
            CenterContral.ControlWindowsAfterPay();
            this.Hide();
            return;
        }

        private void textBox_ReceiveFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommUiltl.Log("Keys:" + e.KeyChar);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                //非数字，非控制，非.都认为不允许输入
                CommUiltl.Log("1 true:" + e.KeyChar);
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                // only allow one decimal point
                //只允许一个小数点
                CommUiltl.Log("2 true:" + e.KeyChar);
                e.Handled = true;
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_OrderFee_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ChangeFee_TextChanged(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void returnPreventWindows()
        {
            CenterContral.Window_RecieveMoney.Show();
            this.Hide();
        }
     
        private void ReceiveMoneyByMember_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            returnPreventWindows();
            CenterContral.Window_ReceiveMoneyByMember = new ReceiveMoneyByMember();
        }
    }
}
