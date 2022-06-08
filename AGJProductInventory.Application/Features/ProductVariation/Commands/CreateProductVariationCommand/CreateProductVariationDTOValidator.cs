using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand
{
    public class CreateProductVariationDTOValidator : AbstractValidator<CreateProductVariationDTO>
    {
        public CreateProductVariationDTOValidator()
        {
            Include(new IProductVariationDTOValidator());
        }
    }
}
