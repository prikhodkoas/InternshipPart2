using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RejectTwoSameSymbols
{
    public partial class RejectTwoSameSymbolsForm : Form
    {
        private Color DefaultTextColor = Color.Black;
        private Color RejectedTextColor = Color.Red;

        private readonly ValidationService ValidationService = new ValidationService();

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
            if (ValidationService.IsTwoSameSymbols(inputTextBox.Text))
            {
                inputTextBox.ForeColor = RejectedTextColor;
            }
            else
            {
                inputTextBox.ForeColor = DefaultTextColor;
            }
        }
        public RejectTwoSameSymbolsForm()
        {
            InitializeComponent();
        }
    }
}
