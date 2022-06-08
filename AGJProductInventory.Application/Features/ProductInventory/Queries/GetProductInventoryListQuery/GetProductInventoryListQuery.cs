using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryListQuery
{
    public class GetProductInventoryListQuery : IRequest<List<ProductInventoryListDTO>>
    {
    }

    public class GetProductInventoryListQueryHandler : IRequestHandler<GetProductInventoryListQuery, List<ProductInventoryListDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventoryListQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductInventoryListDTO>> Handle(GetProductInventoryListQuery request, CancellationToken cancellationToken)
        {
            var inventoryList = await _productInventoryRepository.GetProductInventoryListWithDetails();
            return _mapper.Map<List<ProductInventoryListDTO>>(inventoryList);
        }
    }
}
