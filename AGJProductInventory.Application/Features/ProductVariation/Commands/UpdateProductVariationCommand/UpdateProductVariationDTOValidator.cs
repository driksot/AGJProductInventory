using FluentValidation;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand
{
    public class UpdateProductVariationDTOValidator : AbstractValidator<UpdateProductVariationDTO>
    {
        public UpdateProductVariationDTOValidator()
        {
            Include(new UpdateProductVariationDTOValidator());
        }
    }
}
