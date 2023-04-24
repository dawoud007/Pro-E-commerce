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

        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        public CartController(ICartUnitOfWork unitOfWork,
            IProductRepository productRepository
            , ICartRepository cartRepository
            
            
            
            , IMapper mapper, IValidator<Cart> validator) : base(unitOfWork, mapper, validator)
        {

            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            // Get the product by its ID
            var product = await _productRepository.GetByIdAsync(productId);

            // If the product doesn't exist, return a 404 Not Found response
            if (product == null)
            {
                return NotFound();
            }

            // Add the specified product to the user's cart with the given quantity
    /*        await _cartRepository.AddAsync(product);*/

            // Return a success response with the updated cart data
           /* var cart = await _cartRepository.GetCart();*/
            return Ok();
        }
/*
        [HttpDelete("remove")]
        public IActionResult RemoveFromCart(int productId)
        {
            // Remove the specified product from the user's cart
            _cartService.RemoveFromCart(productId);

            // Return a success response with the updated cart data
            var cart = _cartService.GetCart();
            return Ok(cart);
        }

        [HttpDelete("remove-all")]
        public IActionResult RemoveAllFromCart()
        {
            // Remove all products from the user's cart
            _cartService.RemoveAllFromCart();

            // Return a success response with the updated cart data
            var cart = _cartService.GetCart();
            return Ok(cart);
        }

        [HttpPut("reduce")]
        public IActionResult ReduceProductAtCart(int productId, int quantity)
        {
            // Reduce the quantity of the specified product in the user's cart by a specified amount
            _cartService.ReduceProductAtCart(productId, quantity);

            // Return a success response with the updated cart data
            var cart = _cartService.GetCart();
            return Ok(cart);
        }

        [HttpPut("increment")]
        public IActionResult IncrementProductAtCart(int productId, int quantity)
        {
            // Increase the quantity of the specified product in the user's cart by a specified amount
            _cartService.IncrementProductAtCart(productId, quantity);

            // Return a success response with the updated cart data
            var cart = _cartService.GetCart();
            return Ok(cart);
        }

        [HttpGet("products/{categoryId}")]
        public IActionResult FetchProductsByCategory(int categoryId)
        {
            // Retrieve a list of products in a specified category
            var products = _productService.GetProductsByCategory(categoryId);

            // If no products are found, return a 404 Not Found response
            if (!products.Any())
            {
                return NotFound();
            }

            // Return a success response with the list of products
            return Ok(products);
        }

        [HttpGet("isAdmin")]
        public IActionResult IsAdmin()
        {
            // Check if the current user is an admin
            bool isAdmin = // logic to determine if user is an admin

        // Return a success response with a boolean indicating whether the user is an admin
        return Ok(isAdmin);
        }*/
    }
}