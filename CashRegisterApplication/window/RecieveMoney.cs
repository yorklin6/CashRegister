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
        }
      
        private void RecieveMoneyWindows_Shown(object sender, EventArgs e)
        {
            this.textBox_ReceiveFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.RecieveFee);
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.OrderFee);
            this.textBox_ChangeFee.Text = CommUiltl.CoverMoneyFenToString(CurrentMsg.Order.ChangeFee);

            //如果已经收钱完毕，那么会隐藏这个页面，就弹窗告诉收款成功。
            //this.textBox_ReceiveFee.SelectionStart = 0;
            //this.textBox_ReceiveFee.SelectionLength = this.textBox_ReceiveFee.Text.Length;
        }

        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
         
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
            
            //如果
           
         
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
                        _CheckFee();
                        CurrentMsg.ReceiveMoneyByCash.Show();
                        this.Hide();
                        break;
                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        _CheckFee();
                        CurrentMsg.RecieveMoneyByWeixin.Show();
                        this.Hide();
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                case System.Windows.Forms.Keys.Delete:
                    {
                        this.Hide();
                        CurrentMsg.ProductListWindows.Show();
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
