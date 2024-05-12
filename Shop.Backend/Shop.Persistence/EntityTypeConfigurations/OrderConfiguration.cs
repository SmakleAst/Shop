using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;

namespace Shop.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
            builder.Property(order => order.CustomerName).HasMaxLength(50);
            builder.Property(order => order.CustomerEmail).HasMaxLength(50);
            builder.Property(order => order.TotalPrice).HasPrecision(16, 2);

            builder.HasMany(order => order.OrderItems)
                .WithOne(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);
        }
    }
}
