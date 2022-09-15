
using FluentValidation;
using PayCore.ProductCatalog.Application.Dto;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Color.Validator
{
    class ColorDtoValidator:AbstractValidator<ColorUpsertDto>
    {
        public ColorDtoValidator()
        {
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("Color can not be null");
        }
    }
}
