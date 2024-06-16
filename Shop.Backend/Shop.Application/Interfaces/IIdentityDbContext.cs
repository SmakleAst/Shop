using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Identity;

namespace Shop.Application.Interfaces
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
