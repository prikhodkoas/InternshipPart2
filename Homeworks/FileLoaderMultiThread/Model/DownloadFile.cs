using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoaderMultiThread.Model
{
    public class DownloadFile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Url { get; set; }
        public string FilePathToSave { get; set; }
        public long TotalSize { get; set; }
        public long DownloadedSize { get; set; }
        public bool IsLoaded { get; set; }
    }
}
