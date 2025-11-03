using FileLoaderMultiThread.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoaderMultiThread
{
    public static class FileLoaderServiceFactory
    {
        public static IFileLoaderService Create() => new FileLoaderService();
    }
}
