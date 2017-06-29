using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using CashRegiterApplication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.Setting
{
    public partial class SettingDefaultMsgWindow : Form
    {

        public SettingDefaultMsgWindow()
        {
            InitializeComponent();
        }

        internal void ShowByLogin()
        {
            this.Show();
            this.textBox_user.Text = CenterContral.DefaultUserName;
            this.textBox_userPassword.Text = CenterContral.DefaultPassword;
        }

        internal void ShowByCenter()
        {
            this.Show();
            this.textBox_user.Text = CenterContral.DefaultUserName;
            this.textBox_userPassword.Text = CenterContral.DefaultPassword;
        }



        private void SettingDefaultMsg_Load(object sender, EventArgs e)
        {
           
            //获取postID
            _GetPostId();

            CenterContral.GetSystemInfoFromDb();
            comm.CommUiltl.Log("CenterContral.oSystem:" + CenterContral.oSystem.IpHostAddress);
            textBox_IpHostAddress.Text = CenterContral.oSystem.IpHostAddress;
            textBox_ClouWebAddress.Text = CenterContral.oSystem.ClouWebAddress;

        }
        private void SettingDefaultMsgWindow_Shown(object sender, EventArgs e)
        {
            textBox_PostID.Focus();
        }
        private void _GetMac()
        {
           textBox_Mac.Text= CommUiltl.GetMacInfo();
        }
        private void _GetPostId()
        {
            CenterContral.GetPostIdFromDb();
            textBox_PostID.Text = CenterContral.iPostId.ToString();
        }

        private void _GetStoreList()
        {
            CenterContral.GetStoreMsg(this.textBox_user.Text);
            List<ComboxItem> oListItem = new List<ComboxItem>();
            if (CenterContral.oStoreListWithUser.data.Count == 0)
            {
                MessageBox.Show("系统异常，未能拉出门店信息:");
                return;
            }

            int selectIndex = 0;
            for (int i = 0; i < CenterContral.oStoreListWithUser.data.Count; ++i)
            {
                StoreWhouse item = CenterContral.oStoreListWithUser.data[i];
                ComboxItem oTmp = new ComboxItem(item.name, item.storeWhouseId.ToString());
                if (item.storeWhouseId == CenterContral.oStoreWhouse.storeWhouseId)
                {
                    selectIndex = i;

                }
                oListItem.Add(oTmp);
            }
            comboBox_StoreShop.DataSource = oListItem;
            comboBox_StoreShop.SelectedIndex = selectIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iPostId = 0;
            if (!CommUiltl.CoverStrToInt(textBox_PostID.Text, out iPostId))
            {
                MessageBox.Show("错误PostId");
                return;
            }
            if (-1 == iPostId)
            {
                MessageBox.Show("错误PostId,不能为-1");
                return;
            }
            //取得下拉框门店id信息
            int storeWhouseId = 0;
            CommUiltl.Log("SelectedItem:" + ((ComboxItem)comboBox_StoreShop.SelectedItem).Values);
            CommUiltl.CoverStrToInt(((ComboxItem)comboBox_StoreShop.SelectedItem).Values, out storeWhouseId);
            for (int i = 0; i < CenterContral.oStoreListWithUser.data.Count; ++i)
            {
                if (storeWhouseId == CenterContral.oStoreListWithUser.data[i].storeWhouseId)
                {
                    CenterContral.oStoreWhouse = CenterContral.oStoreListWithUser.data[i];
                    CenterContral.oStoreListWithUser.selectStockIndex = i;
                }
            }
            //更新默认门店信息
            string strStoreWhouseDefult = JsonConvert.SerializeObject(CenterContral.oStoreWhouse);
            CenterContral.UpdateStoreWhouseDefault(strStoreWhouseDefult);

           
            CenterContral.iPostId = iPostId;
            CenterContral.SetPostIdFromDb();

            CenterContral.oSystem.IpHostAddress = textBox_IpHostAddress.Text;
            CenterContral.oSystem.ClouWebAddress = textBox_ClouWebAddress.Text;
            CenterContral.SetSystemInfoToDb();

            MessageBox.Show("保存成功");
            CenterContral.CallWindowsBySettingDefaulMsgWindow();
            this.Hide();
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            CommUiltl.Log("keyData:" + keyData);
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Enter:
                    {
                        button1_Click(null,null);
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool _ConfirmRegisterPostId()
        {
            
            string showTips = "确认" + CenterContral.oStoreWhouse.name + "门店注册post机器？更改比较麻烦哦";

            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "门店确认",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return false;
            }
            return true;
        }


        //  Dao.InitCreateTable();

        private bool _ConfirmUpdatePostId()
        {

            string showTips = "确认更新Post机ID";

            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "更新post机ID",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return false;
            }
            return true;
        }
        private void returnPreventWindows()
        {
            //CenterContral.Window_ProductList.CallShowBySettingWindows();
            this.Hide();
        }

        private void SettingDefaultMsgWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CenterContral.Windows_SettingDefaultMsgWindow = new SettingDefaultMsgWindow();
            e.Cancel = false;
            returnPreventWindows();
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {
            //拉出门店信息
            _GetStoreList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //拉出门店信息
            _GetStoreList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox_StoreShop.Text == "")
            {
                MessageBox.Show("请选择门店", "门店确认");
                return;
            }
            int storeWhouseId = 0;
            CommUiltl.CoverStrToInt(((ComboxItem)comboBox_StoreShop.SelectedItem).Values, out storeWhouseId);
            //更新postid
            string strMac = textBox_Mac.Text;
            if (!CenterContral.GeneratePostId(storeWhouseId, strMac))
            {
                MessageBox.Show("生成post机ID失败:" + HttpUtility.lastErrorMsg);
                return;
            }
            MessageBox.Show("生成Post机ID成功:");
            textBox_PostID.Text = CenterContral.iPostId.ToString();
            return;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox_StoreShop.Text == "")
            {
                MessageBox.Show("请选择门店", "门店确认");
                return;
            }
            int storeWhouseId = 0;
            CommUiltl.CoverStrToInt(((ComboxItem)comboBox_StoreShop.SelectedItem).Values, out storeWhouseId);

            if ( !CenterContral.LoginByUser(textBox_user.Text, textBox_userPassword.Text, storeWhouseId))
            {
                MessageBox.Show("登录失败");
                return;
            }
            MessageBox.Show("登录成功");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string showTips = "确认更新商品信息，确认后将会耗时很长";

            var confirmPayApartResult = MessageBox.Show(showTips,
                                  "更新确认方式",
                                  MessageBoxButtons.YesNo);

            if (confirmPayApartResult != DialogResult.Yes)
            {
                return ;
            }
            CenterContral.UpdateAllGoods();
            MessageBox.Show("更新成功");
            return ;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            _GetMac();
        }
    }

}
