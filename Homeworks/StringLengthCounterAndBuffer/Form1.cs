using System;
using System.Windows.Forms;

namespace StringLengthCounterAndBuffer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Поле для проверки является ли запуск первым
        /// </summary>
        private bool _isInitialised = true;

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
            Clipboard.SetText(textBox1.Text);
            textBox1.Clear();
        }

        /// <summary>
        /// При повторном фокусе textBox текст копируется из буфера обмена в textBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (_isInitialised)
            {
                _isInitialised = false;
                return;
            }
            textBox1.Text = Clipboard.GetText();
        }
    }
}
