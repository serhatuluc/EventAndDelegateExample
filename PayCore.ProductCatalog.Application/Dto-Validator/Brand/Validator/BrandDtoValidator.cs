using FluentValidation;
using PayCore.ProductCatalog.Application.Dto_Validator.Brand.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Brand.Validator
{
    public class BrandDtoValidator:AbstractValidator<BrandUpsertDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Brand can not be null");
        }
    }
}
