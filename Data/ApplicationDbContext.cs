using Microsoft.EntityFrameworkCore;
using HotelAPI.Models;
namespace HotelAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tell EF the table name is Hotels
            modelBuilder.Entity<Hotel>().ToTable("Hotels");
        }
    }
}
