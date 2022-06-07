using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductDTOValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new IProductDTOValidator(_categoryRepository));
        }
    }
}
