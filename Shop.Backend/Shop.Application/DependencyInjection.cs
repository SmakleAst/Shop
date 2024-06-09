using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Behaviors;
using Shop.Application.Common.Mappings;
using System.Reflection;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssemblies(new[]
            {
                Assembly.GetExecutingAssembly(),
            });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            MapsterConfig.RegisterMappings(Assembly.GetExecutingAssembly());
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
