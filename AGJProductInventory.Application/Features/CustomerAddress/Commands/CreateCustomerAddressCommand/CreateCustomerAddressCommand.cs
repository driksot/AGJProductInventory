using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.CreateCustomerAddressCommand
{
    public class CreateCustomerAddressCommand : IRequest<BaseCommandResponse<CreateCustomerAddressDTO>>
    {
        public CreateCustomerAddressDTO CustomerAddressDTO { get; set; }
    }

    public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateCustomerAddressCommand, BaseCommandResponse<CreateCustomerAddressDTO>>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public CreateCustomerAddressCommandHandler(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CreateCustomerAddressDTO>> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateCustomerAddressDTO>();
            var validator = new CreateCustomerAddressDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerAddressDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer address creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var customerAddress = _mapper.Map<Domain.CustomerAddress>(request.CustomerAddressDTO);

                customerAddress = await _customerAddressRepository.Add(customerAddress);

                response.IsSuccess = true;
                response.Data = _mapper.Map<CreateCustomerAddressDTO>(customerAddress);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
