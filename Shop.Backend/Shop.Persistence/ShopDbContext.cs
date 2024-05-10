using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Persistence
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public DbSet<Product>  Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
