using FluentValidation;

namespace AGJProductInventory.Application.Common
{
    public class ICategoryDTOValidator : AbstractValidator<ICategoryDTO>
    {
        public ICategoryDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
