using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CreateCustomerDTOValidator(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;

            Include(new ICustomerDTOValidator(_customerAddressRepository));
        }
    }
}
