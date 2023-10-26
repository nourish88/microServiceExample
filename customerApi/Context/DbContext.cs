using Microsoft.EntityFrameworkCore;

namespace customerApi.Context
{
	public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext() : base() { }
        public DbContext(DbContextOptions<customerApi.Context.DbContext> options) : base(options) { }
        public DbSet<customerApi.Models.Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=eMarket");
        }

    }
}
