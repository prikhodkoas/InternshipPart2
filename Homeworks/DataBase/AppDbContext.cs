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

        public AppDbContext() : base("name=HomeDbConnection") { }

        public AppDbContext(string connectionString)
            : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBase.Model.File>()
                .HasKey(f => f.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
