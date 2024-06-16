using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities.Shop;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IShopDbContext _dbContext;

        public DeleteProductCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(product => product.Id == request.Id , cancellationToken)
                ?? throw new NotFoundException(nameof(Product), request.Id);

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
