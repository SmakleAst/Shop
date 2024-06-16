using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Shop;

namespace Shop.Persistence.EntityTypeConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);
            builder.HasIndex(orderItem => orderItem.Id).IsUnique();
            builder.Property(orderItem => orderItem.Id).ValueGeneratedOnAdd();
            builder.Property(orderItem => orderItem.Price).HasPrecision(16, 2);
            builder.Property(orderItem => orderItem.TotalPrice).HasPrecision(16, 2);

            builder.HasOne(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(order => order.OrderId);

            builder.HasOne(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}
