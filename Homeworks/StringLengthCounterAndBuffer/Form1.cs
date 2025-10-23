using System;
using System.Windows.Forms;

namespace StringLengthCounterAndBuffer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = null;
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
            textBox1.Text = Clipboard.GetText();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
