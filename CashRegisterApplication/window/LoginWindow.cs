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

namespace CashRegiterApplication
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
            this.useNameTextBox.Text = "york";
            this.passwordTextBox.Text = "york";
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (HttpUtility.Login(this.useNameTextBox.Text, this.passwordTextBox.Text))
            {
                this.Hide();
                cashRegisterWindow.Show();
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
