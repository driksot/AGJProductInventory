using AGJProductInventory.Application.Contracts.Persistence;
using FluentValidation;

namespace AGJProductInventory.Application.Common
{
    public class ICustomerDTOValidator : AbstractValidator<ICustomerDTO>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public ICustomerDTOValidator(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;

            RuleFor(p => p.CustomerAddressId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var customerAddressExists = await _customerAddressRepository.Exists(id);
                    return customerAddressExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
