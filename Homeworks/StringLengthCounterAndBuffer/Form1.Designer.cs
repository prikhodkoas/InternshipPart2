namespace StringLengthCounterAndBuffer
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.stringLbl = new System.Windows.Forms.Label();
            this.stringCounterLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 78);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 124);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 20);
            this.textBox2.TabIndex = 1;
            // 
            // stringLbl
            // 
            this.stringLbl.AutoSize = true;
            this.stringLbl.Location = new System.Drawing.Point(12, 11);
            this.stringLbl.Name = "stringLbl";
            this.stringLbl.Size = new System.Drawing.Size(43, 13);
            this.stringLbl.TabIndex = 2;
            this.stringLbl.Text = "Строка";
            // 
            // stringCounterLbl
            // 
            this.stringCounterLbl.AutoSize = true;
            this.stringCounterLbl.Location = new System.Drawing.Point(12, 108);
            this.stringCounterLbl.Name = "stringCounterLbl";
            this.stringCounterLbl.Size = new System.Drawing.Size(166, 13);
            this.stringCounterLbl.TabIndex = 3;
            this.stringCounterLbl.Text = "Количество символов в строке";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 192);
            this.Controls.Add(this.stringCounterLbl);
            this.Controls.Add(this.stringLbl);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = " StringLengthCounter";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label stringLbl;
        private System.Windows.Forms.Label stringCounterLbl;
    }
}

