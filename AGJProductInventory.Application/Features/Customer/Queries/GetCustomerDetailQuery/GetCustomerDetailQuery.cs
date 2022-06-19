using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Customer;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerDetailQuery
{
    public class GetCustomerDetailQuery : IRequest<CustomerDTO>
    {
        public int Id { get; set; }
    }

    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
