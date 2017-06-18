using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.ProductList
{
    public partial class Printer_Hostory_Select_Windows : Form
    {
        public Printer_Hostory_Select_Windows()
        {
            InitializeComponent();
            
        }

        private void Printer_Hostory_Select_Windows_Load(object sender, EventArgs e)
        {
            CenterContral.Init();
        }

        private void Printer_Hostory_Select_Windows_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            escapeToPreWindows();
        }

        private void  escapeToPreWindows()
        {
            CenterContral.Window_ProductList.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            escapeToPreWindows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrinterLastButton();
        }

        private void PrinterLastButton()
        {
            string showTips = "确认打印";
            var confirmPayApartResult = MessageBox.Show("是否要打印前一笔小票",
                                 showTips,
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return;
            }
            CenterContral.PrintLastSotckOutOrder();
            CenterContral.CallProductListWindow();
            this.Hide();
        }

        internal void ShowByCenterContral()
        {
            this.Show();
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                case System.Windows.Forms.Keys.D1:
                case System.Windows.Forms.Keys.NumPad1:
                case System.Windows.Forms.Keys.Oem1:
                    {
                        PrinterLastButton();
                        break;
                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        CenterContral.ShowMoreStockMsg();
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                case System.Windows.Forms.Keys.D3:
                case System.Windows.Forms.Keys.NumPad3:
                case System.Windows.Forms.Keys.Oem3:
                    {
                        escapeToPreWindows();
                        break;
                    }
             
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CenterContral.ShowMoreStockMsg();
            this.Hide();
        }
    }
}
