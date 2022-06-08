
using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommand : IRequest<BaseCommandResponse<UpdateCustomerDTO>>
    {
        public int Id { get; set; }
        public UpdateCustomerDTO CustomerDTO { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseCommandResponse<UpdateCustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ICustomerAddressRepository customerAddressRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<UpdateCustomerDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateCustomerDTO>();
            var validator = new UpdateCustomerDTOValidator(_customerAddressRepository);
            var validationResult = await validator.ValidateAsync(request.CustomerDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var customer = await _customerRepository.Get(request.Id);

                if (request.CustomerDTO != null)
                {
                    _mapper.Map(request.CustomerDTO, customer);
                    await _customerRepository.Update(customer);
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<UpdateCustomerDTO>(customer);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
