using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand
{
    public class UpdateProductInventoryUnitsDTOValidator : AbstractValidator<UpdateProductInventoryUnitsDTO>
    {
        public UpdateProductInventoryUnitsDTOValidator()
        {
            Include(new IProductInventoryDTOValidator());
        }
    }
}
