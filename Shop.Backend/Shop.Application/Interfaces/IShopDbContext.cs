using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Shop;

namespace Shop.Application.Interfaces
{
    public interface IShopDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
