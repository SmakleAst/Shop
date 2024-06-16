using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Identity;

namespace Shop.Identity.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
            builder.Property(order => order.Surname).HasMaxLength(50).IsRequired();
            builder.Property(order => order.Name).HasMaxLength(50).IsRequired();
            builder.Property(order => order.Middlename).HasMaxLength(50).IsRequired();
            builder.Property(order => order.Phone).HasMaxLength(11).IsRequired();
            builder.Property(order => order.Email).HasMaxLength(50).IsRequired();
            builder.Property(order => order.Password).IsRequired();
        }
    }
}
