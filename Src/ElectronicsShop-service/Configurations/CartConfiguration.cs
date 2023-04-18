using CommonGenericClasses;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicsShop_service.Configurations;
public class CartConfiguration : BaseConfiguration<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);
    }
}