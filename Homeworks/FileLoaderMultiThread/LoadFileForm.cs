using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileLoaderMultiThread.Services;

namespace FileLoaderMultiThread
{
    public partial class LoadFileForm : Form
    {
        private readonly IFileLoaderService _fileLoaderService;

        private Guid _currentFileId;
        public LoadFileForm(IFileLoaderService fileLoaderService, Guid fileId)
        {
            InitializeComponent();

            _fileLoaderService = fileLoaderService;
            this.fileIsLoadingNameLbl.Text += $"{_fileLoaderService.GetFileLoader(fileId).GetDownloadFile().FilePathToSave}";
            _fileLoaderService.ProgressChanged += _fileLoaderService_ProgressChanged;
            _currentFileId = fileId;

        }

        private void _fileLoaderService_ProgressChanged(Guid fileId, int currentPercent)
        {
            loadingProgressBar.Value = currentPercent;
            if(currentPercent == 100)
            {
                MessageBox.Show("Загрузка завершена");
                this.Close();
            }
        }

        private void cancelLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.CancelLoadFile(_currentFileId);
        }

        private void pauseLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.PauseLoadFile(_currentFileId);
        }

        private void resumeLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.ResumeLoadFile(_currentFileId);
        }
    }
}
