using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CashRegisterApplication.comm;
using CashRegiterApplication;
using CashRegisterApplication.model;

namespace CashRegisterApplication.window
{
    public partial class RecieveMoneyWindow : Form
    {
        public RecieveMoneyWindow()
        {
            InitializeComponent();
       
        }
      
        private void RecieveMoneyWindows_Shown(object sender, EventArgs e)
        {
            //注意，正常流程下面，这个窗体只有未收款的时候显示。
            CommUiltl.Log("RecieveMoneyWindows_Shown");
            //this.ActiveControl = this.buttonCash;
            ShowByProductListWindow();

        }

        public void ShowByProductListWindow()
        {
            this.Show();
            //显示未收款
            long leftMoney = CenterContral.oStockOutDTO.Base.orderAmount - CenterContral.oStockOutDTO.Base.RecieveFee;
            if (leftMoney < 0)
            {
                leftMoney = 0;
            }
            CommUiltl.Log("leftMoney:"+ leftMoney);
            this.textBox_LeftFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(leftMoney);
            //其他订单信息
            this.textBox_OrderFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.orderAmount);
            this.textBox_RecieveFee.Text = CommUiltl.CoverMoneyUnionToStrYuan(CenterContral.oStockOutDTO.Base.RecieveFee);
            //默认不选中
            this.dataGridView_payTypeList.ClearSelection();
            this.dataGridView_payTypeList.CurrentCell = null;
        }

