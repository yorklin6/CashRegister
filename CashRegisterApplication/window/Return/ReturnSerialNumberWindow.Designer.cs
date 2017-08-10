namespace CashRegisterApplication.window.Return
{
    partial class ReturnSerialNumberWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnSerialNumberWindow));
            this.button_enter = new System.Windows.Forms.Button();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(103, 110);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(75, 23);
            this.button_enter.TabIndex = 2;
            this.button_enter.Text = "确认";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(71, 66);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(152, 21);
            this.textBox_time.TabIndex = 0;
            this.textBox_time.TextChanged += new System.EventHandler(this.textBox_time_TextChanged);
            // 
            // ReturnSerialNumberWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 166);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_time);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnSerialNumberWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入退货单号";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnSerialNumberWindow_FormClosing);
            this.Load += new System.EventHandler(this.ReturnSerialNumber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.TextBox textBox_time;
    }
}