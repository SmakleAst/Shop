using Mapster;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities.Shop;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDetailsVm>()
                .Map(productVm => productVm.Name, product => product.Name)
                .Map(productVm => productVm.Description, product => product.Description)
                .Map(productVm => productVm.Price, product => product.Price)
                .Map(productVm => productVm.Quantity, product => product.Quantity)
                .Map(productVm => productVm.CreationDate, product => product.CreationDate)
                .Map(productVm => productVm.EditDate, product => product.EditDate);
        }
    }
}
