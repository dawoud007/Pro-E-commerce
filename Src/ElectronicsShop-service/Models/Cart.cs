using CommonGenericClasses;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Cart : BaseEntity
{
    public Cart()
    {

    }

    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public Guid? ProductId { get; set; }



    [ValidateNever]
    public Product? Product { get; set; }
    public int Count { get; set; } = 1;
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public decimal Price { get; set; }



}