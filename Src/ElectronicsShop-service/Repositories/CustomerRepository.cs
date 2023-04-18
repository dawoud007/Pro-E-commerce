using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Repositories;
public class CustomerRepository : BaseRepo<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }
}