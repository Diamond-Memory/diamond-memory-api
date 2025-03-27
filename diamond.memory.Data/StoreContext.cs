using Microsoft.EntityFrameworkCore;
using diamond.memory.Domain.Orders;
using diamond.memory.Domain.Catalog;
using diamond.memory.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace diamond.memory.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options){ }

        public DbSet<Item> Items { get; set; } 
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            {
              base.OnModelCreating(builder);
              DbInitializer.Initialize(builder);
            }
    }
}