using CommonGenericClasses;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Cart : BaseEntity
{
    public int ProductId { get; set; }

    [ValidateNever]
    public Product Product { get; set; }
    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public int Count { get; set; }

    public string? customerId { get; set; }
    [ForeignKey("ApplicationUserId")]
    [ValidateNever]
    public Customer customer { get; set; }

    [NotMapped]
    public double Price { get; set; }
}