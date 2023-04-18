using ElectronicsShop_service.Models;
using FluentValidation;

namespace ElectronicsShop_service.Dtos;
public class ProductValidations : AbstractValidator<Product>
{
    public ProductValidations()
    {

    }
}