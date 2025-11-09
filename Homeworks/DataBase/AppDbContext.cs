using System.Data.Entity;
using System.IO;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<DataBase.Model.File> Files { get; set; }

        public AppDbContext() : base("name=HomeDbConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBase.Model.File>()
                .HasKey(f => f.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
