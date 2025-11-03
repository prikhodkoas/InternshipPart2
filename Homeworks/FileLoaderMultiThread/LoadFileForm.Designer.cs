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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fileIsLoadingNameLbl = new System.Windows.Forms.Label();
            this.cancelLoadingBtn = new System.Windows.Forms.Button();
            this.pauseLoadingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // fileIsLoadingNameLbl
            // 
            this.fileIsLoadingNameLbl.AutoSize = true;
            this.fileIsLoadingNameLbl.Location = new System.Drawing.Point(13, 13);
            this.fileIsLoadingNameLbl.Name = "fileIsLoadingNameLbl";
            this.fileIsLoadingNameLbl.Size = new System.Drawing.Size(116, 13);
            this.fileIsLoadingNameLbl.TabIndex = 1;
            this.fileIsLoadingNameLbl.Text = "Идет загрузка файла";
            // 
            // cancelLoadingBtn
            // 
            this.cancelLoadingBtn.Location = new System.Drawing.Point(147, 58);
            this.cancelLoadingBtn.Name = "cancelLoadingBtn";
            this.cancelLoadingBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelLoadingBtn.TabIndex = 2;
            this.cancelLoadingBtn.Text = "Отмена";
            this.cancelLoadingBtn.UseVisualStyleBackColor = true;
            // 
            // pauseLoadingBtn
            // 
            this.pauseLoadingBtn.Location = new System.Drawing.Point(228, 58);
            this.pauseLoadingBtn.Name = "pauseLoadingBtn";
            this.pauseLoadingBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseLoadingBtn.TabIndex = 3;
            this.pauseLoadingBtn.Text = "Пауза";
            this.pauseLoadingBtn.UseVisualStyleBackColor = true;
            // 
            // LoadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 89);
            this.Controls.Add(this.pauseLoadingBtn);
            this.Controls.Add(this.cancelLoadingBtn);
            this.Controls.Add(this.fileIsLoadingNameLbl);
            this.Controls.Add(this.progressBar1);
            this.Name = "LoadFileForm";
            this.Text = "Загрузка файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label fileIsLoadingNameLbl;
        private System.Windows.Forms.Button cancelLoadingBtn;
        private System.Windows.Forms.Button pauseLoadingBtn;
    }
}