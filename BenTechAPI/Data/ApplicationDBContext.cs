using BenTechAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<PredefinedPrices> PredefinedPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dates>()
                .HasOne(d => d.predefinedPrices)
                .WithMany()
                .HasForeignKey(d => d.ColorCode)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
