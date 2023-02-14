namespace GeoPet.Repository;
using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

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
        optionsBuilder.UseSqlServer(
        @"server=127.0.0.1;
        database=geo_pet;
        user=laika;
        password=1234;
        trusted_connection=true;"
        );
    }
}
