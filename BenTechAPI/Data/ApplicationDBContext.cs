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
    }
}
