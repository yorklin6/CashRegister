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
using System.Threading;

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


        Thread newThread = null;

        // Programs the button to throw an exception when clicked.
        private void button2_Click(object sender, System.EventArgs e)
        {
            throw new ArgumentException("The parameter was invalid");
        }

        // Start a new thread, separate from Windows Forms, that will throw an exception.
        private void button3_Click(object sender, System.EventArgs e)
        {
            ThreadStart newThreadStart = new ThreadStart(newThread_Execute);
            newThread = new Thread(newThreadStart);
            newThread.Start();
        }

        // The thread we start up to demonstrate non-UI exception handling. 
        void newThread_Execute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        public static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
    }
}
