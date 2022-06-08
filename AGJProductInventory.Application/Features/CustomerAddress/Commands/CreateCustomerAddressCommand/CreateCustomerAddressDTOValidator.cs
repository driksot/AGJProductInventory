using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.CreateCustomerAddressCommand
{
    public class CreateCustomerAddressDTOValidator : AbstractValidator<CreateCustomerAddressDTO>
    {
        public CreateCustomerAddressDTOValidator()
        {
            Include(new ICustomerAddressDTOValidator());
        }
    }
}
