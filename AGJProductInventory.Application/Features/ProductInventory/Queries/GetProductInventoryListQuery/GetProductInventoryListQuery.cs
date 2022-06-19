using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.ProductInventory;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryListQuery
{
    public class GetProductInventoryListQuery : IRequest<List<ProductInventoryDTO>>
    {
    }

    public class GetProductInventoryListQueryHandler : IRequestHandler<GetProductInventoryListQuery, List<ProductInventoryDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventoryListQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductInventoryDTO>> Handle(GetProductInventoryListQuery request, CancellationToken cancellationToken)
        {
            var inventoryList = await _productInventoryRepository.GetCurrentInventory();
            return _mapper.Map<List<ProductInventoryDTO>>(inventoryList);
        }
    }
}
