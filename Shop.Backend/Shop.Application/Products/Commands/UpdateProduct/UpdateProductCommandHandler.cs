using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IShopDbContext _dbContext;

        public UpdateProductCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FindAsync(new object[] { request.ProductId }, cancellationToken)
                ?? throw new NotFoundException(nameof(Product), request.ProductId);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
