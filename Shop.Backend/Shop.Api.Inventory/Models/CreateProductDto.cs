using Mapster;
using Shop.Application.Common.Mappings;
using Shop.Application.Products.Commands.CreateProduct;

namespace Shop.WebApi.Inventory.Models
{
    public class CreateProductDto  : IMapWith<CreateProductCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductDto, CreateProductCommand>()
                .Map(productCommand => productCommand.Name, productDto => productDto.Name)
                .Map(productCommand => productCommand.Description, productDto => productDto.Description)
                .Map(productCommand => productCommand.Price, productDto => productDto.Price);
        }
    }
}
