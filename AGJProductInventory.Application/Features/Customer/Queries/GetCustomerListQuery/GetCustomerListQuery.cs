using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerListQuery
{
    public class GetCustomerListQuery : IRequest<List<CustomerListDTO>>
    {
    }

    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListDTO>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerListDTO>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomerListWithDetails();
            return _mapper.Map<List<CustomerListDTO>>(customers);
        }
    }
}
