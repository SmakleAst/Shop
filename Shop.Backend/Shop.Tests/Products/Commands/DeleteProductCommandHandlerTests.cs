using Shop.Application.Common.Exceptions;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Tests.Common;

namespace Shop.Tests.Products.Commands
{
    public class DeleteProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProductCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteProductCommand
            {
                Id = ShopContextFactory.ProductIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Products.SingleOrDefault(product =>
                product.Id == ShopContextFactory.ProductIdForDelete));
        }

        [Fact]
        public async Task DeleteProductCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteProductCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProductCommand
                    {
                        Id = 10,
                    }, CancellationToken.None));
        }
    }
}
