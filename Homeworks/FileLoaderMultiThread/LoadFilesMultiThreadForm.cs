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
    public partial class LoadFilesMultiThreadForm : Form
    {
        private readonly IFileLoaderService _fileLoaderService; 

        public LoadFilesMultiThreadForm(IFileLoaderService fileLoaderService)
        {
            InitializeComponent();
            _fileLoaderService = fileLoaderService;
        }
    }
}
