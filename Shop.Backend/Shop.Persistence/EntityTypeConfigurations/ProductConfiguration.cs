using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.HasIndex(product => product.Id).IsUnique();
            builder.Property(product => product.Id).ValueGeneratedOnAdd();
            builder.Property(product => product.Name).HasMaxLength(50);
            builder.Property(product => product.Description).HasMaxLength(250);
            builder.Property(product => product.Price).HasPrecision(16, 2);
        }
    }
}
