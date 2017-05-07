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

            //生成下拉框
            List<ComboxItem> oListItem = new List<ComboxItem>();

            if (CenterContral.oListStoreWhouse.Count != 0)
            {
                int selectIndex = 0;
                for (int i=0;i< CenterContral.oListStoreWhouse.Count;++i)
                {
                    StoreWhouse item = CenterContral.oListStoreWhouse[i];
                    ComboxItem oTmp = new ComboxItem(item.name, item.storeWhouseId.ToString());
                    if (item.storeWhouseId == CenterContral.oStoreWhouse.storeWhouseId )
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
                if (CenterContral.oStoreWhouse.storeWhouseId != 0)
                {
                   
                    ComboxItem oTmp = new ComboxItem(CenterContral.oStoreWhouse.name, CenterContral.oStoreWhouse.storeWhouseId.ToString());
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
            for (int i = 0; i < CenterContral.oListStoreWhouse.Count; ++i)
            {
                if (storeWhouseId == CenterContral.oListStoreWhouse[i].storeWhouseId)
                {
                    CenterContral.oStoreWhouse = CenterContral.oListStoreWhouse[i];
                }
            }
            //登陆
            if (CenterContral.Login(this.textBox_userName.Text, this.textBox_password.Text))
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
