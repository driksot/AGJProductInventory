using FluentValidation;

namespace AGJProductInventory.Application.DTOs.Customer
{
    public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(32).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(32).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
