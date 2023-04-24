namespace ElectronicsShop_service.Interfaces;
using CommonGenericClasses;
using ElectronicsShop_service.Models;
using System.Threading.Tasks;

public interface ICartRepository : IBaseRepo<Cart>
{
    int IncrementCount(Cart shoppingCart, int count);

    int DecrementCount(Cart ShoppingCart, int count);
}