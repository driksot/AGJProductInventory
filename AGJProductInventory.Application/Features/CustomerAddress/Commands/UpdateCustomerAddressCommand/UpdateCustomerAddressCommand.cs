using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.UpdateCustomerAddressCommand
{
    public class UpdateCustomerAddressCommand : IRequest<BaseCommandResponse<UpdateCustomerAddressDTO>>
    {
        public int Id { get; set; }
        public UpdateCustomerAddressDTO CustomerAddressDTO { get; set; }
    }

    public class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, BaseCommandResponse<UpdateCustomerAddressDTO>>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerAddressCommandHandler(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<UpdateCustomerAddressDTO>> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateCustomerAddressDTO>();
            var validator = new UpdateCustomerAddressDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerAddressDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer address update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var customerAddress = await _customerAddressRepository.Get(request.Id);

                _mapper.Map(request.CustomerAddressDTO, customerAddress);

                await _customerAddressRepository.Update(customerAddress);

                response.IsSuccess = true;
                response.Data = _mapper.Map<UpdateCustomerAddressDTO>(customerAddress);
                response.Time = DateTime.UtcNow;
                response.Message = "Customer address creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
