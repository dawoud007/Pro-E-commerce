using ElectronicsShop_service;
using ElectronicsShop_service.BusinessLogic;
using ElectronicsShop_service.Helpers;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Repositories;
using ElectronicsShop_service.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//give the add package code to add the Microsoft.EntityFrameworkCore.Design package


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connnectionString
    , ServerVersion.AutoDetect(connnectionString)));

//add validation from current assembly
builder.Services.AddValidatorsFromAssembly(typeof(CustomerValidations).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerUnitOfWork, CustomerBusiness>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductUnitOfWork, ProductBusiness>();

builder.Services.Configure<RabbitMqConnectionHelper>(builder.Configuration.GetSection("rabbitmq"));






var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
