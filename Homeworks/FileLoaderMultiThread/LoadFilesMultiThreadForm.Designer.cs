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
            this.FileNameLbl = new System.Windows.Forms.Label();
            this.choosePathBtn = new System.Windows.Forms.Button();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // FileNameLbl
            // 
            this.FileNameLbl.AutoSize = true;
            this.FileNameLbl.Location = new System.Drawing.Point(12, 9);
            this.FileNameLbl.Name = "FileNameLbl";
            this.FileNameLbl.Size = new System.Drawing.Size(235, 20);
            this.FileNameLbl.TabIndex = 1;
            this.FileNameLbl.Text = "Выберите файл для загрузки";
            // 
            // choosePathBtn
            // 
            this.choosePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.choosePathBtn.Location = new System.Drawing.Point(12, 60);
            this.choosePathBtn.Name = "choosePathBtn";
            this.choosePathBtn.Size = new System.Drawing.Size(183, 32);
            this.choosePathBtn.TabIndex = 2;
            this.choosePathBtn.Text = "Выбрать файл";
            this.choosePathBtn.UseVisualStyleBackColor = true;
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveFileBtn.Location = new System.Drawing.Point(289, 60);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(183, 32);
            this.SaveFileBtn.TabIndex = 3;
            this.SaveFileBtn.Text = "Сохранить файл";
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // LoadFilesMultiThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 104);
            this.Controls.Add(this.SaveFileBtn);
            this.Controls.Add(this.choosePathBtn);
            this.Controls.Add(this.FileNameLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2134231446, 160);
            this.MinimumSize = new System.Drawing.Size(506, 160);
            this.Name = "LoadFilesMultiThreadForm";
            this.Text = "File Loader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FileNameLbl;
        private System.Windows.Forms.Button choosePathBtn;
        private System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

