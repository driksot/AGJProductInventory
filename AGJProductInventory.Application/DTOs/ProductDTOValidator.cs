using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.DTOs
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductDTOValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var categoryExists = await _categoryRepository.Exists(id);
                    return categoryExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
