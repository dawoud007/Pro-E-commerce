using AutoMapper;
using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Models.VM;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ElectronicsShop_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CartController : BaseController<Cart, CartDto>
    {

        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        public CartController(ICartUnitOfWork unitOfWork,
            IProductRepository productRepository
            , ICartRepository cartRepository
            , ICustomerRepository customerRepository



            , IMapper mapper, IValidator<Cart> validator) : base(unitOfWork, mapper, validator)
        {

            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ShoppingCart()
        {
            var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            Customer customer = (await _customerRepository.Get(c => c.UserName == username, null, "")).FirstOrDefault()!;

            var cartVM = new CartVM()
            {
                ListCart = await _cartRepository.Get(u => u.CustomerId == customer.Id, null, "Product"),

            };

            return Ok(_mapper.Map<CartVMDto>(cartVM));
        }


        [HttpPost]
        public async Task<string> RemoveFromCart([FromQuery] Guid? productId)
        {
            if (productId! == null)
            {
                return "enter valid product ";
            }

            await _cartRepository.RemoveByIdAsync(productId);
            await _cartRepository.Save();
            return "product deleted successfully";

        }


        [HttpPost]
        public async Task<string> removeAllfromCart()
        {

            var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            Customer customer = (await _customerRepository.Get(u => u.UserName == username)).FirstOrDefault()!;
            /*var cart = (await _cartRepository.Get(c=>c.CustomerId==customer.Id,null,"")).FirstOrDefault()!;*/

            await _cartRepository.RemoveAsync(c => c.CustomerId == customer.Id);

            await _cartRepository.Save();
            return $"cart deleted for {customer.Name}";


        }

        [HttpPost]
        public async Task<string> Plus([FromQuery] Guid cartId)
        {
            Cart cart = await _cartRepository.GetByIdAsync(cartId);
            _cartRepository.IncrementCount(cart, 1);
            await _cartRepository.Save();
            return "item icreased by one";
        }
        [HttpPost]
        public async Task<string> Minus(int cartId)
        {
            Cart cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart.Count <= 1)
            {
                await _cartRepository.RemoveByIdAsync(cart.Id);
            }
            else
            {
                _cartRepository.DecrementCount(cart, 1);
            }
            await _cartRepository.Save();
            return "item decreased by one";

        }

    }
}