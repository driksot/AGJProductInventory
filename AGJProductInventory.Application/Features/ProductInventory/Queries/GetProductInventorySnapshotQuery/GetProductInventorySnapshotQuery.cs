using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventorySnapshotQuery
{
    public class GetProductInventorySnapshotQuery : IRequest<List<ProductInventorySnapshotDTO>>
    {
    }

    public class GetProductInventorySnapshotQueryHandler : IRequestHandler<GetProductInventorySnapshotQuery, List<ProductInventorySnapshotDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventorySnapshotQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductInventorySnapshotDTO>> Handle(GetProductInventorySnapshotQuery request, CancellationToken cancellationToken)
        {
            var snapshotList = await _productInventoryRepository.GetSnapshotHistory();
            return _mapper.Map<List<ProductInventorySnapshotDTO>>(snapshotList);
        }
    }
}
