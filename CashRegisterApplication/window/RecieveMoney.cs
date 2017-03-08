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
    public partial class RecieveMoneyWindows : Form
    {
        public RecieveMoneyWindows()
        {
            InitializeComponent();
            int recieveFee = 900; int orderFee = 800;
            SetFeeByProductListWindows(recieveFee, orderFee);
            oReceiveMoneyByCash = new ReceiveMoneyByCash();
        }
        public ProductListWindow gProductListWindow ;
        public ReceiveMoneyByCash oReceiveMoneyByCash;
        public void SetProductListWindow( ProductListWindow oProductListWindow)
        {
            gProductListWindow = oProductListWindow;
        }
        private void RecieveMoneyWindows_Shown(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.SelectionStart = 0;
            this.textBox_ReceiveFee.SelectionLength = this.textBox_ReceiveFee.Text.Length;
        }

        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
         
        }

        public void SetFeeByProductListWindows(int recieveFee, int orderFee)
        {
            int changeFee = recieveFee - orderFee;

            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(recieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(orderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(changeFee);
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            CommUiltl.Log("button_Confirm_Click");
            _SubmitPrice();
        }

       

        private void textBox_ReceiveFee_Leave(object sender, EventArgs e)
        {
            CommUiltl.Log("textBox_ReceiveFee_Leave");
            _SubmitPrice();
 
        }

        private void _SubmitPrice()
        {
            CommUiltl.Log("_SubmitPrice");
            int orderFee = 0, recieveFee = 0, changeFee = 0;
            if (!CommUiltl.ConverStrYuanToFen(this.textBox_ReceiveFee.Text, out recieveFee))
            {
                MessageBox.Show("实收错误:" + this.textBox_ReceiveFee.Text);
                return;
            }
            if (!CommUiltl.ConverStrYuanToFen(this.textBox_OrderFee.Text, out orderFee))
            {
                MessageBox.Show("总价错误:" + this.textBox_OrderFee.Text);
                return;
            }
            changeFee = recieveFee - orderFee;
            if (changeFee < 0)
            {
                MessageBox.Show("错误：收钱额度小于总价");
                return;
            }

            if (gProductListWindow != null)
            {
                gProductListWindow.Windows_SetFeeByRecieveFeeWindows(recieveFee);
                this.Hide();
                gProductListWindow.Show();
            }
            oReceiveMoneyByCash.Show();
            return;
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys.Escape"+ keyData);
            switch (keyData)
            {
        
                case System.Windows.Forms.Keys.Enter:
                    {
                        CommUiltl.Log("Keys.Enter");
                        _SubmitPrice();
                        break;

                    }

                case System.Windows.Forms.Keys.Escape:
                case System.Windows.Forms.Keys.Delete:
                    {
                        CommUiltl.Log("Keys.Escape");
                        this.Hide();
                        gProductListWindow.Show();
                        break;
                    }

                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
