using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IShopDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.Products
                .ProjectToType<ProductLookupDto>()
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = products };
        }
    }
}
