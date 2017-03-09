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
    public partial class ReceiveMoneyByCash : Form
    {
        public ReceiveMoneyByCash()
        {
            InitializeComponent();
        }

        private void ReceiveMoneyByCash_Load(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.ChangeFee);
        }

        private void ReceiveMoneyByCash_Shown(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentOrderMsg.Info.ChangeFee);
        }
    }
}
