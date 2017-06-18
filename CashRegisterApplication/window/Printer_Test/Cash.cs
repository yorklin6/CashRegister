using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Collections;
using System.Data.SqlClient;
using CashRegisterApplication.comm;
using CashRegisterApplication.window.Printer;
using System.Drawing.Printing;

namespace SuperMarket
{
    public partial class Cash : Form
    {
        public Cash()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void Cash_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("0001", "C#数据结构", "222", "55.26", "55.26", "露天其");
            //dataGridView1.Rows.Add("0002", "联想笔记本电脑送鼠标", "3333", "1111.23", "1111.23", "露天其");
            // dataGridView1.Rows.Add("0003", "联想台式电脑玩家", "111", "333.23", "333.23", "露天其");
            // dataGridView1.Rows.Add("0004", "我的读书郎", "1", "555.33", "55555.33", "露天其");
            // dataGridView1.Rows.Add("0005", "新一佳超市购物小票", "222222", "1.33", "1.33", "露天其");
            CenterContral.Init();
        }
       
        bool isEnter = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                isEnter = true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Cash_Activated(object sender, EventArgs e)
        {
            txtNum.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txbm=this.txtNum.Text.Trim();//查询出库存表中对应的数据
            if (txbm == "")
            {
                MessageBox.Show("文本框中请输入产品编码！");
                txtNum.Focus();
                return;
            }
            else
            {
                AddGridView(txbm);
                CompPro();

            }
        }
      
        #region 封装 填写DataGridView的数据操作
        private void AddGridView(string probianma)
        {
            //第一步 查询该编码的商品信息
            SqlParameter parm = new SqlParameter("@ProBianma", probianma);
            //SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, SQL, parm);
            string proname = "", realbm = "";
            int num = 0;//数量 每次都是1，如果在文本框多次输入统一编码的商品，则DataGridView中，统一编码的数量改变，其余不必
            string price = "0";//单价是多少
            string shouyinyuan = "露天其";//收银员的名字，这个可以改写登录后 获取登录者的名称即可
            bool input = false;//输入的产品编码是否有误，如果有误，则查询不出信息，则不会执行下面的填写数据到DataGridView
//             if (dr.Read())
//             {
//                 input = true;
//                 proname = dr["ProName"].ToString();
//                 realbm = probianma;//如果从数据库中查询出该信息，则证明这个编码的商品信息存在
//                 num = 1;
//                 price = dr["ProPrice"].ToString();
//             }
            //第二部 判断该编码的商品是否已经存在下面的DataGridView中
            if (input)
            {
                bool ext = false;//不存在
                foreach (DataGridViewRow dv in dataGridView1.Rows)
                {
                    if (dv.Cells["bianma"].FormattedValue.ToString() == realbm)//说明已经存在该编码的信息 则更新即可，不必再写入一条信息
                    {
                        ext = true;
                        dv.Cells["ProNum"].Value = Convert.ToInt32(dv.Cells["ProNum"].FormattedValue.ToString()) + 1;
                        dv.Cells["ProMoney"].Value =Convert.ToString(Convert.ToInt32(dv.Cells["ProNum"].FormattedValue.ToString()) * decimal.Parse(price));
                        break;
                    }
                }
                if (ext == false)//不存在则添加一条信息信息
                {
                    
                    this.dataGridView1.Rows.Add(probianma, proname, num, price, price, shouyinyuan);
                }
            }
            else
            {
                MessageBox.Show("输入的产品编码有误，请重新输入！");
                return;
            }
        }
        #endregion
       
