using CashRegisterApplication.comm;
using CashRegisterApplication.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CashRegisterApplication.window.History
{
    public partial class HistoryWindow : Form
    {
        public HistoryWindow()
        {
            InitializeComponent();
            CenterContral.Init();
        }

        List<StockOutDTO> listStockOutDTO = new List<StockOutDTO>();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

      

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CommUiltl.Log("row:"+e.RowIndex);
            ShowDetailWindow(e.RowIndex);
        }

        private void ShowDetailWindow(int rowIndex)
        {
            if (rowIndex < -1 || rowIndex > listStockOutDTO.Count)
            {
                return;
            }
            
        }

        private void HistoryWindow_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Today;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void RefreshData()
        {
           
            DateTime oDate= this.dateTimePicker1.Value;
            listStockOutDTO = new List<StockOutDTO>();
            if (!CenterContral.GetStockOutMsgByDate(oDate, ref listStockOutDTO))
            {
                return;
            }
            ShowDataGrivewByStoctOutMsg(listStockOutDTO);
        }

        private void ShowDataGrivewByStoctOutMsg(List<StockOutDTO> listStockOutDTO)
        {
            this.dataGridView_HistoryData.Rows.Clear();

            for (int i=0 ; i< listStockOutDTO.Count ; i++)
            {
              
                this.dataGridView_HistoryData.Rows.Add();
                SetRowsByStockOutDetail(this.dataGridView_HistoryData.Rows[i], listStockOutDTO[i].Base) ;
                return;
            }
            label_total_count.Text = "一共有" + listStockOutDTO.Count + "笔交易";
            //默认选中最后一笔交易
            if (listStockOutDTO.Count > 0)
            {
                this.dataGridView_HistoryData.CurrentCell = this.dataGridView_HistoryData.Rows[0].Cells[0];
             }
        }

        private int CELL_SERIAL_NUMBER = 0;
        private int CELL_CREATETIME = 1;
        private int CELL_ORDER_AMOUNT = 2;
        private int CELL_TOTAL_COUNT = 3;
        private int CELL_CREATOR = 4;
        private int CELL_STATE = 5;
        private void SetRowsByStockOutDetail(DataGridViewRow dataGridViewRow, StockOutBase oStockOutBase)
        {
            dataGridViewRow.Cells[CELL_SERIAL_NUMBER].Value = oStockOutBase.serialNumber;
            dataGridViewRow.Cells[CELL_CREATETIME].Value = oStockOutBase.stockOutTime ;
            dataGridViewRow.Cells[CELL_ORDER_AMOUNT].Value = CommUiltl.CoverMoneyUnionToStrYuan(oStockOutBase.orderAmount);
            dataGridViewRow.Cells[CELL_TOTAL_COUNT].Value = oStockOutBase.totalProductCount;
            dataGridViewRow.Cells[CELL_CREATOR].Value = oStockOutBase.creator;
            dataGridViewRow.Cells[CELL_STATE].Value = CenterContral.GetStateDscByStockOutBase(oStockOutBase);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_HistoryData.CurrentCell != null)
            {
                MessageBox.Show("请选中打印的订单");
                return;
            }
           
            //if ()
            //{
            //    var confirmPayApartResult = MessageBox.Show("是否要打印前一笔小票",
            //      showTips,
            //       MessageBoxButtons.YesNo);

            //    if (confirmPayApartResult != DialogResult.Yes)
            //    {
            //        return;
            //    }
            //    return;
            //}
        }
    }
}
