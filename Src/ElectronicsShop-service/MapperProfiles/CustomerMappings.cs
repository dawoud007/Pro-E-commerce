using AutoMapper;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.MapperProfiles;
public class MapperProfiles : Profile
{
    public MapperProfiles()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}