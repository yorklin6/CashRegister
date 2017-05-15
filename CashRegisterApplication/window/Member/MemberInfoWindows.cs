using CashRegisterApplication.comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.member
{
    public partial class MemberInfoWindows : Form
    {
        public MemberInfoWindows()
        {
            InitializeComponent();
        }

        private void memberRechargeWindows_Load(object sender, EventArgs e)
        {

        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("Keys:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        enterEvent();
                        break;
                    }
                case System.Windows.Forms.Keys.Escape:
                    {
                        CenterContral.ShowWindowWhenMemberInfoCancel();
                        this.Hide();
                        break;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        internal void ShowWhithMember()
        {
            
            this.textBox_memberAccount.Text= CenterContral.oMember.memberAccount;
            this.textBox_name.Text = CenterContral.oMember.name;
            this.textBox_memberBalance.Text = CommUiltl.CoverMoneyUnionToStrYuan((CenterContral.oMember.balance ));
            this.textBox_phone.Text = CenterContral.oMember.phone;
            this.textBox_memberAccount.Focus();

            this.textBox_memberAccount.Text = "123456";
            this.textBox_memberAccount.SelectionStart = 0;
            this.textBox_memberAccount.SelectionLength = this.textBox_memberAccount.Text.Length;
            this.Show();
            return;
        }

        //回车事件
        private void enterEvent()
        {
            if (this.textBox_memberAccount.Text == "")
            {
                this.textBox_memberAccount.Focus();
                this.textBox_memberAccount.SelectionStart = 0;
                return;
            }
            if (CenterContral.oMember.memberAccount != this.textBox_memberAccount.Text)
            {
                //查会员信息
                if (!CenterContral.GetMemberByMemberAccount(this.textBox_memberAccount.Text))
                {
                    this.textBox_memberAccount.Focus();
                    this.textBox_memberAccount.SelectionStart = 0;
                    this.textBox_memberAccount.SelectionLength = this.textBox_memberAccount.Text.Length;
                    return;
                }

              
   
                //查成功
                this.textBox_name.Text = CenterContral.oMember.name;
                this.textBox_memberBalance.Text = CommUiltl.CoverMoneyUnionToStrYuan((CenterContral.oMember.balance ));
                this.textBox_phone.Text = CenterContral.oMember.phone;
            }
            //查成功或者没有修改会员账号
            CenterContral.ShowWindowWhenGetMemberSuccess();
            this.Hide();
            return;

        }
        private void memberRechargeWindows_Shown(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
