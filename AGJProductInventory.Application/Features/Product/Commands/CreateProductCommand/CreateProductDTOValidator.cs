using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductDTOValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new IProductDTOValidator(_categoryRepository));
        }
    }
}
