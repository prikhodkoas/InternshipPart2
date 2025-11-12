using Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileSearcherMultiThread
{
    public partial class FindFilesForm : Form
    {
        /// <summary>
        /// Сервис по поиску файла в файловой системе
        /// </summary>
        private readonly IFileSearchService _fileSearchService;

        /// <summary>
        /// Путь корневой папки
        /// </summary>
        private string _rootDirectoryPath;

        /// <summary>
        /// Имя искомого файла
        /// </summary>
        private string _fileName;

        public FindFilesForm(IFileSearchService fileSearchService)
        {
            _fileSearchService = fileSearchService;
            InitializeComponent();
            _fileSearchService.FindedPathes.CollectionChanged += FindedNewFile;
            _fileSearchService.SearchCompleted += _fileSearchService_SearchCompleted;
        }

        private void ChooseRootDirectoryBtn_Click(object sender, EventArgs e)
        {
            ChooseRootCatalogFileDialog.Description = "Выберите корневую директорию";
            ChooseRootCatalogFileDialog.ShowNewFolderButton = true;

            if (ChooseRootCatalogFileDialog.ShowDialog() == DialogResult.OK)
            {
                _rootDirectoryPath = ChooseRootCatalogFileDialog.SelectedPath;
                RootDirectoryPathTxtBx.Text = _rootDirectoryPath;
            }
        }

        private void StartSearchBtn_Click(object sender, EventArgs e)
        {
            FileSystemTreeView.Nodes.Clear();
            _fileName = FindingFileNameTxtBx.Text;

            if (string.IsNullOrEmpty(_rootDirectoryPath))
            {
                MessageBox.Show("Выберите путь!");
                return;
            }
            if (string.IsNullOrEmpty(_fileName))
            {
                MessageBox.Show("Введите полное название файла!");
                return;
            }

            if (!_fileSearchService.IsSearching)
            {
                _fileSearchService.FileName = _fileName;
                _fileSearchService.RootDirectoryPath = _rootDirectoryPath;
                _fileSearchService.AmountOfThreads = (byte)AmountOfThreadsNumericUpDown.Value;

                Task.Run(() => _fileSearchService.StartSearch());

                StartSearchBtn.Enabled = false;
            }
        }

        private void StopSearchBtn_Click(object sender, EventArgs e)
        {
            if (_fileSearchService.IsSearching)
            {
                _fileSearchService.StopSearch();
                StartSearchBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Обработчик события на завершение поиска
        /// </summary>
        private void _fileSearchService_SearchCompleted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => StartSearchBtn.Enabled = true));
            }
            else
            {
                StartSearchBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Обработчик события, если найден новый путь к файлу
        /// </summary>
        private void FindedNewFile(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (string newPath in e.NewItems)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() => AddPathToTree(newPath)));
                    }
                    else
                    {
                        AddPathToTree(newPath);
                    }
                }
            }
        }

        /// <summary>
        /// Добавление элемента в дерево 
        /// </summary>
        /// <param name="fullPath">Полный путь к файлу</param>
        private void AddPathToTree(string fullPath)
        {
            string[] parts = fullPath.Split(Path.DirectorySeparatorChar, (char)StringSplitOptions.RemoveEmptyEntries);
            TreeNodeCollection currentNodes = FileSystemTreeView.Nodes;
            string currentPath = "";

            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];
                currentPath = (i == 0 && fullPath.Contains(":")) ? part + "\\" : Path.Combine(currentPath, part);

                TreeNode existingNode = currentNodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == part);
                if (existingNode == null)
                {
                    int iconIndex = GetIconIndex(currentPath, FileSystemTreeView.ImageList);
                    existingNode = new TreeNode(part, iconIndex, iconIndex);
                    currentNodes.Add(existingNode);
                }

                currentNodes = existingNode.Nodes;
            }
        }

        /// <summary>
        /// Получение индекса иконки
        /// </summary>
        private static int GetIconIndex(string path, ImageList imageList)
        {
            Icon icon = ShellIconService.GetSmallIcon(path);
            imageList.Images.Add(icon);
            return imageList.Images.Count - 1;
        }
    }
}
