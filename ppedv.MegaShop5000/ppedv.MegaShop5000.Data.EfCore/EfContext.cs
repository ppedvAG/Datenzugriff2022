using Microsoft.EntityFrameworkCore;
using ppedv.MegaShop5000.Model;
using System.Reflection.Metadata;

namespace ppedv.MegaShop5000.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<BestellPosition> BestellPositionen { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Preis> Preise { get; set; }
        public DbSet<PreisListe> Preislisten { get; set; }
        public DbSet<Produkt> Produkte { get; set; }

        private string _conString;
        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=MegaShop5000_dev;Trusted_Connection=true;TrustServerCertificate=true")
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(_conString);
        }

    }
}