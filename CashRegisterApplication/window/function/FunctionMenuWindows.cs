using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.function
{
    public partial class FunctionMenuWindow : Form
    {
        public FunctionMenuWindow()
        {
            InitializeComponent();
           
        }

        private void FuncitonMenu_Load(object sender, EventArgs e)
        {
            CenterContral.Init();
            this.ActiveControl = this.buttonRecharge;
        }
        public void CallShowByCenter()
        {
            this.Show();
            this.ActiveControl = this.buttonRecharge;
        }
        private void buttonBasePay_Enter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            setButtonLignt(button);
            CommUiltl.Log("buttonBasePay_Enter button.Tag:" + button.Tag + " buttonName:" + button.Name + " buttonName:" + button.Text);
        }

        private void buttonBasePay_Leave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            setButtonShadow(button);
            CommUiltl.Log("buttonBasePay_Leave button.Tag:" + button.Tag);
        }
        private void setButtonLignt(Button button)
        {
            button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        }
        private void setButtonShadow(Button button)
        {
            button.BackColor = System.Drawing.SystemColors.ButtonShadow;
        }

        private void buttonRecharge_Click(object sender, EventArgs e)
        {
            //唤起会员充值页面
            CenterContral.ShowWindows_RechargeMoneyForMember();
            this.Hide();
        }

        private void buttonCloudSystem_Click(object sender, EventArgs e)
        {
            CommUiltl.Log("CenterContral.oSystem.ClouWebAddress):"+ CenterContral.oSystem.ClouWebAddress);
            Process.Start(CenterContral.oSystem.ClouWebAddress);
            this.Hide();
        }

        private void buttonSettingSystem_Click(object sender, EventArgs e)
        {
            CenterContral.CallSettingDefaultMsgWindow(CenterContral.FLAG_FUNCTION_MENU_WINDOW);
            this.Hide();
        }

        internal void HideByCenter()
        {
            this.Hide();
        }

        private void FunctionMenuWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            escapeToPreWindows();
        }

        private void escapeToPreWindows()
        {
            CenterContral.Window_ProductList.CallShow();
            this.Hide();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.D0:
                case System.Windows.Forms.Keys.NumPad0:
                    {
                        buttonRecharge_Click(null,null);
                        break;
                    }
                case System.Windows.Forms.Keys.D1:
                case System.Windows.Forms.Keys.NumPad1:
                case System.Windows.Forms.Keys.Oem1:
                    {
                        buttonCloudSystem_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        buttonSettingSystem_Click(null, null);
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                    {
                        escapeToPreWindows();

                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
