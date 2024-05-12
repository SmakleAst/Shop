﻿using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(productDto => productDto.ProductId,
                    opt => opt.MapFrom(product => product.ProductId))
                .ForMember(productDto => productDto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(productDto => productDto.Description,
                    opt => opt.MapFrom(product => product.Description))
                .ForMember(productDto => productDto.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(productDto => productDto.Quantity,
                    opt => opt.MapFrom(product => product.Quantity));
        }
    }
}