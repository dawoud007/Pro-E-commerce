using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Dtos
{
    public class CartDto : BaseDto
    {

        public Guid ProductId { get; set; }

        /* public byte[]? image { get; set; }*/

        public ProductDto? Product { get; set; }
        public int Count { get; set; } = 1;

        public Guid? customerId { get; set; }



        public decimal Price { get; set; }

    }
}
