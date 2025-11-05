namespace FileLoaderMultiThread
{
    partial class LoadFilesMultiThreadForm
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
            this.URITxtBx = new System.Windows.Forms.TextBox();
            this.URILbl = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.choosePathBtn = new System.Windows.Forms.Button();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // URITxtBx
            // 
            this.URITxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URITxtBx.Location = new System.Drawing.Point(12, 38);
            this.URITxtBx.Name = "URITxtBx";
            this.URITxtBx.Size = new System.Drawing.Size(460, 26);
            this.URITxtBx.TabIndex = 0;
            // 
            // URILbl
            // 
            this.URILbl.AutoSize = true;
            this.URILbl.Location = new System.Drawing.Point(12, 9);
            this.URILbl.Name = "URILbl";
            this.URILbl.Size = new System.Drawing.Size(201, 20);
            this.URILbl.TabIndex = 1;
            this.URILbl.Text = "URL файла для загрузки";
            // 
            // choosePathBtn
            // 
            this.choosePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.choosePathBtn.Location = new System.Drawing.Point(12, 74);
            this.choosePathBtn.Name = "choosePathBtn";
            this.choosePathBtn.Size = new System.Drawing.Size(130, 32);
            this.choosePathBtn.TabIndex = 2;
            this.choosePathBtn.Text = "Выбор пути";
            this.choosePathBtn.UseVisualStyleBackColor = true;
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileBtn.Location = new System.Drawing.Point(291, 74);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(183, 32);
            this.saveFileBtn.TabIndex = 3;
            this.saveFileBtn.Text = "Сохранить файл";
            this.saveFileBtn.UseVisualStyleBackColor = true;
            // 
            // LoadFilesMultiThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 104);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.choosePathBtn);
            this.Controls.Add(this.URILbl);
            this.Controls.Add(this.URITxtBx);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2134231443, 160);
            this.MinimumSize = new System.Drawing.Size(506, 160);
            this.Name = "LoadFilesMultiThreadForm";
            this.Text = "File Loader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URITxtBx;
        private System.Windows.Forms.Label URILbl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button choosePathBtn;
        private System.Windows.Forms.Button saveFileBtn;
    }
}

