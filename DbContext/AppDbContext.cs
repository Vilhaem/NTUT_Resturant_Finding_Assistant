using Microsoft.EntityFrameworkCore;

namespace NTUT_Resturant_Finding_Assistant
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Resturant.db");
        }
        public DbSet<Resturant> Resturants { get; set; }
    }
}