using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryDetailQuery
{
    public class GetProductInventoryDetailQuery : IRequest<ProductInventoryDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductInventoryDetailQueryHandler : IRequestHandler<GetProductInventoryDetailQuery, ProductInventoryDetailDTO>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventoryDetailQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductInventoryDetailDTO> Handle(GetProductInventoryDetailQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _productInventoryRepository.GetProductInventoryWithDetails(request.Id);
            return _mapper.Map<ProductInventoryDetailDTO>(inventory);
        }
    }
}
