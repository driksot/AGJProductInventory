using FluentValidation;

namespace AGJProductInventory.Application.DTOs.Category
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
