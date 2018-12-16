using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DocumentsApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
            modelBuilder.ApplyConfiguration(new DocumentCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        }
    }


}