using System;
using System.Windows.Forms;

namespace StringLengthCounterAndBuffer
{
    public partial class Form1 : Form
    {
        private bool IsInitialised = true;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = string.Empty;
            textBox2.Text = textBox1.Text.Length.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox2.Text = textBox1.Text.Length.ToString(); 
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            textBox1.Clear();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (IsInitialised)
            {
                IsInitialised = false;
                return;
            }
            textBox1.Text = Clipboard.GetText();
        }
    }
}
