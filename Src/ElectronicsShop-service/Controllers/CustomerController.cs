using AutoMapper;
using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class CustomerController : BaseController<Customer, CustomerDto>
{
    public CustomerController(ICustomerUnitOfWork unitOfWork, IMapper mapper, IValidator<Customer> validator) : base(unitOfWork, mapper, validator)
    {
    }
}
