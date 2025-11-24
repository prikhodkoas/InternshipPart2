namespace FileLoaderMultiThread
{
    partial class LoadFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.fileIsLoadingNameLbl = new System.Windows.Forms.Label();
            this.cancelLoadingBtn = new System.Windows.Forms.Button();
            this.pauseLoadingBtn = new System.Windows.Forms.Button();
            this.resumeLoadingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Location = new System.Drawing.Point(18, 45);
            this.loadingProgressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(436, 35);
            this.loadingProgressBar.TabIndex = 0;
            // 
            // fileIsLoadingNameLbl
            // 
            this.fileIsLoadingNameLbl.AutoSize = true;
            this.fileIsLoadingNameLbl.Location = new System.Drawing.Point(20, 20);
            this.fileIsLoadingNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileIsLoadingNameLbl.Name = "fileIsLoadingNameLbl";
            this.fileIsLoadingNameLbl.Size = new System.Drawing.Size(174, 20);
            this.fileIsLoadingNameLbl.TabIndex = 1;
            this.fileIsLoadingNameLbl.Text = "Идет загрузка файла";
            // 
            // cancelLoadingBtn
            // 
            this.cancelLoadingBtn.Location = new System.Drawing.Point(18, 89);
            this.cancelLoadingBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelLoadingBtn.Name = "cancelLoadingBtn";
            this.cancelLoadingBtn.Size = new System.Drawing.Size(112, 35);
            this.cancelLoadingBtn.TabIndex = 2;
            this.cancelLoadingBtn.Text = "Отмена";
            this.cancelLoadingBtn.UseVisualStyleBackColor = true;
            this.cancelLoadingBtn.Click += new System.EventHandler(this.cancelLoadingBtn_Click);
            // 
            // pauseLoadingBtn
            // 
            this.pauseLoadingBtn.Location = new System.Drawing.Point(204, 89);
            this.pauseLoadingBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pauseLoadingBtn.Name = "pauseLoadingBtn";
            this.pauseLoadingBtn.Size = new System.Drawing.Size(112, 35);
            this.pauseLoadingBtn.TabIndex = 3;
            this.pauseLoadingBtn.Text = "Пауза";
            this.pauseLoadingBtn.UseVisualStyleBackColor = true;
            this.pauseLoadingBtn.Click += new System.EventHandler(this.pauseLoadingBtn_Click);
            // 
            // resumeLoadingBtn
            // 
            this.resumeLoadingBtn.Location = new System.Drawing.Point(326, 89);
            this.resumeLoadingBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resumeLoadingBtn.Name = "resumeLoadingBtn";
            this.resumeLoadingBtn.Size = new System.Drawing.Size(129, 35);
            this.resumeLoadingBtn.TabIndex = 4;
            this.resumeLoadingBtn.Text = "Возобновить";
            this.resumeLoadingBtn.UseVisualStyleBackColor = true;
            this.resumeLoadingBtn.Click += new System.EventHandler(this.resumeLoadingBtn_Click);
            // 
            // LoadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 137);
            this.Controls.Add(this.resumeLoadingBtn);
            this.Controls.Add(this.pauseLoadingBtn);
            this.Controls.Add(this.cancelLoadingBtn);
            this.Controls.Add(this.fileIsLoadingNameLbl);
            this.Controls.Add(this.loadingProgressBar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoadFileForm";
            this.Text = "Загрузка файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.Label fileIsLoadingNameLbl;
        private System.Windows.Forms.Button cancelLoadingBtn;
        private System.Windows.Forms.Button pauseLoadingBtn;
        private System.Windows.Forms.Button resumeLoadingBtn;
    }
}