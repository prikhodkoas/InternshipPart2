using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoaderMultiThread.Model
{
    public class UploadFile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string FilePathFromSave { get; set; }
    }
}
