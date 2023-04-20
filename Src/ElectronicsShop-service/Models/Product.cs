using CommonGenericClasses;
using System.Drawing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsShop_service.Models;
public class Product : BaseEntity
{
    public int? code { get; set; }

    public string Name { get; set; } = "";

    public Guid? categoryID { get; set; }
 
    public Category? category { get; set; }

    public string? Brand { get; set; }
    public string? Manufacturer { get; set; }
    public string? color { get; set; }
    public string? description { get; set; }
    public string? image { get; set; }

    public float Rating { get; set; }

    public string? status { get; set; }

    public Guid? CartId { get; set; }


    public Cart? Cart { get; set; }

    public ICollection<Customer> Customers { get; set;}



}