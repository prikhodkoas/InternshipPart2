using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _appDbContext;
        public FileRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public void Add (DataBase.Model.File file)
        {
            _appDbContext.Files.Add(file);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
