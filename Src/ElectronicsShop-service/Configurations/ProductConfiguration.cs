using CommonGenericClasses;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicsShop_service.Configurations;
public class ProductConfiguration : BaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
      
    }
}