using CashRegisterApplication.comm;
using CashRegisterApplication.model;
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
            CenterContral.InitWindows();
        }

       

        private void SettingDefaultMsg_Load(object sender, EventArgs e)
        {
            //拉出门店信息
            _GetStoreList();
            //获取mac地址
            _GetMac();
            //获取postID
            _GetPostId();
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
            CenterContral.GetStoreMsg();
            List<ComboxItem> oListItem = new List<ComboxItem>();
            if (CenterContral.oStoreWhouseData.list.Count == 0)
            {
                MessageBox.Show("系统异常，未能拉出门店信息:");
                return;
            }

            int selectIndex = 0;
            for (int i = 0; i < CenterContral.oStoreWhouseData.list.Count; ++i)
            {
                StoreWhouse item = CenterContral.oStoreWhouseData.list[i];
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
            //取得下拉框门店id信息
            int storeWhouseId = 0;
            CommUiltl.Log("SelectedItem:" + ((ComboxItem)comboBox_StoreShop.SelectedItem).Values);
            CommUiltl.CoverStrToInt(((ComboxItem)comboBox_StoreShop.SelectedItem).Values, out storeWhouseId);
            for (int i = 0; i < CenterContral.oStoreWhouseData.list.Count; ++i)
            {
                if (storeWhouseId == CenterContral.oStoreWhouseData.list[i].storeWhouseId)
                {
                    CenterContral.oStoreWhouse = CenterContral.oStoreWhouseData.list[i];
                    CenterContral.oStoreWhouseData.selectStockIndex = i;
                }
            }
            //更新默认门店信息
            string strStoreWhouseDefult = JsonConvert.SerializeObject(CenterContral.oStoreWhouse);
            CenterContral.UpdateStoreWhouseDefault(strStoreWhouseDefult);

         
            //更新postid
            if (CenterContral.iPostId == -1)
            {
                //说明mac从来都没有注册过，于是自动生成
                if (_ConfirmRegisterPostId())
                {
                    if (CenterContral.GeneratePostId())
                    {
                        textBox_PostID.Text = CenterContral.iPostId.ToString();
                    }
                }
            }
            else if (textBox_PostID.Text != CenterContral.iPostId.ToString())
            {
                int iPostId = 0;
                if (CommUiltl.CoverStrToInt(textBox_PostID.Text,out iPostId))
                {
                    //说明更新post机id
                    if (_ConfirmUpdatePostId())
                    {
                        CenterContral.iPostId = iPostId;
                        CenterContral.SetPostIdFromDb();
                    }
                }
            }
            MessageBox.Show("更新成功");
            CenterContral.Window_ProductList.CallShowBySettingWindows();
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
            CenterContral.Window_ProductList.CallShowBySettingWindows();
            this.Hide();
        }

        private void SettingDefaultMsgWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            returnPreventWindows();
        }
        
    }

}
