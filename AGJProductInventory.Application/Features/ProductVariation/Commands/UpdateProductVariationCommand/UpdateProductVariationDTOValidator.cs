using FluentValidation;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand
{
    public class UpdateProductVariationDTOValidator : AbstractValidator<ICustomerAddressListDTO>
    {
        public UpdateProductVariationDTOValidator()
        {
            Include(new UpdateProductVariationDTOValidator());
        }
    }
}
