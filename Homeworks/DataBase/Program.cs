using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());

            using (var db = new AppDbContext())
            {
                db.Database.Initialize(force: true);
                Console.WriteLine("База данных успешно создана!");
            }
        }
    }
}
