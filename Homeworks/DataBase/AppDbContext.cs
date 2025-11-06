using System.Data.Entity;
using System.IO;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }

        public AppDbContext() : base(@"Server=IM1834\SQLEXPRESS;Database=FileStorageDb;Trusted_Connection=True;TrustServerCertificate=True;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .HasKey(f => f.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
