using ElectronicsShop_service.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsShop_service;
public class ApplicationDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }

    public DbSet<Customer>? Customers { get; set; }

    public DbSet<Cart>? Carts { get; set; }
    public DbSet<Category>? Categories { get; set; }



    private readonly IConfiguration configuration;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        this.configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = Guid.NewGuid(), Name = "electronics" },
            new { Id = Guid.NewGuid(), Name = "jewelery" },
            new { Id = Guid.NewGuid(), Name = "men's clothing" },
            new { Id = Guid.NewGuid(), Name = "women's clothing" }
        );
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}