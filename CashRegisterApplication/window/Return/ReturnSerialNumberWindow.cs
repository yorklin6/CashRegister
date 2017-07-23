using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.Return
{
    public partial class ReturnSerialNumberWindow : Form
    {
        public ReturnSerialNumberWindow()
        {
            InitializeComponent();
        }
       
        public void ShowByCenterContral()
        {
            this.Show();
            StockOutDTO oLastStockmsg = new StockOutDTO();
            CenterContral.GetLastSotckOutOrder(ref oLastStockmsg);

            this.textBox_type.Text = oLastStockmsg.Base.serialNumber.Substring(0,2); ;
            this.textBox_store_id.Text = oLastStockmsg.Base.serialNumber.Substring(3, 1);
            this.textBox_time.Text = oLastStockmsg.Base.serialNumber.Substring(5, 17);
            this.textBox_random.Text = oLastStockmsg.Base.serialNumber.Substring(23, 3) ;
            _BeginShow();
        }
        private void ReturnSerialNumber_Load(object sender, EventArgs e)
        {
            _BeginShow();
            return;
        }

        private void _BeginShow()
        {
            this.ActiveControl = textBox_store_id;
            this.textBox_store_id.SelectionStart = 0;
            textBox_store_id.SelectionLength = this.textBox_store_id.Text.Length;
        }

        //1
        private void textBox_store_id_TextChanged(object sender, EventArgs e)
        {

            this.ActiveControl = textBox_time;
            return;
        }

        private void textBox_time_TextChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("textBox_time.Text.Length:" + textBox_time.Text.Length);
            if (textBox_time.Text.Length == 17 )
            {
                this.ActiveControl = textBox_random;
                return;
            }
            if (textBox_time.Text.Length > 17)
            {
                this.textBox_time.Text = textBox_time.Text.Substring(0,17);
                return;
            }
        }

        private void textBox_random_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox_random.Text.Length > 3)
            {
                textBox_random.Text = textBox_random.Text.Substring(0, 3);
                this.ActiveControl = button_enter;
                return;
            }
        }
        //2

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("keyData:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        //MessageBox.Show("Keys.Enter: CurrentCell.RowIndex:" + this.productListDataGridView.CurrentCell.RowIndex);
                        EnterEvent();
                    }
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EnterEvent()
        {
            if (this.ActiveControl == textBox_type)
            {
                this.ActiveControl = textBox_store_id;
                return;
            }
            if (this.ActiveControl == textBox_store_id)
            {
                this.ActiveControl = textBox_time;
                return;
            }
            if (this.ActiveControl == textBox_time)
            {
                this.ActiveControl = textBox_random;
                return;
            }
            if (this.ActiveControl == textBox_random)
            {
                this.ActiveControl = button_enter;
               button1_Click(null, null);
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommUiltl.Log("button1_Click:" );
            string strSerialNumber = "";
            strSerialNumber += this.textBox_type.Text + "-";
            strSerialNumber += this.textBox_store_id.Text + "-";
            strSerialNumber += this.textBox_time.Text + "-";
            strSerialNumber += this.textBox_random.Text + "";
            CommUiltl.Log("strSerialNumber:"+ strSerialNumber);
            StockOutDTO oStock = new StockOutDTO();
            if ( !CenterContral.GetStockBySerialNumber(strSerialNumber, ref oStock) )
            {
                return;
            }

            CenterContral.ShowReturanWindowByContral(oStock);
            this.Hide();
            //oLastStockmsg = new StockOutDTO();
            //CenterContral.GetLastSotckOutOrder(ref oLastStockmsg);
            //StockOutDTO oStock = new StockOutDTO();
            //CenterContral.GetStockBySerialNumber(oLastStockmsg.Base.serialNumber, ref oStock);

            return;

        }
    }
}
