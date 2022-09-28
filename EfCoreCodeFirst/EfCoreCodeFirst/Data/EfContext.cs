using EfCoreCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EfCoreCodeFirst.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        //public DbSet<Person> Personen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=EfCoreCodeFirst;Trusted_Connection=true;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCoreCodeFirst;Trusted_Connection=true;TrustServerCertificate=true");

            optionsBuilder.LogTo(msg => Debug.WriteLine(msg));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abteilung>().ToTable("Departments");
            modelBuilder.Entity<Abteilung>().Property(x => x.Bezeichnung)
                                            .HasColumnName("DepName")
                                            .HasMaxLength(82)
                                            .IsRequired();

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Name).HasMaxLength(99).IsRequired();

            //Table-per-hierachie
            //modelBuilder.Entity<Person>().ToTable("Person");
            //modelBuilder.Entity<Mitarbeiter>().ToTable("Person");
            //modelBuilder.Entity<Kunde>().ToTable("Person");

            //Table-per-type
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");

            //Table-per-concrete-type
            //modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            //modelBuilder.Entity<Kunde>().ToTable("Kunden");
        }
    }
}
