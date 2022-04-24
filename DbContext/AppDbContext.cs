using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace NTUT_Resturant_Finding_Assistant
{
    public class AppDbContext:DbContext
    {
        public DbSet<Resturant> Resturants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Resturant.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>().ToTable("Resturants");
        }
    }

    
}