        #region 计算下面DataGridView里面总的金额是多少，以及商品件数
        private void CompPro()
        {
            decimal je = 0;
            int num = 0;
            lbje.Text = "";
            lbnum.Text = "";
          
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                {
                    je += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    num += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());
                }
            }
            lbje.Text = je.ToString() + "￥";
            lbnum.Text = num.ToString();
            textBox1.Text = je.ToString();
            decimal oldmoney = Convert.ToDecimal(textBox1.Text);
            decimal newmoney = 0;
            
                newmoney = oldmoney;
           
            textBox2.Text = newmoney.ToString();

        }
        #endregion
        #region dataGridView1中修改商品数量 回车 
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (isEnter)
            {
                string bm = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
                if (bm != "")
                {
                    int v = 0;
                    try { v = Convert.ToInt32(bm); }
                    catch { MessageBox.Show("请输入数字！"); return; }
                    string pronum = dataGridView1.CurrentRow.Cells[2].EditedFormattedValue.ToString();//获取数量
                    string price = dataGridView1.CurrentRow.Cells[3].EditedFormattedValue.ToString();//获取单价
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = Convert.ToString(Convert.ToInt32(pronum) * decimal.Parse(price));//更新该编码的商品金额
                  
                    CompPro();//统计下面的数据
                }
                else
                {                   
                    dataGridView1.CancelEdit();
                    MessageBox.Show("输入无效！");                
                  
                }
            }
        }
        #endregion
        #region 输入商品编码 回车事件
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                button1_Click(null, null);
            }
        }
        #endregion

        #region 该函数动态添加空格，对齐小票
        public string AddSpace(string text, int length)
        {
           
              text=text.PadRight(length, ' ');
            
                return text;
        }
        #endregion

        #region 结帐以及打印函数
        private void jzPrint()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有购物数据，无法收银和打印！");
                return;
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("没有输入付款金额，无法收银打印！");
                return;
            }
            //收银打印


            #region 第一步，首先把这项订单写入数据库的表中
             //写入数据库比较简单，
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string name = dataGridView1.Rows[i].Cells["ProName"].Value.ToString().Trim();//获取该行的物品名称
                string num = dataGridView1.Rows[i].Cells["ProNum"].Value.ToString().Trim();//数量
                string price = dataGridView1.Rows[i].Cells["ProPrice"].Value.ToString().Trim();//单价
                string bm = dataGridView1.Rows[i].Cells["bianma"].Value.ToString();
                //string SQL = "insert into T_Order()";
                //SqlHelper.ExecuteNonQuery(

            }
            #endregion
            string path = Application.StartupPath.ToString() + "\\ticket.txt";//exe程序所在的路径

            #region 第二步，把这位顾客的购物单，按格式生成一个txt文件，方便第三步打印
            StreamWriter sw = new StreamWriter(path, true);
    
            #region 拼出小票格式
            sw.WriteLine("欢迎光临速顾优先选鲜食材馆！");
            sw.WriteLine(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"));
            sw.WriteLine("POST机号:"+CenterContral.iPostId);
            sw.WriteLine("单号:"+ CenterContral.oStockOutDTO.Base.serialNumber);
            sw.WriteLine("收银员:"+ CenterContral.DefaultUserId);
 
            sw.WriteLine("==============销售==============");
            sw.WriteLine("名称/条码    单价   数量   金额");
            int nums = 20;
            int prices = 12;

            #region 获取DataGridView中的数据
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string name = dataGridView1.Rows[i].Cells["ProName"].Value.ToString().Trim();//获取该行的物品名称
                string num = dataGridView1.Rows[i].Cells["ProNum"].Value.ToString().Trim();//数量
                string price = dataGridView1.Rows[i].Cells["ProPrice"].Value.ToString().Trim();//单价

                int numlength = System.Text.Encoding.Default.GetBytes(num).Length;
                if (numlength < nums)
                {
                    num = AddSpace(num, nums - numlength);
                }

                int pricelength = System.Text.Encoding.Default.GetBytes(price).Length;
                if (pricelength < prices)
                {
                    price = AddSpace(price, prices - pricelength);
                }
                sw.WriteLine(name);
                sw.WriteLine("12134                    " + num + "        " + price);

            }
            #endregion
            sw.WriteLine("-----------------------------------------------------");
            sw.WriteLine("总数：                  " + lbnum.Text.ToString());
            //计算合计金额：
            decimal oldmoney = Convert.ToDecimal(textBox1.Text);
            decimal newmoney = 0;

            newmoney = oldmoney;


            sw.WriteLine("总件数" + "");//合计金额
            sw.WriteLine("应收:" + textBox3.Text.Trim());//实收现金
            sw.WriteLine("已优惠:" + textBox4.Text.Trim());//实收现金
            sw.WriteLine("找零:");
            if (CenterContral.oStockOutDTO.oMember.memberId > 0)
            {
                sw.WriteLine("会员卡号:");
                sw.WriteLine("本单交易积分:");
                sw.WriteLine("会员卡余额:");
            }
            sw.WriteLine("会员卡号:");
            sw.WriteLine("本单 " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            sw.Close();
            #endregion
            #endregion
            #region 第三部，进行打印
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            PrintDialog1.ShowHelp = true;
            CommUiltl.Log("PrintDialog1");
            // 把PrintDialog的Document属性设为上面配置好的PrintDocument的实例 
            PrintDialog1.Document = docToPrint;//这是工具箱中打印的一个 组件名称
            this.docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(docToPrint_PrintPage);
            this.docToPrint.EndPrint += new System.Drawing.Printing.PrintEventHandler(afterPrint);
            CommUiltl.Log(" this.docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(docToPrint_PrintPage)");
            // 调用PrintDialog的ShowDialog函数显示打印对话框 
            DialogResult result = PrintDialog1.ShowDialog();

            //if (result == DialogResult.OK)// 弹出设置打印机，如果不需要设置，第三部可简写为   docToPrint.Print(); 则开始进行打印了
            {
                // 开始打印 
                docToPrint.Print();

            }
            #endregion
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

      
        #endregion
        #region 读取文本文件 打印完成后 重新删除该文件
        private string GetTicketInfo()
        {
            string val = "";
            string path = Application.StartupPath.ToString() + "\\ticket.txt";//exe程序所在的路径
            try
            {
                FileStream fsFile = new FileStream(path, FileMode.Open);

                /* 
                 * 讀取數據最簡單的方法是Read()。此方法將流的下一個字符作為正整數值返回， 
                 * 如果達到了流的結尾處，則返回-1。 
                 */
                StreamReader srReader = new StreamReader(fsFile);
                int iChar;
                iChar = srReader.Read();
                while (iChar != -1)
                {
                    val += (Convert.ToChar(iChar));
                    iChar = srReader.Read();
                }
                srReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return val;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            jzPrint();
        }


        #region 该函数是真实调用打印机开始打印工作
        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            string text = null;
            // 信息头 
            System.Drawing.Font printFont = new System.Drawing.Font
            ("Arial", 8, System.Drawing.FontStyle.Regular);            
           
            text = GetTicketInfo();//获取本次购物清单数据
            // 设置信息打印格式 
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 0, 5);
        }
        #endregion
        #region 打印结束后
        private void afterPrint(object sender, PrintEventArgs e)
        {
            //关闭钱箱
            CenterContral.CloseMoneyBox(CenterContral.CloseMoneyBoxComm);
        }
        #endregion
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                button3_Click(null, null);
            }           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            decimal ygje = Convert.ToDecimal(textBox2.Text);//实际该收的金额 也算是折后的
            decimal zfje = Convert.ToDecimal(textBox3.Text);//支付的金额
            textBox4.Text = Convert.ToString(zfje-ygje);
        }   

       
        private void button4_Click(object sender, EventArgs e)
        {
            string val = "";
           string path = Application.StartupPath.ToString() + "\\ticket.txt";//exe程序所在的路径
           try
           {
               FileStream fsFile = new FileStream(path, FileMode.Open);

               /* 
                * 讀取數據最簡單的方法是Read()。此方法將流的下一個字符作為正整數值返回， 
                * 如果達到了流的結尾處，則返回-1。 
                */
               StreamReader srReader = new StreamReader(fsFile);
               int iChar;
               iChar = srReader.Read();
               while (iChar != -1)
               {
                   val += (Convert.ToChar(iChar));
                   iChar = srReader.Read();
               }
               srReader.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }
           MessageBox.Show(val);
            //streamToPrint.Dispose();
            //streamToPrint.Close();
           if (File.Exists(path))
           {
               File.Delete(path);
           }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            decimal ygje = Convert.ToDecimal(textBox2.Text);//实际该收的金额 也算是折后的
            decimal zfje = Convert.ToDecimal(textBox3.Text);//支付的金额
            textBox4.Text = Convert.ToString(zfje - ygje);
        }
        /// <summary>
        /// 按回车也响应结帐 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            jzPrint();
        }
        

       



        

       

       

       

       

       
    }
}
