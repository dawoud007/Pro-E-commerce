using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic
{
    public class CartBusiness : BaseUnitOfWork<Cart>, ICartUnitOfWork
    {
        public CartBusiness(ICartRepository cartRepository) : base(cartRepository)
        {
        }
    }
}