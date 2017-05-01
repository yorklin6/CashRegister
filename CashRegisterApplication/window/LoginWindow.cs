using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CashRegiterApplication;
using Newtonsoft.Json;
using System.Net;
using CashRegisterApplication.comm;
using CashRegisterApplication.model;

namespace CashRegiterApplication
{


    public partial class LoginWindows : Form
    {

        public ProductListWindow gProductListWindow;
        public LoginWindows()
        {
            InitializeComponent();
            gProductListWindow = new ProductListWindow();
            this.textBox_userName.Text = "york";
            this.textBox_password.Text = "york";
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            //拉出门店信息
            MsgContral.GetStoreMsg();
            //生成下拉框
            List<ComboxItem> oListItem = new List<ComboxItem>();

            if (MsgContral.oListStoreWhouse.Count != 0)
            {
                int selectIndex = 0;
                for (int i=0;i< MsgContral.oListStoreWhouse.Count;++i)
                {
                    StoreWhouse item = MsgContral.oListStoreWhouse[i];
                    ComboxItem oTmp = new ComboxItem(item.name, item.storeWhouseId.ToString());
                    if (item.storeWhouseId == MsgContral.oStoreWhouse.storeWhouseId )
                    {
                        selectIndex = i;
                       
                    }
                    oListItem.Add(oTmp);
                }
                comboBox_StoreShop.DataSource = oListItem;
                comboBox_StoreShop.SelectedIndex = selectIndex;
            }
            else
            {
                //MsgContral.oListStoreWhouse.Count == 0
                if (MsgContral.oStoreWhouse.storeWhouseId != 0)
                {
                   
                    ComboxItem oTmp = new ComboxItem(MsgContral.oStoreWhouse.name, MsgContral.oStoreWhouse.storeWhouseId.ToString());
                    oListItem.Add(oTmp);
                    comboBox_StoreShop.DataSource = oListItem;
                    comboBox_StoreShop.SelectedIndex = 0;
                }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //取得下拉框门店id信息
            int storeWhouseId=0;
            CommUiltl.CoverStrToInt(((ComboxItem)comboBox_StoreShop.SelectedItem).Values ,out storeWhouseId);
            for (int i = 0; i < MsgContral.oListStoreWhouse.Count; ++i)
            {
                if (storeWhouseId == MsgContral.oListStoreWhouse[i].storeWhouseId)
                {
                    MsgContral.oStoreWhouse = MsgContral.oListStoreWhouse[i];
                }
            }
            //登陆
            if (MsgContral.Login(this.textBox_userName.Text, this.textBox_password.Text))
            {
                gProductListWindow.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
