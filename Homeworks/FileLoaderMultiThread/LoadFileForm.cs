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

        private readonly string filePath; 

        public LoadFileForm(IFileLoaderService fileLoaderService, Guid fileId)
        {
            InitializeComponent();

            _fileLoaderService = fileLoaderService;
            _currentFileId = fileId;

            var loader = _fileLoaderService.GetFileLoader(fileId);
            filePath = loader.GetUploadFile().FilePathFromSave;
            this.fileIsLoadingNameLbl.Text += $" {filePath}";

            _fileLoaderService.ProgressChanged += _fileLoaderService_ProgressChanged;
        }

        private void _fileLoaderService_ProgressChanged(Guid fileId, int currentPercent)
        {
            if (fileId != _currentFileId)
                return;

            if (InvokeRequired)
            {
                Invoke(new Action<Guid, int>(_fileLoaderService_ProgressChanged), fileId, currentPercent);
                return;
            }

            loadingProgressBar.Value = currentPercent;
            if (currentPercent == 100)
            {
                MessageBox.Show($"Файл успешно загружен: {filePath}");
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
