using Authentication.Infrastructure.Models;
using BusinessLogic.Entry.Options;
using ElectronicsShop_service;
using ElectronicsShop_service.BusinessLogic;
using ElectronicsShop_service.Helpers;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Repositories;
using ElectronicsShop_service.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//give the add package code to add the Microsoft.EntityFrameworkCore.Design package


// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();

var connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connnectionString
    , ServerVersion.AutoDetect(connnectionString)));

//add validation from current assembly
builder.Services.AddValidatorsFromAssembly(typeof(CustomerValidations).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartUnitOfWork, CartBusiness>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryUnitOfWork, CategoryBusiness>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerUnitOfWork, CustomerBusiness>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductUnitOfWork, ProductBusiness>();

builder.Services.Configure<RabbitMqConnectionHelper>(builder.Configuration.GetSection("rabbitmq"));

<<<<<<< HEAD

Jwt jwt = new();
builder.Configuration.GetSection("Jwt").Bind(jwt);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        ValidateIssuer = true,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Base64UrlEncoder.DecodeBytes(jwt.Key)),
        ValidateIssuerSigningKey = true,
    };
});
=======
//configure cors policy 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

>>>>>>> 6755d7e01b891492ffdd1dbce89320b81a3de246



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
