using Mapster;
using Shop.Application.Common.Mappings;
using Shop.Application.Products.Commands.UpdateProduct;

namespace Shop.WebApi.Inventory.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateProductDto, UpdateProductCommand>()
                .Map(productCommand => productCommand.Id, productDto => productDto.Id)
                .Map(productCommand => productCommand.Name, productDto => productDto.Name)
                .Map(productCommand => productCommand.Description, productDto => productDto.Description)
                .Map(productCommand => productCommand.Price, productDto => productDto.Price);
        }
    }
}
