using System.Net;
using System.Text;
using Authentication.Infrastructure.Models;
using BusinessLogic.Entry.Options;
using ElectronicsShop_service;
using ElectronicsShop_service.BusinessLogic;
using ElectronicsShop_service.Helpers;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.NetworkCalls;
using ElectronicsShop_service.Repositories;
using ElectronicsShop_service.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//configure swagger gen options

builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();

builder.Services.AddSwaggerGen();

var connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connnectionString
    , ServerVersion.AutoDetect(connnectionString)));


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
// try
// {
MessageQueueManager messageQueueManager = new MessageQueueManager(
    Options.Create<RabbitMqConnectionHelper>(
        builder.Configuration.GetSection("rabbitmq").Get<RabbitMqConnectionHelper>()
        ),
    builder.Services.BuildServiceProvider()
    );
messageQueueManager.SubscribeToUsersQueue();
// }
// catch (Exception ex)
// {
// Console.WriteLine(ex);
// }

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
        ValidateIssuerSigningKey = true,
    };
});

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

builder.Services.AddCoreAdmin();

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

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/coreadmin" && context.Request.Query["password"] != "iamthebigadminhere")
    {
        context.Response.StatusCode = 403;
        return;
    }

    await next(context);
});

app.MapDefaultControllerRoute();

app.Run();