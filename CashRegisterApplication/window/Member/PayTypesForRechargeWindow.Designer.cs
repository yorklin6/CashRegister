namespace CashRegisterApplication.window
{
    partial class PayTypesForRechargeWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayTypesForRechargeWindow));
            this.buttonBasePay = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Show = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Show.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBasePay
            // 
            this.buttonBasePay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBasePay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBasePay.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBasePay.FlatAppearance.BorderSize = 10;
            this.buttonBasePay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonBasePay.Location = new System.Drawing.Point(10, 10);
            this.buttonBasePay.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBasePay.Name = "buttonBasePay";
            this.buttonBasePay.Size = new System.Drawing.Size(174, 72);
            this.buttonBasePay.TabIndex = 5;
            this.buttonBasePay.Text = "支付";
            this.buttonBasePay.UseVisualStyleBackColor = false;
            this.buttonBasePay.Click += new System.EventHandler(this.buttonBasePay_Click_1);
            this.buttonBasePay.Enter += new System.EventHandler(this.buttonBasePay_Enter);
            this.buttonBasePay.Leave += new System.EventHandler(this.buttonBasePay_Leave);
            // 
            // tableLayoutPanel_Show
            // 
            this.tableLayoutPanel_Show.ColumnCount = 3;
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel_Show.Controls.Add(this.buttonBasePay, 0, 0);
            this.tableLayoutPanel_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Show.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Show.Name = "tableLayoutPanel_Show";
            this.tableLayoutPanel_Show.RowCount = 6;
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Show.Size = new System.Drawing.Size(584, 462);
            this.tableLayoutPanel_Show.TabIndex = 1;
            // 
            // PayTypesForRechargeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.tableLayoutPanel_Show);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayTypesForRechargeWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "充值支付方式";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PayTypesForRecharge_FormClosing);
            this.Load += new System.EventHandler(this.PayTypesForRecharges_Load);
            this.Shown += new System.EventHandler(this.PayTypesForRecharges_Shown);
            this.tableLayoutPanel_Show.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonBasePay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Show;
    }
}