using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}