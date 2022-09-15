using FluentValidation;
using PayCore.ProductCatalog.Application.Dto_Validator.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Category.Validator
{
    class CategoryDtoValidator : AbstractValidator<CategoryUpsertDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category can not be null");
        }
    }
}
