namespace ElectronicsShop_service.Configurations;
using CommonGenericClasses;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : BaseConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.HasMany(c => c.Products) // Category has many Products
            .WithOne(p => p.category) // Product has one Category
            // Product's foreign key is CategoryId
            .OnDelete(DeleteBehavior.Cascade);
    }
}