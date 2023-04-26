using CommonGenericClasses;

namespace ElectronicsShop_service.Models;
public class Customer : BaseEntity
{
    public Customer()
    {
        Products = new HashSet<Product>();
    }
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public Cart? Cart { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<Cart> Carts { get; set; }
}