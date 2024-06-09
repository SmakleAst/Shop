using Mapster;
using System.Reflection;

namespace Shop.Application.Common.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { TypeAdapterConfig.GlobalSettings });
            }
        }
    }
}
