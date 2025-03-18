using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options) : base(options) { }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<MoneyEntity>();
            modelBuilder.Entity<ClientEntity>().ToTable("Client");
            modelBuilder.Entity<OrderEntity>().ToTable("Order");
            modelBuilder.Entity<ProductEntity>().ToTable("Product");

            modelBuilder.ApplyConfiguration(new ProductSeed());
            modelBuilder.ApplyConfiguration(new OrderSeed());
            modelBuilder.ApplyConfiguration(new ClientSeed());

        }

        


    }
}
