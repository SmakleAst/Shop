using AutoMapper;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Persistence;
using Shop.Tests.Common;
using Shouldly;
using System.Diagnostics;

namespace Shop.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetProductDetailsQueryHandlerTests
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetProductDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetProductDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetProductDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetProductDetailsQuery
                {
                    Id = Context.Products.First().Id,
                }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ProductDetailsVm>();
            result.Name.ShouldBe("Product1");
            result.Description.ShouldBe("Description1");
            result.Price.ShouldBe(1000.00m);
            result.Quantity.ShouldBe(100);
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
