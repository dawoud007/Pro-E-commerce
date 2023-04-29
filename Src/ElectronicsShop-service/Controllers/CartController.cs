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
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace ElectronicsShop_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CartController : BaseController<Cart, CartControllerVMDto>
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


        /*      public async override Task<IActionResult> Post([FromBody] CartControllerVMDto entityViewModel)
              {
                  Product product = await _productRepository.GetByIdAsync(entityViewModel.ProductId);
                  Customer customer = await _customerRepository.GetByIdAsync(entityViewModel.customerId);
                  var va = new Cart()
                  {
                      Id= Guid.NewGuid(),
                  ProductId = product.Id,
                      Product= product,
                      Price = product.price,
                      CustomerId=customer.Id,
                      Count=1

                  };

                  return Ok(va);
              }*/

        [Authorize]

        [HttpGet]
        public async Task<IActionResult> ShoppingCart()
        {
            var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            Customer customer = (await _customerRepository.Get(c => c.UserName == username, null, "")).FirstOrDefault()!;


            if (customer == null)
            {
                return NotFound();
            }
            var cartVM = new CartVM()
            {
                ListCart = await _cartRepository.Get(u => u.CustomerId == customer.Id, null, "Product"),

            };

            foreach(var item in cartVM.ListCart)
            {
                Product product= (await _productRepository.Get(p=>p.Id== item.ProductId, null,"")).FirstOrDefault()!;
                item.Price = product.price;
                item.Product=product;
               

                
            }
/*
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
*/
 /*           string jsonString = JsonSerializer.Serialize(cartVM);

            return Ok(jsonString);*/

            return Ok(_mapper.Map<CartVMDto>(cartVM).ListCart.Select(c=>c.Product));
        }



        [Authorize]
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

        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<string> Plus([FromQuery] Guid cartId)
        {
            Cart cart = await _cartRepository.GetByIdAsync(cartId);

            if(cart == null)
            {
                
            }
            _cartRepository.IncrementCount(cart, 1);
            await _cartRepository.Save();
            return "item icreased by one";
        }
        [Authorize]
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