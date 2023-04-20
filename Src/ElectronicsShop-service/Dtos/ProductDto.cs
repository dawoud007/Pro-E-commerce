using ElectronicsShop_service.Models;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Dtos;
public class ProductDto : BaseDto
{
    public int? code { get; set; }

    public string Name { get; set; } = "";
    public Guid? categoryID { get; set; }

    public string? Brand { get; set; }
    public string? Manufacturer { get; set; }
    public string? color { get; set; }
    public string? description { get; set; }
    public string? image { get; set; }

    public float Rating { get; set; }

    public string? status { get; set; }

}
