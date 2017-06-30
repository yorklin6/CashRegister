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
         

           
        }

        public void CallHide()
        {
            this.Hide();
        }
        public void ShowPaidMsg()
        {
            CommUiltl.Log("已支付列表");
            this.Show();
           
            ShowByProductListWindow();
        }

        List<Button> listButton = new List<Button>();

        private void RecieveMoneyWindows_Load(object sender, EventArgs e)
        {
    
            this.tableLayoutPanel_Show.Controls.Remove(this.buttonBasePay); 

            if (CenterContral.oPayTypeList.list.Count ==0)
            {
                return;
            }
            int iRowCount = CenterContral.oPayTypeList.list.Count / 3;
            CommUiltl.Log("iRowCount:" + iRowCount);
            if (CenterContral.oPayTypeList.list.Count % 3 != 0)
            {
                ++iRowCount;
                CommUiltl.Log(" ++iRowCount:" + iRowCount);
            }

           _GenerateTablePane(iRowCount);//重新绘制layout
         
            int i = 0;
            for (int row = 0; row < iRowCount && i < CenterContral.oPayTypeList.list.Count; ++row)
            {
                for (int colum=0; colum < 3 && i < CenterContral.oPayTypeList.list.Count; ++colum)
                {
                    Button button = new Button();
                    setButtonShadow(button);//
                    button.Tag = i;
                    button.Dock = System.Windows.Forms.DockStyle.Fill;
                    button.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
                    button.FlatAppearance.BorderSize = 10;
                    button.ForeColor = System.Drawing.SystemColors.WindowText;
                    button.Location = new System.Drawing.Point(10, 10);
                    button.Margin = new System.Windows.Forms.Padding(10);
                    button.Name = "button_"+i;
                    button.Size = new System.Drawing.Size(174, 72);
                    button.TabIndex = 5 + i;
                  
                    button.Text =  CenterContral.oPayTypeList.list[i].description;
                    if (i < 10)
                    {
                        button.Text += "(" + i + ")";
                    }
                    button.UseVisualStyleBackColor = false;
                    button.Enter += new System.EventHandler(this.buttonBasePay_Enter);
                    button.Leave += new System.EventHandler(this.buttonBasePay_Leave);
                    button.Click += new System.EventHandler(this.buttonBasePay_Click_1);
                    listButton.Add(button);
                    this.tableLayoutPanel_Show.Controls.Add(button, colum,  row);
                    ++i;
                }
              
            }

            this.ActiveControl = listButton[0];
            setButtonLignt(listButton[0]);//高亮
        }

        private void _GenerateTablePane(int iRowCount)
        {
            //模仿页面，动态生成平铺
            this.tableLayoutPanel_Show.ColumnCount = iRowCount;
           this.tableLayoutPanel_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Show.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Show.Name = "tableLayoutPanel_Show";
            this.tableLayoutPanel_Show.RowCount = 6;
            this.tableLayoutPanel_Show.RowStyles.Clear();
            for (int i = 0; i < iRowCount; ++i)
            {
                this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle());
            }
            this.tableLayoutPanel_Show.Size = new System.Drawing.Size(584, 462);
            this.tableLayoutPanel_Show.TabIndex = 1;
        }
        private void _MoveToActiveButton(Keys keyData)
        {
            //动态计算要移动到哪个按钮
            CommUiltl.Log("_MoveToActiveButton Keys:" + keyData);
           // for (int i=0;i< listButton.Count;++i)
            {
                Button button = (Button)this.ActiveControl;
               // if (button == this.ActiveControl)
                {
                    CommUiltl.Log("button is ActiveControl :" + button.Text);
                  
                    int iSource=(int)button.Tag;
                    CommUiltl.Log("button is iSource :" + iSource);
                    if (keyData ==System.Windows.Forms.Keys.Up)
                    {
                        //向上其实是退格3个
                        iSource = iSource - 3;
                        if (iSource < 0)
                        {
                            return;
                        }
                        SetActiByTag(iSource);
                        return;
                    }
                    if (keyData == System.Windows.Forms.Keys.Left)
                    {
                        //向上其实是退格1个
                        iSource = iSource - 1;
                        if (iSource < 0)
                        {
                            return;
                        }
                        SetActiByTag(iSource);
                        return;
                    }
                    if (keyData == System.Windows.Forms.Keys.Down)
                    {
                        //向上其实是进3个
                        iSource = iSource + 3;
                        if (iSource > listButton.Count -1)
                        {
                            return;
                        }
                        SetActiByTag(iSource);
                        return;
                    }
                    if (keyData == System.Windows.Forms.Keys.Right)
                    {
                        //向上其实是退格1个
                        iSource = iSource +1;
                        if (iSource > listButton.Count - 1)
                        {
                            return;
                        }
                        SetActiByTag(iSource);
                        return;
                    }
                }
            }
          
        }

        private void SetActiByTag(int iTag)
        {
            CommUiltl.Log("button is iTag :" + iTag+ "  listButton.Count:" + listButton.Count);
            if (iTag<0 || iTag > listButton.Count - 1)
            {
                CommUiltl.Log("ERR : button is iTag :" + iTag);
                return;
            }
            this.ActiveControl = listButton[iTag];
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
                case System.Windows.Forms.Keys.Up:
                case System.Windows.Forms.Keys.Down:
                case System.Windows.Forms.Keys.Left:
                case System.Windows.Forms.Keys.Right:
                    {
                        _MoveToActiveButton(keyData);
                        return true;
                    }

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
            CenterContral.Window_ReceiveMoneyByPayType.ShowByReceiveMoneyWindow();
            this.Hide();
            return;
        }
     
        
        private void dataGridView_payTypeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView_payTypeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string strPayType=this.dataGridView_payTypeList.Rows[e.RowIndex].Cells[PAY_TYPE_COLUMN].Value.ToString();
            //if(strPayType== "" || strPayType == null)
            //{
            //    return;
            //}
            //if ( strPayType== "escKey")
            //{
            //    escapeToPreWindows();
            //    return;
            //}
            //int payType = 0;
            //if (!CommUiltl.CoverStrToInt(strPayType, out payType))
            //{
            //    MessageBox.Show("错误支付类型:" + strPayType);
            //    return;
            //}
            //callPayWindowsBayPayTypeId(payType);
            return;
        }


        private void RecieveMoneyWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CenterContral.Window_RecieveMoney = new RecieveMoneyWindow();
            e.Cancel = false;
            escapeToPreWindows();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_LeftFee_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_payTypeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_payTypeList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lable_RecieveFee_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel_Show_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonBasePay_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            CommUiltl.Log("button.Tag:"+ button.Tag);
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

        private void buttonBasePay_Click_1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            callPayWindowsBayQuickKey((int)button.Tag);
            CommUiltl.Log("buttonBasePay_Click_1 button.Tag:" + button.Tag + " buttonName:" + button.Name + " buttonName:" + button.Text);
        }

        private void setButtonLignt(Button button)
        {
            button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        }
        private void setButtonShadow(Button button)
        {
            button.BackColor = System.Drawing.SystemColors.ButtonShadow;
        }
    }
}
