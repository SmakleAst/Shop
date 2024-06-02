using Microsoft.EntityFrameworkCore;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Tests.Common;

namespace Shop.Tests.Products.Commands
{
    public class CreateProductCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateProductCommandHandler(Context);
            var productName = "product name";
            var productDescription = "productDescription";
            var productPrice = 100.00m;

            // Act
            var productId = await handler.Handle(
                new CreateProductCommand
                {
                    Name = productName,
                    Description = productDescription,
                    Price = productPrice,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Products.SingleOrDefaultAsync(product =>
                    product.Id == productId && product.Name.Equals(productName) &&
                    product.Description.Equals(productDescription) && product.Price == productPrice));
        }
    }
}
