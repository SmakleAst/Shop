using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Tests.Common;

namespace Shop.Tests.Products.Commands
{
    public class UpdateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProductCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);
            var updatedName = "updated name";
            var updatedDescription = "updated description";
            var updatedPrice = 101.00m;
            var updatedQuantity = 11;

            // Act
            await handler.Handle(new UpdateProductCommand
            {
                Id = ShopContextFactory.ProductIdForUpdate,
                Name = updatedName,
                Description = updatedDescription,
                Price = updatedPrice,
                Quantity = updatedQuantity,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(product =>
                product.Id == ShopContextFactory.ProductIdForUpdate && product.Name.Equals(updatedName) &&
                product.Description.Equals(updatedDescription) && product.Price == updatedPrice && product.Quantity == updatedQuantity));
        }

        [Fact]
        public async Task UpdateProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProductCommand
                    {
                        Id = 10,
                    }, CancellationToken.None));
        }
    }
}
