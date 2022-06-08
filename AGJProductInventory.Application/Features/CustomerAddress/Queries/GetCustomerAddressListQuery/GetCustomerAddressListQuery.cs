using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressListQuery
{
    public class GetCustomerAddressListQuery : IRequest<List<CustomerAddressListDTO>>
    {
    }

    public class GetCustomerAddressListQueryHandler : IRequestHandler<GetCustomerAddressListQuery, List<CustomerAddressListDTO>>
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public GetCustomerAddressListQueryHandler(ICustomerAddressRepository customerAddressRepository, IMapper mapper)
        {
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerAddressListDTO>> Handle(GetCustomerAddressListQuery request, CancellationToken cancellationToken)
        {
            var customerAddresses = await _customerAddressRepository.GetAll();
            return _mapper.Map<List<CustomerAddressListDTO>>(customerAddresses);
        }
    }
}
