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
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.textBox_random = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_store_id = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(92, 66);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(112, 21);
            this.textBox_time.TabIndex = 0;
            this.textBox_time.TextChanged += new System.EventHandler(this.textBox_time_TextChanged);
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
            // textBox_random
            // 
            this.textBox_random.Location = new System.Drawing.Point(214, 66);
            this.textBox_random.Name = "textBox_random";
            this.textBox_random.Size = new System.Drawing.Size(27, 21);
            this.textBox_random.TabIndex = 3;
            this.textBox_random.TextChanged += new System.EventHandler(this.textBox_random_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // textBox_store_id
            // 
            this.textBox_store_id.Location = new System.Drawing.Point(71, 66);
            this.textBox_store_id.Name = "textBox_store_id";
            this.textBox_store_id.Size = new System.Drawing.Size(12, 21);
            this.textBox_store_id.TabIndex = 5;
            this.textBox_store_id.TextChanged += new System.EventHandler(this.textBox_store_id_TextChanged);
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(46, 66);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.Size = new System.Drawing.Size(19, 21);
            this.textBox_type.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // ReturnSerialNumberWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 166);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.textBox_store_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_random);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_time);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnSerialNumberWindow";
            this.Text = "请输入退货单号";
            this.Load += new System.EventHandler(this.ReturnSerialNumber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.TextBox textBox_random;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_store_id;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}