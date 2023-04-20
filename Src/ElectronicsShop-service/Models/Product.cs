using CommonGenericClasses;
using System.Drawing;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop_service.Models;
public class Product : BaseEntity
{
    [Required]
    public int? code { get; set; }
    [Required]

    public string Name { get; set; } = "";
    [Required]

    public Category? category { get; set; }
    [Required]

    public string? Brand { get; set; }
    [Required]
    public string? Manufacturer { get; set; }
    [Required]
    public string? color { get; set; }
    [Required]
    public string? description { get; set; }
    [Required]
    public string? image { get; set; }

    [Required]
    public float Rating { get; set; }

    [Required]
    public string? status { get; set; }



}