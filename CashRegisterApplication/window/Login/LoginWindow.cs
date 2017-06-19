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
           // HttpUtility.TestTimeOut();
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label_tips.Text = "正在登录....";
            //登陆
            if (CenterContral.Login(this.textBox_userName.Text, this.textBox_password.Text,CenterContral.oStoreWhouse.storeWhouseId))
            {
                this.label_tips.Text = "初始化中...";
                CenterContral.LoginSuccess();
                this.Hide();
            }
            this.label_tips.Text = "登陆失败";
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginWindows_Shown(object sender, EventArgs e)
        {
            CommUiltl.Log("LoginWindows_Shown ");
            CenterContral.Init();
  
            if (0 != CenterContral.oStoreWhouse.storeWhouseId)
            {
                textBox_Shop.Text = CenterContral.oStoreWhouse.name;
            }
        }
        public void UpdateSetttingDefaultMsg()
        {
            this.Show();
            textBox_Shop.Text = CenterContral.oStoreWhouse.name;
            CenterContral.Init();
          
        }
    }
}
