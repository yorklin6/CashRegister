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
            oReceiveMoneyByCash = new ReceiveMoneyByCash();
            oRecieveMoneyByWeixin = new RecieveMoneyByWeixin();
        }
        public ProductListWindow gProductListWindow ;
        public ReceiveMoneyByCash oReceiveMoneyByCash;
        public RecieveMoneyByWeixin oRecieveMoneyByWeixin;
        public void SetProductListWindow( ProductListWindow oProductListWindow)
        {
            gProductListWindow = oProductListWindow;
        }
        private void RecieveMoneyWindows_Shown(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.ChangeFee);

            //this.textBox_ReceiveFee.SelectionStart = 0;
            //this.textBox_ReceiveFee.SelectionLength = this.textBox_ReceiveFee.Text.Length;
        }

        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
         
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
            //int orderFee = 0, recieveFee = 0, changeFee = 0;
            //if (!CommUiltl.ConverStrYuanToFen(this.textBox_ReceiveFee.Text, out recieveFee))
            //{
            //    MessageBox.Show("实收错误:" + this.textBox_ReceiveFee.Text);
            //    return;
            //}
            //if (!CommUiltl.ConverStrYuanToFen(this.textBox_OrderFee.Text, out orderFee))
            //{
            //    MessageBox.Show("总价错误:" + this.textBox_OrderFee.Text);
            //    return;
            //}
            //changeFee = recieveFee - orderFee;
            //if (changeFee < 0)
            //{
            //    MessageBox.Show("错误：收钱额度小于总价");
            //    return;
            //}

            if (gProductListWindow != null)
            {
                gProductListWindow.Windows_SetFeeByRecieveFeeWindows();
                this.Hide();
                gProductListWindow.Show();
            }
         
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
                        CommUiltl.Log("Keys.Enter");
                        _SubmitPrice();
                        oReceiveMoneyByCash.Show();
                        this.Hide();
                        break;

                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        CommUiltl.Log("Keys.Enter");
                        _SubmitPrice();
                        oReceiveMoneyByCash.Show();
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
