using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommand : IRequest<BaseCommandResponse<CustomerDTO>>
    {
        public CustomerDTO CustomerDTO { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCommandResponse<CustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CustomerDTO>();
            var validator = new CustomerDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CustomerDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var customer = await _customerRepository.Create(request.CustomerDTO);

            response.IsSuccess = true;
            response.Data = _mapper.Map<CustomerDTO>(customer);
            response.Time = DateTime.UtcNow;
            response.Message = "Customer created successfully.";
            response.Errors = null;

            return response;
        }
    }
}
