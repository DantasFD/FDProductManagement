using AutoMapper;
using FDProductManagement.Domain.Entities;
using FDProductManagement.Service.ViewModels;

namespace FDProductManagement.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}
