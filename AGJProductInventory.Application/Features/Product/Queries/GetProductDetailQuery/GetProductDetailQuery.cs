using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery
{
    public class GetProductDetailQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
