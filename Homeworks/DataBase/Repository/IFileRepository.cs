using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public interface IFileRepository
    {
        void Add(DataBase.Model.File file);
        void Save();
    }
}
