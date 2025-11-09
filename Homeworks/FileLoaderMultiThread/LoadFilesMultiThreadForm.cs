using FileLoaderMultiThread.Model;
using FileLoaderMultiThread.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoaderMultiThread
{
    public partial class LoadFilesMultiThreadForm : Form
    {
        /// <summary>
        /// Сервис по многопоточной загрузке файлов
        /// </summary>
        private readonly IFileLoaderService _fileLoaderService;

        private string fileName;

        private string filePath;

        public LoadFilesMultiThreadForm(IFileLoaderService fileLoaderService)
        {
            InitializeComponent();
            _fileLoaderService = fileLoaderService;

            choosePathBtn.Click += choosePathBtn_Click;
            SaveFileBtn.Click += saveFileBtn_Click;
        }

        private void choosePathBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Выберите путь для открытия файла";
            openFileDialog.Filter = "Все файлы|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                FileNameLbl.Text = "Выбранный файл: " + filePath;
            }
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            fileName = Path.GetFileName(filePath);

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Выберите путь для открытия.");
                return;
            }

            var fileInfo = new UploadFile()
            {
                Name = fileName,
                FilePathFromSave = filePath
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
