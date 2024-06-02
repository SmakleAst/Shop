using AutoMapper;
using Shop.Application.Products.Queries.GetProductList;
using Shop.Persistence;
using Shop.Tests.Common;
using Shouldly;

namespace Shop.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductListQueryHandlerTests
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetProductListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetProductListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetProductListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetProductListQuery
                {

                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ProductListVm>();
            result.Products.Count.ShouldBe(4);
        }
    }
}
