using MediatR;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
    }
}
