using AutoMapper;
using CommonGenericClasses;
using ElectronicsShop_service.Dtos;
using ElectronicsShop_service.Interfaces;
using ElectronicsShop_service.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop_service.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : BaseController<Category, CategoryDto>
{
    public CategoryController(ICategoryUnitOfWork unitOfWork, IMapper mapper, IValidator<Category> validator) : base(unitOfWork, mapper, validator)
    {
    }



}