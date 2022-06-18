using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseCommandResponse<int>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var customer = await _customerRepository.Get(request.Id);

            if (customer == null)
            {
                response.IsSuccess = false;
                response.Data = 0;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer deletion failed.";
                response.Errors = null;
            }
            else
            {
                await _customerRepository.Delete(customer.Id);

                response.IsSuccess = true;
                response.Data = request.Id;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer deletion successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
