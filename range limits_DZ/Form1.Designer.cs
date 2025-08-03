namespace range_limits_DZ
{
    partial class listBoxPrimes
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnFindPrimes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(414, 65);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 22);
            this.txtTo.TabIndex = 0;
            this.txtTo.Text = "ДО";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(237, 64);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 22);
            this.txtFrom.TabIndex = 1;
            this.txtFrom.Text = "ОТ";
            // 
            // btnFindPrimes
            // 
            this.btnFindPrimes.Location = new System.Drawing.Point(237, 127);
            this.btnFindPrimes.Name = "btnFindPrimes";
            this.btnFindPrimes.Size = new System.Drawing.Size(108, 57);
            this.btnFindPrimes.TabIndex = 2;
            this.btnFindPrimes.Text = "Простые числа";
            this.btnFindPrimes.UseVisualStyleBackColor = true;
            this.btnFindPrimes.Click += new System.EventHandler(this.btnFindPrimes_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 57);
            this.button2.TabIndex = 3;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(59, 147);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(167, 16);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Кол-во найденных чисел";
            this.lblResult.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(62, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 84);
            this.listBox1.TabIndex = 5;
            // 
            // listBoxPrimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFindPrimes);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtTo);
            this.Name = "listBoxPrimes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.listBoxPrimes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnFindPrimes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox listBox1;
    }
}

