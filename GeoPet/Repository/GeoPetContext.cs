using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

namespace GeoPet.Repository
{


    public class GeoPetContext : DbContext, IGeoPetContext
    {
        public GeoPetContext(DbContextOptions<GeoPetContext> options) : base(options)
        {
        }
        public GeoPetContext() { }

        public DbSet<Pets> Pets { get; set; }
        public DbSet<LocationHistory> LocationHistory { get; set; }
        public DbSet<CareGivers> CareGivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=127.0.0.1;Database=Geopet;User=SA;Password=Password123";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pets>().ToTable("Pets");
            modelBuilder.Entity<LocationHistory>().ToTable("LocationHistory");
            modelBuilder.Entity<CareGivers>().ToTable("CareGivers");
        }
    }
}