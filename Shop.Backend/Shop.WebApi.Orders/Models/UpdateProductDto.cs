using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Products.Commands.UpdateProduct;

namespace Shop.WebApi.Orders.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(productCommand => productCommand.Id,
                    opt => opt.MapFrom(productDto => productDto.Id))
                .ForMember(productCommand => productCommand.Name,
                    opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productCommand => productCommand.Description,
                    opt => opt.MapFrom(productDto => productDto.Description))
                .ForMember(productCommand => productCommand.Price,
                    opt => opt.MapFrom(productDto => productDto.Price));
        }
    }
}
