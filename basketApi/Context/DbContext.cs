using basketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace basketApi.Context
{
	public class DbContext:Microsoft.EntityFrameworkCore.DbContext
	{
     public DbContext() :base(){ }
        public DbContext(DbContextOptions<basketApi.Context.DbContext> options) : base(options) { }
        public DbSet<Basket> Baskets { get; set; }
    }
}
