using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    internal interface IFileRepository
    {
        void Add(File file);
        void Save();
    }
}
