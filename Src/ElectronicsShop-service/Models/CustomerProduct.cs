namespace ElectronicsShop_service.Models;
using CommonGenericClasses;

public class CustomerProduct : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}
