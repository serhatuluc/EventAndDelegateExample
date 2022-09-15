

using FluentValidation;
using PayCore.ProductCatalog.Application.Dto_Validator.Offer.Dto;

namespace PayCore.ProductCatalog.Application.Dto_Validator.Offer.Validator
{
    public class OfferDtoValidator:AbstractValidator<OfferUpsertDto>
    {
        public OfferDtoValidator()
        {
            //RuleFor(x=>x.OfferedPrice).
        }
    }
}
