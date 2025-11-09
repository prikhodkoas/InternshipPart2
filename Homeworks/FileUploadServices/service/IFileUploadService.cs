using FileUploadService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoaderMultiThread.Services
{
    internal interface IFileUploadService
    {
        void UploadFile(FileDto fileDto);
    }
}
