using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Models.VM;

namespace ElectronicsShop_service.MapperProfiles;
public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>()
        .ReverseMap();
    }
}