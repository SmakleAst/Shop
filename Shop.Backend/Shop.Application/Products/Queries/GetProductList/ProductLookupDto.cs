using Mapster;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities.Shop;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductLookupDto>()
                .Map(productDto => productDto.Id, product => product.Id)
                .Map(productDto => productDto.Name, product => product.Name)
                .Map(productDto => productDto.Description, product => product.Description)
                .Map(productDto => productDto.Price, product => product.Price)
                .Map(productDto => productDto.Quantity, product => product.Quantity);
        }
    }
}
