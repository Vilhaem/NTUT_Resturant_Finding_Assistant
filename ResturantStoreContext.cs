using Microsoft.EntityFrameworkCore;

namespace NTUT_Resturant_Finding_Assistant.Model;

public class ResturantStoreContext : DbContext
{
    public ResturantStoreContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Resturant> Resturants { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturant>().ToTable("Resturant");
    }
}