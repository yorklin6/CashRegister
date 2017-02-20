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

namespace CashRegisterApplicationNameSapce
{


    public partial class loginForm : Form
    {
        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDay { get; set; }
        }

        public CashRegisterWindow cashRegisterWindow;
        public loginForm()
        {
            InitializeComponent();
            cashRegisterWindow = new CashRegisterWindow();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ProductPricingInfoResp oJson = new ProductPricingInfoResp();
            //oJson.errorCode=0;
            //oJson.info = new ProductPricing();
            //oJson.info.NormalPrice = 11;
            ////将对象转化成Json字符串
            //string output = JsonConvert.SerializeObject(oJson);

            ////将Json字符串转化成对象
            //ProductPricingInfoResp outPerson = JsonConvert.DeserializeObject<ProductPricingInfoResp>(output);

            //MessageBox.Show("NormalPrice:" + outPerson.info.NormalPrice);

            string tagUrl = "http://aladdin.chalubo.com/cashRegister/getPricingByProductCode.json?productCode=4891913690152";
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, cookies);
            this.Hide();
            cashRegisterWindow.Show();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
