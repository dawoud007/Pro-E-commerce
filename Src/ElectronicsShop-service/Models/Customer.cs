using CommonGenericClasses;

namespace ElectronicsShop_service.Models;
public class Customer : BaseEntity
{
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }

    public Cart Cart { get; set; }
    public ICollection<Product> Products { get; set;}
}