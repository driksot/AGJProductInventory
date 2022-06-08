using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using MediatR;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.DeleteCustomerAddressCommand
{
    public class DeleteCustomerAddressCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, BaseCommandResponse<int>>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public DeleteCustomerAddressCommandHandler(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var customerAddress = await _customerAddressRepository.Get(request.Id);

            if (customerAddress == null)
            {
                response.IsSuccess = false;
                response.Data = 0;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer address deletion failed.";
                response.Errors = null;
            }
            else
            {
                await _customerAddressRepository.Delete(customerAddress);

                response.IsSuccess = true;
                response.Data = request.Id;
                response.Time = DateTime.UtcNow;
                response.Message = "Customer address deletion successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
