using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerDTOValidator : AbstractValidator<UpdateCustomerDTO>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public UpdateCustomerDTOValidator(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;

            Include(new ICustomerDTOValidator(_customerAddressRepository));
        }
    }
}
