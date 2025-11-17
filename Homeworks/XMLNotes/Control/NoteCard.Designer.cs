namespace XMLNotes
{
    partial class NoteCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLbl = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TextLbl = new System.Windows.Forms.Label();
            this.CreatedAtLbl = new System.Windows.Forms.Label();
            this.CreatedAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(8, 5);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(57, 13);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Название";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(8, 21);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(284, 20);
            this.TitleTextBox.TabIndex = 1;
            // 
            // TextRichTextBox
            // 
            this.TextRichTextBox.AcceptsTab = true;
            this.TextRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextRichTextBox.DetectUrls = false;
            this.TextRichTextBox.Location = new System.Drawing.Point(8, 60);
            this.TextRichTextBox.Name = "TextRichTextBox";
            this.TextRichTextBox.Size = new System.Drawing.Size(284, 106);
            this.TextRichTextBox.TabIndex = 2;
            this.TextRichTextBox.Text = "";
            // 
            // TextLbl
            // 
            this.TextLbl.AutoSize = true;
            this.TextLbl.Location = new System.Drawing.Point(8, 44);
            this.TextLbl.Name = "TextLbl";
            this.TextLbl.Size = new System.Drawing.Size(51, 13);
            this.TextLbl.TabIndex = 3;
            this.TextLbl.Text = "Заметка";
            // 
            // CreatedAtLbl
            // 
            this.CreatedAtLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreatedAtLbl.AutoSize = true;
            this.CreatedAtLbl.Location = new System.Drawing.Point(8, 175);
            this.CreatedAtLbl.Name = "CreatedAtLbl";
            this.CreatedAtLbl.Size = new System.Drawing.Size(125, 13);
            this.CreatedAtLbl.TabIndex = 4;
            this.CreatedAtLbl.Text = "Последнее изменение:";
            // 
            // CreatedAtDateTimePicker
            // 
            this.CreatedAtDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatedAtDateTimePicker.Location = new System.Drawing.Point(139, 172);
            this.CreatedAtDateTimePicker.Name = "CreatedAtDateTimePicker";
            this.CreatedAtDateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.CreatedAtDateTimePicker.TabIndex = 7;
            // 
            // NoteCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.CreatedAtDateTimePicker);
            this.Controls.Add(this.CreatedAtLbl);
            this.Controls.Add(this.TextLbl);
            this.Controls.Add(this.TextRichTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.TitleLbl);
            this.Name = "NoteCard";
            this.Size = new System.Drawing.Size(300, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label TitleLbl;
        public System.Windows.Forms.TextBox TitleTextBox;
        public System.Windows.Forms.RichTextBox TextRichTextBox;
        public System.Windows.Forms.Label TextLbl;
        public System.Windows.Forms.Label CreatedAtLbl;
        public System.Windows.Forms.DateTimePicker CreatedAtDateTimePicker;
    }
}
