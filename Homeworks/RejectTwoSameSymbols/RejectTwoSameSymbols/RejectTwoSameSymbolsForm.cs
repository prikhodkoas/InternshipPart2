using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RejectTwoSameSymbols
{
    public partial class RejectTwoSameSymbolsForm : Form
    {
        #region Initialize Control Components

        #region Initialize inputTextBox 
        TextBox inputTextBox = new TextBox();
        private void Initialize_inputTextBox()
        {
            this.inputTextBox.Location = new Point(12, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new Size(333, 26);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.inputTextBox.TextChanged += InputTextBox_TextChanged;
        }
        #endregion

        #endregion
        /// <summary>
        /// Проверка на ввод двух одинаковых символов подряд
        /// </summary>
        private void InputTextBox_TextChanged(object sender, System.EventArgs e)
        {
            string input = inputTextBox.Text;

            Regex regex = new Regex(@"(.)\1");

            if (regex.IsMatch(input))
            {
                inputTextBox.ForeColor = Color.Red;
            }
            else
            {
                inputTextBox.ForeColor = Color.Black;
            }
        }
        public RejectTwoSameSymbolsForm()
        {
            InitializeComponent();
        }
    }
}
