using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class CartMappings : Profile
{
    public CartMappings()
    {
        CreateMap<Cart, CartDto>();
        CreateMap<CartDto, Cart>();
    }
}