using EfCoreMigration.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCoreMigration.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Pizza;Trusted_Connection=true");
        }
    }
}
