using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain;

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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(productVm => productVm.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productVm => productVm.Description,
                    opt => opt.MapFrom(product => product.Description))
                .ForMember(productVm => productVm.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(productVm => productVm.Quantity,
                    opt => opt.MapFrom(product => product.Quantity))
                .ForMember(productVm => productVm.CreationDate,
                    opt => opt.MapFrom(product => product.CreationDate))
                .ForMember(productVm => productVm.EditDate,
                    opt => opt.MapFrom(product => product.EditDate));
        }
    }
}
