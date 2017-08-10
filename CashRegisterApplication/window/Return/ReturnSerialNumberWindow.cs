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
            DbStockOutDTO oLastStockmsg = new DbStockOutDTO();
            CenterContral.GetLastSotckOutOrder(ref oLastStockmsg);

            // this.textBox_type.Text = oLastStockmsg.Base.serialNumber.Substring(0,2); ;
            //this.textBox_store_id.Text = oLastStockmsg.Base.serialNumber.Substring(3, 1);
            //this.textBox_time.Text = oLastStockmsg.Base.serialNumber.Substring(5, 17);
            this.textBox_time.Text = oLastStockmsg.Base.serialNumber;
            this.textBox_time.SelectionStart = 0;
            textBox_time.SelectionLength = this.textBox_time.Text.Length;
            _BeginShow();
        }
        private void ReturnSerialNumber_Load(object sender, EventArgs e)
        {
            _BeginShow();
            return;
        }

        private void _BeginShow()
        {
            this.ActiveControl = textBox_time;
            this.textBox_time.SelectionStart = 0;
            textBox_time.SelectionLength = this.textBox_time.Text.Length;
        }



        private void textBox_time_TextChanged(object sender, EventArgs e)
        {
            CommUiltl.Log("textBox_time.Text.Length:" + textBox_time.Text.Length);
            
        }
 

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
            if (this.ActiveControl == textBox_time)
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
            strSerialNumber += this.textBox_time.Text + "";
            CommUiltl.Log("strSerialNumber:"+ strSerialNumber);
            DbStockOutDTO oStock = new DbStockOutDTO();
            if ( !CenterContral.GetStockBySerialNumber(strSerialNumber, ref oStock) )
            {
                return;
            }

            CenterContral.ShowReturanWindowByContral(oStock);
            this.Hide();
          
            return;

        }

        private void ReturnSerialNumberWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CenterContral.Window_ProductList.CallShow();
            this.Hide();
        }
    }
}
