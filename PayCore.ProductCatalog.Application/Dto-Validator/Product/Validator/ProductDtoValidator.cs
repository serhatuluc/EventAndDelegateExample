using FluentValidation;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Product.Validator
{
    public class ProductDtoValidator:AbstractValidator<ProductUpsertDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.ProductName).MaximumLength(100).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(500).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UsingStatus).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
        }
    }
}
