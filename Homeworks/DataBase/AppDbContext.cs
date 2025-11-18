using DataBase.Model;
using System.Data.Entity;
using System.IO;

namespace DataBase
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<DataBase.Model.File> Files { get; set; }

        public DbSet<Chunk> Chunks { get; set; }

        public AppDbContext() : base(@"Server=IM1834\SQLEXPRESS;Database=FileStorageDb;Trusted_Connection=True;TrustServerCertificate=True;") { }

        public AppDbContext(string connectionString)
            : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // File
            modelBuilder.Entity<DataBase.Model.File>()
                .HasKey(f => f.Id);

            // Chunk
            modelBuilder.Entity<Chunk>()
                .HasKey(fd => fd.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
