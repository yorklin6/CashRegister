using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.productList
{
    public partial class DiscountWindows : Form
    {
        public DiscountWindows()
        {
            InitializeComponent();
        }

        private void DiscountWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            returnPreventWindows();
            CenterContral.Window_DiscountWindows = new DiscountWindows();
        }

        private void returnPreventWindows()
        {
            CenterContral.Window_ProductList.Show();
            this.Hide();

        }

        private void DiscountWindows_Load(object sender, EventArgs e)
        {

        }

        public void ShowWithDiscountMsg()
        {
            this.textBox_allGoodsMoneyAmount.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount);
            this.textBox_discountRate.Text = CommUiltl.CoveDiscountDiv100(CenterContral.oStockOutDTO.Base.discountRate);
            this.textBox_discountAmount.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.discountAmount);
            this.Show();
            focuseDiscount();
        }

        private void focuseDiscount()
        {
            this.textBox_discountRate.Focus();
            this.textBox_discountRate.SelectionStart = 0;
            this.textBox_discountRate.SelectionLength = this.textBox_discountRate.Text.Length;
            CommUiltl.Log("this.textBox_discountRate.Text:" + this.textBox_discountRate.Text);
            CommUiltl.Log("this.SelectionLength.Text:" + this.textBox_discountRate.Text.Length);
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

        private void enterEvent()
        {
            button_loggin_Click(null, null);
            return;
        }


        private void button_loggin_Click(object sender, EventArgs e)
        {
            //参数检查
            if (this.textBox_allGoodsMoneyAmount.Text != CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount))
            {
                MessageBox.Show("金额有问题，请重试" );
                ShowWithDiscountMsg();
                return;
            }


            long discountRate = 0;
            if (!CommUiltl.Cover2PercentToUnion(this.textBox_discountRate.Text, out discountRate))
            {
                MessageBox.Show("折扣率错误:" + this.textBox_discountRate.Text);
                return;
            }

            //确认折扣

            string showTips = "确认折扣率：" + this.textBox_discountRate.Text + "%";
           

            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "折扣率确认",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
            }
            //确认支付
            CommUiltl.Log("discountRate:" + discountRate + "%");
            CenterContral.UpdateDiscountRate(discountRate,ref CenterContral.oStockOutDTO);
            returnPreventWindows();
            return;
        }

        private void textBox_discountRate_TextChanged(object sender, EventArgs e)
        {
            //检查小数点后两位
            string word = this.textBox_discountRate.Text.Trim();
            string[] wordArr = word.Split('.');
            if (wordArr.Length > 1)
            {
                string afterDot = wordArr[1];
                if (afterDot.Length > 2)
                {
                    this.textBox_discountRate.Text = wordArr[0] + "." + afterDot.Substring(0, 2);
                    this.textBox_discountRate.SelectionStart = this.textBox_discountRate.Text.Length;
                }
            }

            if (CommUiltl.IsObjEmpty(this.textBox_discountRate.Text))
            {
                return;
            }
            long discountRate = 0;
            if (!CommUiltl.Cover2PercentToUnion(this.textBox_discountRate.Text, out discountRate))
            {
                MessageBox.Show("折扣率错误:" + this.textBox_discountRate.Text);
                this.focuseDiscount();
                return;
            }
            long afterAmount = CenterContral.GetMoneyAmountByDiscountRate(CenterContral.oStockOutDTO ,discountRate);
            long discountAmount = CenterContral.oStockOutDTO.Base.allGoodsMoneyAmount - afterAmount;
            this.textBox_discountAmount.Text = CommUiltl.CoverMoneyUnionToStrYuan(discountAmount);
        }
    }
}
