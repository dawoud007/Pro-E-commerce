using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;

namespace ElectronicsShop_service.Repositories;
public class CartRepository : BaseRepo<Cart>, ICartRepository
{
    public CartRepository(ApplicationDbContext context) : base(context)
    {


    }


    public int DecrementCount(Cart shoppingCart, int count)
    {
        shoppingCart.Count -= count;
        return shoppingCart.Count;
    }

    public int IncrementCount(Cart shoppingCart, int count)
    {
        shoppingCart.Count += count;
        return shoppingCart.Count;
    }
}