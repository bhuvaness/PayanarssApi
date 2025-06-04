using AutoMapper;
using ProductManagementModule.DTOs;
using ProductManagementModule.Models;

namespace ProductManagementModule.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductUnit, ProductUnitDto>().ReverseMap();
        }
    }
}
