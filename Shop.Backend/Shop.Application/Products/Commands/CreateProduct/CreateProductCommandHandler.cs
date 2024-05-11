using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IShopDbContext _dbContext;

        public CreateProductCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = 0,
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.ProductId;
        }
    }
}
