using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery
{
    public class GetProductListQuery : IRequest<List<ProductListDTO>>
    {
    }

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductListWithDetails();
            return _mapper.Map<List<ProductListDTO>>(products);
        }
    }
}
