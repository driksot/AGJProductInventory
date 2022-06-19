using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Customer;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerListQuery
{
    public class GetCustomerListQuery : IRequest<List<CustomerDTO>>
    {
    }

    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }
    }
}
