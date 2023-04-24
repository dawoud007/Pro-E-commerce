using CommonGenericClasses;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Cart : BaseEntity
{
    public Cart()
    {
        Products = new HashSet<Product>();
    }
    public Product? Product { get; set; }
    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public int Count { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public double Price { get; set; }
    public ICollection<Product> Products { get; set; }


}