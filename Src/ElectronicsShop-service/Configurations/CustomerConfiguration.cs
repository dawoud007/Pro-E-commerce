using CommonGenericClasses;
using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicsShop_service.Configurations;
public class CustomerConfiguration : BaseConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        base.Configure(builder);

        builder
      .HasOne(c => c.Cart)
      .WithOne(c => c.Customer)
      .HasForeignKey<Cart>(c => c.CustomerId);








        builder.HasMany(c => c.Products)
       .WithMany(p => p.Customers)
       .UsingEntity<CustomerProduct>(
           j => j
               .HasOne(c => c.Product)
               .WithMany()
               .HasForeignKey(c => c.ProductId),
           j => j
               .HasOne(c => c.Customer)
               .WithMany()
               .HasForeignKey(c => c.CustomerId),
           j =>
           {
               j.HasKey(c => new {
                   c.CustomerId,
                   c.ProductId
               });
             
           });





    }



}