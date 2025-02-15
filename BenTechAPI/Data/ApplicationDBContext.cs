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
                .HasOne(d => d.PredefinedPrices)  // Um Date pertence a um PredefinedPrice
                .WithMany(p => p.Dates)          // Um PredefinedPrice pode ter vários Dates
                .HasForeignKey(d => d.ColorCode) // FK em Dates referenciando PredefinedPrices
                .OnDelete(DeleteBehavior.Cascade); // Se PredefinedPrice for deletado, os Dates são removidos
        }
    }
}
