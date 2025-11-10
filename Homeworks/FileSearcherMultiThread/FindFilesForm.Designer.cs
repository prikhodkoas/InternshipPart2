namespace FileSearcherMultiThread
{
    partial class FindFilesForm
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
            this.FileSystemTreeView = new System.Windows.Forms.TreeView();
            this.AmountOfThreadsLbl = new System.Windows.Forms.Label();
            this.FindedFilesLbl = new System.Windows.Forms.Label();
            this.AmountOfThreadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RootDirectoryLbl = new System.Windows.Forms.Label();
            this.RootDirectoryPathTxtBx = new System.Windows.Forms.TextBox();
            this.ChooseRootDirectoryBtn = new System.Windows.Forms.Button();
            this.FindingFileNameLbl = new System.Windows.Forms.Label();
            this.FindingFileNameTxtBx = new System.Windows.Forms.TextBox();
            this.ChooseRootCatalogFileDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.StartSearchBtn = new System.Windows.Forms.Button();
            this.StopSearchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfThreadsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FileSystemTreeView
            // 
            this.FileSystemTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileSystemTreeView.Location = new System.Drawing.Point(12, 28);
            this.FileSystemTreeView.Name = "FileSystemTreeView";
            this.FileSystemTreeView.Size = new System.Drawing.Size(144, 102);
            this.FileSystemTreeView.TabIndex = 0;
            // 
            // AmountOfThreadsLbl
            // 
            this.AmountOfThreadsLbl.AutoSize = true;
            this.AmountOfThreadsLbl.Location = new System.Drawing.Point(162, 12);
            this.AmountOfThreadsLbl.Name = "AmountOfThreadsLbl";
            this.AmountOfThreadsLbl.Size = new System.Drawing.Size(110, 13);
            this.AmountOfThreadsLbl.TabIndex = 1;
            this.AmountOfThreadsLbl.Text = "Количество потоков";
            // 
            // FindedFilesLbl
            // 
            this.FindedFilesLbl.AutoSize = true;
            this.FindedFilesLbl.Location = new System.Drawing.Point(12, 12);
            this.FindedFilesLbl.Name = "FindedFilesLbl";
            this.FindedFilesLbl.Size = new System.Drawing.Size(102, 13);
            this.FindedFilesLbl.TabIndex = 2;
            this.FindedFilesLbl.Text = "Найденные файлы";
            // 
            // AmountOfThreadsNumericUpDown
            // 
            this.AmountOfThreadsNumericUpDown.Location = new System.Drawing.Point(165, 28);
            this.AmountOfThreadsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AmountOfThreadsNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AmountOfThreadsNumericUpDown.Name = "AmountOfThreadsNumericUpDown";
            this.AmountOfThreadsNumericUpDown.Size = new System.Drawing.Size(107, 20);
            this.AmountOfThreadsNumericUpDown.TabIndex = 3;
            this.AmountOfThreadsNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // RootDirectoryLbl
            // 
            this.RootDirectoryLbl.AutoSize = true;
            this.RootDirectoryLbl.Location = new System.Drawing.Point(162, 60);
            this.RootDirectoryLbl.Name = "RootDirectoryLbl";
            this.RootDirectoryLbl.Size = new System.Drawing.Size(200, 13);
            this.RootDirectoryLbl.TabIndex = 4;
            this.RootDirectoryLbl.Text = "Выберите путь корневого директория";
            // 
            // RootDirectoryPathTxtBx
            // 
            this.RootDirectoryPathTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootDirectoryPathTxtBx.Enabled = false;
            this.RootDirectoryPathTxtBx.Location = new System.Drawing.Point(278, 78);
            this.RootDirectoryPathTxtBx.Name = "RootDirectoryPathTxtBx";
            this.RootDirectoryPathTxtBx.Size = new System.Drawing.Size(129, 20);
            this.RootDirectoryPathTxtBx.TabIndex = 5;
            // 
            // ChooseRootDirectoryBtn
            // 
            this.ChooseRootDirectoryBtn.Location = new System.Drawing.Point(165, 78);
            this.ChooseRootDirectoryBtn.Name = "ChooseRootDirectoryBtn";
            this.ChooseRootDirectoryBtn.Size = new System.Drawing.Size(107, 21);
            this.ChooseRootDirectoryBtn.TabIndex = 6;
            this.ChooseRootDirectoryBtn.Text = "Выбрать путь";
            this.ChooseRootDirectoryBtn.UseVisualStyleBackColor = true;
            this.ChooseRootDirectoryBtn.Click += new System.EventHandler(this.ChooseRootDirectoryBtn_Click);
            // 
            // FindingFileNameLbl
            // 
            this.FindingFileNameLbl.AutoSize = true;
            this.FindingFileNameLbl.Location = new System.Drawing.Point(278, 12);
            this.FindingFileNameLbl.Name = "FindingFileNameLbl";
            this.FindingFileNameLbl.Size = new System.Drawing.Size(116, 13);
            this.FindingFileNameLbl.TabIndex = 7;
            this.FindingFileNameLbl.Text = "Имя искомого файла";
            // 
            // FindingFileNameTxtBx
            // 
            this.FindingFileNameTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindingFileNameTxtBx.Location = new System.Drawing.Point(278, 28);
            this.FindingFileNameTxtBx.Name = "FindingFileNameTxtBx";
            this.FindingFileNameTxtBx.Size = new System.Drawing.Size(129, 20);
            this.FindingFileNameTxtBx.TabIndex = 8;
            // 
            // StartSearchBtn
            // 
            this.StartSearchBtn.Location = new System.Drawing.Point(165, 107);
            this.StartSearchBtn.Name = "StartSearchBtn";
            this.StartSearchBtn.Size = new System.Drawing.Size(107, 23);
            this.StartSearchBtn.TabIndex = 9;
            this.StartSearchBtn.Text = "Начать поиск";
            this.StartSearchBtn.UseVisualStyleBackColor = true;
            this.StartSearchBtn.Click += new System.EventHandler(this.StartSearchBtn_Click);
            // 
            // StopSearchBtn
            // 
            this.StopSearchBtn.Location = new System.Drawing.Point(278, 107);
            this.StopSearchBtn.Name = "StopSearchBtn";
            this.StopSearchBtn.Size = new System.Drawing.Size(107, 23);
            this.StopSearchBtn.TabIndex = 10;
            this.StopSearchBtn.Text = "Прервать поиск";
            this.StopSearchBtn.UseVisualStyleBackColor = true;
            // 
            // FindFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 139);
            this.Controls.Add(this.StopSearchBtn);
            this.Controls.Add(this.StartSearchBtn);
            this.Controls.Add(this.FindingFileNameTxtBx);
            this.Controls.Add(this.FindingFileNameLbl);
            this.Controls.Add(this.ChooseRootDirectoryBtn);
            this.Controls.Add(this.RootDirectoryPathTxtBx);
            this.Controls.Add(this.RootDirectoryLbl);
            this.Controls.Add(this.AmountOfThreadsNumericUpDown);
            this.Controls.Add(this.FindedFilesLbl);
            this.Controls.Add(this.AmountOfThreadsLbl);
            this.Controls.Add(this.FileSystemTreeView);
            this.MinimumSize = new System.Drawing.Size(435, 147);
            this.Name = "FindFilesForm";
            this.Text = "Поиск файлов в файловой системе";
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfThreadsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FileSystemTreeView;
        private System.Windows.Forms.Label AmountOfThreadsLbl;
        private System.Windows.Forms.Label FindedFilesLbl;
        private System.Windows.Forms.NumericUpDown AmountOfThreadsNumericUpDown;
        private System.Windows.Forms.Label RootDirectoryLbl;
        private System.Windows.Forms.TextBox RootDirectoryPathTxtBx;
        private System.Windows.Forms.Button ChooseRootDirectoryBtn;
        private System.Windows.Forms.Label FindingFileNameLbl;
        private System.Windows.Forms.TextBox FindingFileNameTxtBx;
        private System.Windows.Forms.FolderBrowserDialog ChooseRootCatalogFileDialog;
        private System.Windows.Forms.Button StartSearchBtn;
        private System.Windows.Forms.Button StopSearchBtn;
    }
}

