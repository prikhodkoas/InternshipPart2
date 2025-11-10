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
            _fileLoaderService.Completed += _fileLoaderService_Completed;
        }

        /// <summary>
        /// Событие изменения прогресса загрузки
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="currentPercent"></param>
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
        }

        private void cancelLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.CancelLoadFile(_currentFileId);
            this.Close();
        }

        private void pauseLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.PauseLoadFile(_currentFileId);
        }

        private void resumeLoadingBtn_Click(object sender, EventArgs e)
        {
            _fileLoaderService.ResumeLoadFile(_currentFileId);
        }

        /// <summary>
        /// Событие завершения процесса загрузки
        /// </summary>
        /// <param name="fileId"></param>
        private void _fileLoaderService_Completed(Guid fileId)
        {
            if (fileId != _currentFileId) return;

            if (InvokeRequired)
            {
                Invoke(new Action<Guid>(_fileLoaderService_Completed), fileId);
                return;
            }

            MessageBox.Show($"Файл успешно загружен: {filePath}");
            this.Close();
        }
    }
}
