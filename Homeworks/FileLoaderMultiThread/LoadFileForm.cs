using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoaderMultiThread
{
    public partial class LoadFileForm : Form
    {
        public LoadFileForm(string filename)
        {
            this.fileIsLoadingNameLbl.Text += $"{filename}";
            InitializeComponent();
            
        }

    }
}
