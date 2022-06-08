using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerDetailQuery
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailDTO>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDetailDTO> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerWithDetails(request.Id);
            return _mapper.Map<CustomerDetailDTO>(customer);
        }
    }
}
