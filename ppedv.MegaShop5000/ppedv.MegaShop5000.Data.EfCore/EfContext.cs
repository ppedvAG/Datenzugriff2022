using Microsoft.EntityFrameworkCore;
using ppedv.MegaShop5000.Model;

namespace ppedv.MegaShop5000.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<BestellPosition> BestellPositionen => Set<BestellPosition>();
        public DbSet<Bestellung> Bestellungen => Set<Bestellung>();
        public DbSet<Kategorie> Kategorien => Set<Kategorie>();
        public DbSet<Kunde> Kunde => Set<Kunde>();
        public DbSet<Preis> Preise => Set<Preis>();
        public DbSet<PreisListe> Preislisten => Set<PreisListe>();
        public DbSet<Produkt> Produkte => Set<Produkt>();

        private readonly string _conString;
        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=MegaShop5000_dev;Trusted_Connection=true;TrustServerCertificate=true")
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(_conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Bestellung>().HasOne(x => x.Lieferadresse).WithMany(x => x.BestellungLieferung);
            //modelBuilder.Entity<Bestellung>().HasOne(x => x.RechnungsAdresse).WithMany(x => x.BestellungRechnung);
            modelBuilder.Entity<Kunde>().HasMany(x => x.BestellungLieferung).WithOne(x => x.Lieferadresse);
            modelBuilder.Entity<Kunde>().HasMany(x => x.BestellungRechnung).WithOne(x => x.RechnungsAdresse);
        }

    }
}