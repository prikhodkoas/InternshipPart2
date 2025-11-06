using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    internal class FileRepository : IFileRepository
    {
        private readonly AppDbContext _appDbContext;
        public FileRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public void Add (File file)
        {
            _appDbContext.Files.Add(file);
            _appDbContext.SaveChanges();
        }
    }
}
