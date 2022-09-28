using EfCoreCodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCodeFirst.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Person> Personen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=EfCoreCodeFirst;Trusted_Connection=true;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCoreCodeFirst;Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}
