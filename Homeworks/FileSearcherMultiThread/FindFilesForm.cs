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

namespace FileSearcherMultiThread
{
    public partial class FindFilesForm : Form
    {
        private readonly IFileSearchService _fileSearchService;

        private string _rootDirectoryPath;

        private string _fileName;

        public FindFilesForm(IFileSearchService fileSearchService)
        {
            _fileSearchService = fileSearchService;
            InitializeComponent();
            _fileSearchService.FindedPathes.CollectionChanged += FindedNewFile;
            _fileSearchService.SearchCompleted += _fileSearchService_SearchCompleted;
        }

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
            if(string.IsNullOrEmpty(_rootDirectoryPath))
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

        private void AddPathToTree(string fullPath)
        {
            string[] parts = fullPath.Split(Path.DirectorySeparatorChar);
            TreeNodeCollection currentNodes = FileSystemTreeView.Nodes;

            foreach (string part in parts)
            {
                TreeNode existingNode = currentNodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == part);
                if (existingNode == null)
                {
                    existingNode = new TreeNode(part);
                    currentNodes.Add(existingNode);
                }
                currentNodes = existingNode.Nodes;
            }
        }

        private void StopSearchBtn_Click(object sender, EventArgs e)
        {
            _fileSearchService.StopSearch();
            StartSearchBtn.Enabled = false;
        }
    }
}
