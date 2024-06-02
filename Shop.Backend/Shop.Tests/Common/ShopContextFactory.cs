using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Persistence;

namespace Shop.Tests.Common
{
    public class ShopContextFactory
    {
        public static int ProductIdForDelete = 1;
        public static int ProductIdForUpdate = 1;

        public static ShopDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ShopDbContext(options);
            context.Database.EnsureCreated();
            context.Products.AddRange(
                new Product
                {
                    Name = "Product1",
                    Description = "Description1",
                    Price = 1000.00m,
                    Quantity = 100,
                    CreationDate = DateTime.Today,
                },
                new Product
                {
                    Name = "Product2",
                    Description = "Description2",
                    Price = 2000.00m,
                    Quantity = 200,
                    CreationDate = DateTime.Today,
                },
                new Product
                {
                    Name = "Product3",
                    Description = "Description3",
                    Price = 3000.00m,
                    Quantity = 300,
                    CreationDate = DateTime.Today,
                },
                new Product
                {
                    Name = "Product4",
                    Description = "Description4",
                    Price = 4000.00m,
                    Quantity = 400,
                    CreationDate = DateTime.Today,
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(ShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
