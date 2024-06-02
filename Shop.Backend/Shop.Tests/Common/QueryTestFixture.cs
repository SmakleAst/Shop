using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Interfaces;
using Shop.Persistence;

namespace Shop.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ShopDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context =  ShopContextFactory.Create();
            var configurationBuilder = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IShopDbContext).Assembly));
            });
            Mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose()
        {
            ShopContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {

    }
}
