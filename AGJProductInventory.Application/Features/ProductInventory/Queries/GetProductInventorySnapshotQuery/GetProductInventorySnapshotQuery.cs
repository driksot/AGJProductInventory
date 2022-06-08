using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventorySnapshotQuery
{
    public class GetProductInventorySnapshotQuery : IRequest<List<ProductInventorySnapshotListDTO>>
    {
    }

    public class GetProductInventorySnapshotQueryHandler : IRequestHandler<GetProductInventorySnapshotQuery, List<ProductInventorySnapshotListDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventorySnapshotQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductInventorySnapshotListDTO>> Handle(GetProductInventorySnapshotQuery request, CancellationToken cancellationToken)
        {
            var snapshotList = await _productInventoryRepository.GetProductInventorySnapshots();
            return _mapper.Map<List<ProductInventorySnapshotListDTO>>(snapshotList);
        }
    }
}
