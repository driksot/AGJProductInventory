using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.UpdateCustomerAddressCommand
{
    public class UpdateCustomerAddressDTOValidator : AbstractValidator<UpdateCustomerAddressDTO>
    {
        public UpdateCustomerAddressDTOValidator()
        {
            Include(new ICustomerAddressDTOValidator());
        }
    }
}
