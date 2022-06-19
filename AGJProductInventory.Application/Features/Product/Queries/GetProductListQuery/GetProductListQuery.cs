using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery
{
    public class GetProductListQuery : IRequest<List<ProductDTO>>
    {
    }

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
