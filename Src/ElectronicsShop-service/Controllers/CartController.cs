using AutoMapper;
using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
namespace ElectronicsShop_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CartController : BaseController<Cart, CartDto>
    {
        public CartController(ICartUnitOfWork unitOfWork, IMapper mapper, IValidator<Cart> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }

}
