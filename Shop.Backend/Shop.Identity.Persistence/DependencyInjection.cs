using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;

namespace Shop.Identity.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ShopUsers");
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<IdentityDbContext>());

            return services;
        }
    }
}
