using System;
using System.Windows.Forms;
using System.Drawing;

namespace StringLengthCounterAndBuffer
{
    public partial class Form1 : Form
    {

        #region Initialization

        private TextBox textBox1 = new TextBox();
        private TextBox textBox2 = new TextBox();
        private Label stringLbl = new Label();
        private Label stringCounterLbl = new Label();

        private void CustomInitializeComponent()
        {
            SuspendLayout(); // Метод приостанавливающий автоматическую раскладку элементов на форме
 
            // textBox1

            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(8, 27);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 78);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
          
            // textBox2
          
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(8, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(288, 20);
            textBox2.TabIndex = 1;
            
            // stringLbl
            
            stringLbl.AutoSize = true;
            stringLbl.Location = new Point(12, 11);
            stringLbl.Name = "stringLbl";
            stringLbl.Size = new Size(43, 13);
            stringLbl.TabIndex = 2;
            stringLbl.Text = "Строка";
            
            // stringCounterLbl
            
            stringCounterLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            stringCounterLbl.AutoSize = true;
            stringCounterLbl.Location = new Point(12, 108);
            stringCounterLbl.Name = "stringCounterLbl";
            stringCounterLbl.Size = new Size(166, 13);
            stringCounterLbl.TabIndex = 3;
            stringCounterLbl.Text = "Количество символов в строке";
            
            // Form1
            
            AutoScaleDimensions = new SizeF(6F, 15F); 
            AutoScaleMode = AutoScaleMode.Font; //Масштабировать элементы в зависимости от шрифта системы
            ClientSize = new Size(302, 154);
            Controls.Add(this.stringCounterLbl);
            Controls.Add(this.stringLbl);
            Controls.Add(this.textBox2);
            Controls.Add(this.textBox1);
            MaximizeBox = false; // Убираем функцию на весь экран
            MinimumSize = new Size(318, 193); //Минимальный размер 
            Name = "Form1";
            Text = "StringLengthCounter";
            Shown += new EventHandler(Form1_Shown);

            ResumeLayout(false); //Возобновление раскладки элементов 
            PerformLayout(); //Применение изменений
        }

        #endregion

        public Form1()
        {
            CustomInitializeComponent();
            textBox1.Text = string.Empty;
            textBox2.Text = textBox1.Text.Length.ToString();
        }

        /// <summary>
        /// При изменении текста производится подсчет длины строки
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.Length.ToString(); 
        }

        /// <summary>
        /// При выходе из textbox текст заносится в буфер обмена и удаляется из textBox
        /// </summary>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            { 
                Clipboard.SetText(textBox1.Text);
            }
            textBox1.Clear();
        }

        /// <summary>
        /// При повторном фокусе textBox текст копируется из буфера обмена в textBox 
        /// </summary>
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
        }

        /// <summary>
        /// При инициализации формы подписываемся на события для фокуса textBox
        /// </summary>
        private void Form1_Shown(object sender, EventArgs e)
        {
            Clipboard.Clear();
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
        }
    }
}