        public void ShowPaidMsg()
        {
            CommUiltl.Log("已支付列表");
            this.Show();
            string strPaidInfo="已支付列表：\n";
            foreach (var item in CenterContral.oStockOutDTO.checkouts)
            {
                if (item.payType== PayWay.PAY_TYPE_CASH)
                {
                    strPaidInfo += PayWay.PAY_TYPE_CASH_DESC+":" + CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount)+"元\n";
                }
                else if (item.payType == PayWay.PAY_TYPE_WEIXIN)
                {
                    strPaidInfo += PayWay.PAY_TYPE_WEIXIN_DESC + ":" + CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount) + "元\n";
                }
                else if (item.payType == PayWay.PAY_TYPE_ZHIFUBAO)
                {
                    strPaidInfo += PayWay.PAY_TYPE_ZHIFUBAO_DESC + ":" + CommUiltl.CoverMoneyUnionToStrYuan(item.payAmount) + "元\n";
                }
            }
            this.labelPaidMsg.Text = strPaidInfo;
            ShowByProductListWindow();
        }

        int DESCRIPTION_COLUMN = 0;
        int QUCK_KEY_COLUMN = 1;
        int PAY_TYPE_COLUMN = 2;
        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
            CommUiltl.Log("RecieveMoneyWindows_Load");
            int iRowIndex=0;
            //不支持大于10的快捷键
            int i = 0;
            for (;i < CenterContral.oPayTypeList.list.Count ; ++i)
            {
                iRowIndex=this.dataGridView_payTypeList.Rows.Add();
                this.dataGridView_payTypeList.Rows[iRowIndex].Cells[DESCRIPTION_COLUMN].Value= CenterContral.oPayTypeList.list[i].description;
                this.dataGridView_payTypeList.Rows[iRowIndex].Cells[QUCK_KEY_COLUMN].Value = i;
                this.dataGridView_payTypeList.Rows[iRowIndex].Cells[PAY_TYPE_COLUMN].Value = CenterContral.oPayTypeList.list[i].payTypeId;
                if (i > 9)
                {
                    this.dataGridView_payTypeList.Rows[iRowIndex].Cells[QUCK_KEY_COLUMN].Value = "双击下单";
                }
            }
            this.dataGridView_payTypeList.Rows[iRowIndex].Cells[DESCRIPTION_COLUMN].Value ="返回上一层";
            this.dataGridView_payTypeList.Rows[iRowIndex].Cells[QUCK_KEY_COLUMN].Value = "Esc";
            this.dataGridView_payTypeList.Rows[iRowIndex].Cells[PAY_TYPE_COLUMN].Value = "escKey";
           
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
            return;
        }


        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:"+ keyData);
            switch (keyData)
            {

                case System.Windows.Forms.Keys.Enter:
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                case System.Windows.Forms.Keys.D0:
                case System.Windows.Forms.Keys.NumPad0:
                    {
                        callPayWindowsBayQuickKey(0);
                        break;
                    }
                case System.Windows.Forms.Keys.D1:
                case System.Windows.Forms.Keys.NumPad1:
                case System.Windows.Forms.Keys.Oem1:
                    {
                        callPayWindowsBayQuickKey(1);
                        break;
                    }
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.Oem2:
                    {
                        callPayWindowsBayQuickKey(2);
                        break;
                    }
                case System.Windows.Forms.Keys.D3:
                case System.Windows.Forms.Keys.NumPad3:
                case System.Windows.Forms.Keys.Oem3:
                    {
                        callPayWindowsBayQuickKey(3);
                        break;
                    }
                case System.Windows.Forms.Keys.D4:
                case System.Windows.Forms.Keys.NumPad4:
                case System.Windows.Forms.Keys.Oem4:
                    {
                        callPayWindowsBayQuickKey(4);
                        break;
                    }
                case System.Windows.Forms.Keys.D5:
                case System.Windows.Forms.Keys.NumPad5:
                case System.Windows.Forms.Keys.Oem5:
                    {
                        callPayWindowsBayQuickKey(5);
                        break;
                    }
                case System.Windows.Forms.Keys.D6:
                case System.Windows.Forms.Keys.NumPad6:
                case System.Windows.Forms.Keys.Oem6:
                    {
                        callPayWindowsBayQuickKey(6);
                        break;
                    }
                case System.Windows.Forms.Keys.D7:
                case System.Windows.Forms.Keys.NumPad7:
                case System.Windows.Forms.Keys.Oem7:
                    {
                        callPayWindowsBayQuickKey(7);
                        break;
                    }
                case System.Windows.Forms.Keys.D8:
                case System.Windows.Forms.Keys.NumPad8:
                case System.Windows.Forms.Keys.Oem8:
                    {
                        callPayWindowsBayQuickKey(8);
                        break;
                    }
                case System.Windows.Forms.Keys.D9:
                case System.Windows.Forms.Keys.NumPad9:
                    {
                        callPayWindowsBayQuickKey(9);
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
        private void escapeToPreWindows()
        {
            CenterContral.Window_ProductList.EscapeShowByRecieveWindows();
            this.Hide();
        }
        private void callPayWindowsBayQuickKey(int indexPay)
        {
            CommUiltl.Log("indexPay:" + indexPay);
            callPayWindowsBayPayTypeId(CenterContral.oPayTypeList.list[indexPay].payTypeId);
            return;
        }
        private void callPayWindowsBayPayTypeId(int payTypeId)
        {
            CommUiltl.Log("payTypeId:" + payTypeId);
            _CheckFee();
            if (!CenterContral.SetCurrentPayTypeById(payTypeId))
            {
                MessageBox.Show("系统错误，未知支付类型:payTypeId-" + payTypeId);
                return;
            }
            if (payTypeId == CenterContral.MEMBER_PAY_TYPE)
            {
                CenterContral.Window_ReceiveMoneyByMember.ShowByReceiveMoneyWindows();
                this.Hide();
                return;
            }
            CenterContral.Window_ReceiveMoneyByCash.ShowByReceiveMoneyWindow();
            this.Hide();
            return;
        }
        private void buttonCash_Click(object sender, EventArgs e)
        {
            _CheckFee();
            CenterContral.Window_ReceiveMoneyByCash.ShowByReceiveMoneyWindow();
            this.Hide();
        }



        private void buttonMember_Click(object sender, EventArgs e)
        {
            _CheckFee();
            CenterContral.Window_ReceiveMoneyByMember.ShowByReceiveMoneyWindows();
            this.Hide();
        }

        private void dataGridView_payTypeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView_payTypeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strPayType=this.dataGridView_payTypeList.Rows[e.RowIndex].Cells[PAY_TYPE_COLUMN].Value.ToString();
            if(strPayType== "" || strPayType == null)
            {
                return;
            }
            if ( strPayType== "escKey")
            {
                escapeToPreWindows();
                return;
            }
            int payType = 0;
            if (!CommUiltl.CoverStrToInt(strPayType, out payType))
            {
                MessageBox.Show("错误支付类型:" + strPayType);
                return;
            }
            callPayWindowsBayPayTypeId(payType);
            return;
        }
        private void returnPreventWindows()
        {
            CenterContral.Window_RecieveMoney.Show();
            this.Hide();
        }

        private void RecieveMoneyWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            returnPreventWindows();
            CenterContral.Window_RecieveMoney = new RecieveMoneyWindow();
        }
       
    }
}
