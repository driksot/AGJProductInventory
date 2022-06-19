using FluentValidation;

namespace AGJProductInventory.Application.DTOs.ProductVariation
{
    public class ProductVariationDTOValidator : AbstractValidator<ProductVariationDTO>
    {
        public ProductVariationDTOValidator()
        {
            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {0}.");
        }
    }
}
