namespace GeoPet.Repository;
using Microsoft.EntityFrameworkCore;
using GeoPet.Models;

    public interface IGeoPetContext
    {
       public DbSet<Pets> Pets { get; set; }
        public DbSet<LocationHistory> LocationHistory { get; set; }
        public DbSet<CareGivers> CareGivers { get; set; }
        public int SaveChanges();
    }
