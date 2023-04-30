using CommonGenericClasses;
using System.Drawing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsShop_service.Models;
public class Product : BaseEntity
{
    public Product()
    {
        Customers = new HashSet<Customer>();
    }
    public int? code { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid? categoryID { get; set; }

    public Category? category { get; set; }

    public string Brand { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string color { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public byte[]? image { get; set; }

    public float Rating { get; set; }

    public string status { get; set; } = string.Empty;

    public Guid? CartId { get; set; }

    public float price { get; set; }


    public Cart? Cart { get; set; }

    public int? quantity { get; set; }
    public ICollection<Customer> Customers { get; set; }



}