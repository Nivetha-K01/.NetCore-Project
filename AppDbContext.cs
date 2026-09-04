using Microsoft.EntityFrameworkCore;

using PJAverageRate.Models;

namespace PJAverageRate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)

           : base(options) { }

        public DbSet<PJAverageRateViewModel> PJAverageRateVal { get; set; }

        public DbSet<GoldRateModel> GoldRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoldRateModel>()
                .HasNoKey();
            modelBuilder.Entity<PJAverageRateViewModel>()
                .HasNoKey();

        }


    }


}
