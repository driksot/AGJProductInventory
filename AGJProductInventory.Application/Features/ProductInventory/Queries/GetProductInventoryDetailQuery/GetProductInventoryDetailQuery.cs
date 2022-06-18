using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryDetailQuery
{
    public class GetProductInventoryDetailQuery : IRequest<ProductInventoryDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductInventoryDetailQueryHandler : IRequestHandler<GetProductInventoryDetailQuery, ProductInventoryDTO>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public GetProductInventoryDetailQueryHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductInventoryDTO> Handle(GetProductInventoryDetailQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _productInventoryRepository.GetByProductId(request.Id);
            return _mapper.Map<ProductInventoryDTO>(inventory);
        }
    }
}
