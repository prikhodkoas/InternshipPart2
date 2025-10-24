using System;
using System.Windows.Forms;

namespace StringLengthCounterAndBuffer
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private TextBox textBox2;
        private Label stringLbl;
        private Label stringCounterLbl;

        public Form1()
        {
            InitializeComponent();
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
