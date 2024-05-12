using MediatR;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public int Id { get; set; }
    }
}
