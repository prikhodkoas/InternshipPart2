using FileLoaderMultiThread.Model;
using FileLoaderMultiThread.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoaderMultiThread
{
    public partial class LoadFilesMultiThreadForm : Form
    {
        private readonly IFileLoaderService _fileLoaderService;

        private string savePath;
        private string downloadURI;
        public LoadFilesMultiThreadForm(IFileLoaderService fileLoaderService)
        {
            InitializeComponent();
            _fileLoaderService = fileLoaderService;

            choosePathBtn.Click += choosePathBtn_Click;
            saveFileBtn.Click += saveFileBtn_Click;
        }

        private void choosePathBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Выберите путь для сохранения файла";
            saveFileDialog.Filter = "Все файлы|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog.FileName;
            }
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            downloadURI = URITxtBx.Text;

            if (string.IsNullOrWhiteSpace(downloadURI) || string.IsNullOrWhiteSpace(savePath))
            {
                MessageBox.Show("Введите ссылку и выберите путь для сохранения.");
                return;
            }

            var fileInfo = new DownloadFile()
            {
                Url = downloadURI,
                FilePathToSave = savePath
            };

            try
            {
                _fileLoaderService.LoadFile(fileInfo);
                var LoadForm = new LoadFileForm(_fileLoaderService, fileInfo.Id);
                LoadForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }
    }
}
