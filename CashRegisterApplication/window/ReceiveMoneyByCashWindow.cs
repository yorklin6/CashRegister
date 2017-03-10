using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window
{
    public partial class ReceiveMoneyByCashWindow : Form
    {
        public ReceiveMoneyByCashWindow()
        {
            InitializeComponent();
        }

        private void ReceiveMoneyByCash_Load(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.ChangeFee);
        }

        private void ReceiveMoneyByCash_Shown(object sender, EventArgs e)
        {

            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.ChangeFee);
           
        }
        private void _PayOrderByCashRequest()
        {

            CurrentMsg.ReceiveMoneyByCash.Show();
            this.Hide();
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                    
                        _PayOrderByCashRequest();
                     
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                case System.Windows.Forms.Keys.Delete:
                    {
                        this.Hide();
                        CurrentMsg.RecieveMoneyWindows.Show();
                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
