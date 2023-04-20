using ElectronicsShop_service.Models;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Dtos;
public class ProductDto : BaseDto
{
    [Required]
    public int? code { get; set; }
    [Required]

    public string Name { get; set; } = "";
  
    [Required]

    public string? Brand { get; set; }
}