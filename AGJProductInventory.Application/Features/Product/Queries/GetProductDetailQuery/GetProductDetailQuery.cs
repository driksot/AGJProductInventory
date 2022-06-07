using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery
{
    public class GetProductDetailQuery : IRequest<ProductDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDetailDTO> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithDetails(request.Id);
            return _mapper.Map<ProductDetailDTO>(product);
        }
    }
}
