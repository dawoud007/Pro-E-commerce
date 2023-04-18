using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic;
public class CustomerBusiness : BaseUnitOfWork<Customer>, ICustomerUnitOfWork
{
    public CustomerBusiness(ICustomerRepository customerRepository) : base(customerRepository)
    {
    }
}