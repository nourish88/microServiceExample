
using Microsoft.EntityFrameworkCore;
using productApi.Models;
using System.Diagnostics;

namespace productApi.Context
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string db_setting = String.Format("Host={0}; Port={1}; Username={2}; Password={3}; Database={4};", "localhost", 5432, "root", "root", "Emarket");

            optionsBuilder.UseNpgsql(db_setting);
        }
    }
}
