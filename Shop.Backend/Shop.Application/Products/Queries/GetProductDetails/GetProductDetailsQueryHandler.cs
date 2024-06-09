using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IShopDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductDetailsVm>(product);
        }
    }
}
