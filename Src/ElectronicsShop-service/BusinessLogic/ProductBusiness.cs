using CommonGenericClasses;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using ElectronicsShop_service.Repositories;

namespace ElectronicsShop_service.BusinessLogic;
public class ProductBusiness : BaseUnitOfWork<Product>, IProductUnitOfWork
{
    public ProductBusiness(IProductRepository productRepository) : base(productRepository)
    {
    }
}