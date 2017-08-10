namespace CashRegisterApplication.window.function
{
    partial class FunctionMenuWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionMenuWindow));
            this.buttonRecharge = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Show = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettingSystem = new System.Windows.Forms.Button();
            this.buttonCloudSystem = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Show.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRecharge
            // 
            this.buttonRecharge.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRecharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRecharge.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRecharge.FlatAppearance.BorderSize = 10;
            this.buttonRecharge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonRecharge.Location = new System.Drawing.Point(10, 10);
            this.buttonRecharge.Margin = new System.Windows.Forms.Padding(10);
            this.buttonRecharge.Name = "buttonRecharge";
            this.buttonRecharge.Size = new System.Drawing.Size(80, 73);
            this.buttonRecharge.TabIndex = 5;
            this.buttonRecharge.Tag = "0";
            this.buttonRecharge.Text = "会员充值(0)";
            this.buttonRecharge.UseVisualStyleBackColor = false;
            this.buttonRecharge.Click += new System.EventHandler(this.buttonRecharge_Click);
            this.buttonRecharge.Enter += new System.EventHandler(this.buttonBasePay_Enter);
            this.buttonRecharge.Leave += new System.EventHandler(this.buttonBasePay_Leave);
            // 
            // tableLayoutPanel_Show
            // 
            this.tableLayoutPanel_Show.ColumnCount = 3;
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Show.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Show.Controls.Add(this.buttonSettingSystem, 2, 0);
            this.tableLayoutPanel_Show.Controls.Add(this.buttonCloudSystem, 1, 0);
            this.tableLayoutPanel_Show.Controls.Add(this.buttonRecharge, 0, 0);
            this.tableLayoutPanel_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Show.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Show.Name = "tableLayoutPanel_Show";
            this.tableLayoutPanel_Show.RowCount = 1;
            this.tableLayoutPanel_Show.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel_Show.Size = new System.Drawing.Size(302, 91);
            this.tableLayoutPanel_Show.TabIndex = 2;
            // 
            // buttonSettingSystem
            // 
            this.buttonSettingSystem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonSettingSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSettingSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSettingSystem.FlatAppearance.BorderSize = 10;
            this.buttonSettingSystem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonSettingSystem.Location = new System.Drawing.Point(210, 10);
            this.buttonSettingSystem.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSettingSystem.Name = "buttonSettingSystem";
            this.buttonSettingSystem.Size = new System.Drawing.Size(82, 73);
            this.buttonSettingSystem.TabIndex = 7;
            this.buttonSettingSystem.Tag = "2";
            this.buttonSettingSystem.Text = "系统设置(2)";
            this.buttonSettingSystem.UseVisualStyleBackColor = false;
            this.buttonSettingSystem.Click += new System.EventHandler(this.buttonSettingSystem_Click);
            this.buttonSettingSystem.Enter += new System.EventHandler(this.buttonBasePay_Enter);
            this.buttonSettingSystem.Leave += new System.EventHandler(this.buttonBasePay_Leave);
            // 
            // buttonCloudSystem
            // 
            this.buttonCloudSystem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonCloudSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCloudSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonCloudSystem.FlatAppearance.BorderSize = 10;
            this.buttonCloudSystem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonCloudSystem.Location = new System.Drawing.Point(110, 10);
            this.buttonCloudSystem.Margin = new System.Windows.Forms.Padding(10);
            this.buttonCloudSystem.Name = "buttonCloudSystem";
            this.buttonCloudSystem.Size = new System.Drawing.Size(80, 73);
            this.buttonCloudSystem.TabIndex = 6;
            this.buttonCloudSystem.Tag = "1";
            this.buttonCloudSystem.Text = "云系统(1)";
            this.buttonCloudSystem.UseVisualStyleBackColor = false;
            this.buttonCloudSystem.Click += new System.EventHandler(this.buttonCloudSystem_Click);
            this.buttonCloudSystem.Enter += new System.EventHandler(this.buttonBasePay_Enter);
            this.buttonCloudSystem.Leave += new System.EventHandler(this.buttonBasePay_Leave);
            // 
            // FunctionMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 91);
            this.Controls.Add(this.tableLayoutPanel_Show);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionMenuWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能菜单";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FunctionMenuWindow_FormClosing);
            this.Load += new System.EventHandler(this.FuncitonMenu_Load);
            this.tableLayoutPanel_Show.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRecharge;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Show;
        private System.Windows.Forms.Button buttonSettingSystem;
        private System.Windows.Forms.Button buttonCloudSystem;
    }
}