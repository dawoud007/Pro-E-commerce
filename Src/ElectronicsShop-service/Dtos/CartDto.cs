using ElectronicsShop_service.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Dtos
{
    public class CartDto : BaseDto
    {

        public int ProductId { get; set; }

     
        public int Count { get; set; }

        public Guid? customerId { get; set; }
       

        
        public double Price { get; set; }

    }
}
