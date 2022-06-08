using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressDetailQuery
{
    public class GetCustomerAddressDetailQuery : IRequest<CustomerAddressDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetCustomerAddressDetailQueryHandler : IRequestHandler<GetCustomerAddressDetailQuery, CustomerAddressDetailDTO>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public GetCustomerAddressDetailQueryHandler(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<CustomerAddressDetailDTO> Handle(GetCustomerAddressDetailQuery request, CancellationToken cancellationToken)
        {
            var customerAddress = await _customerAddressRepository.Get(request.Id);
            return _mapper.Map<CustomerAddressDetailDTO>(customerAddress);
        }
    }
}
