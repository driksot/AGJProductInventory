using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery
{
    public class GetProductVariationListQuery : IRequest<List<ProductVariationListDTO>>
    {
    }

    public class GetProductVariationListQueryHandler : IRequestHandler<GetProductVariationListQuery, List<ProductVariationListDTO>>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public GetProductVariationListQueryHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVariationListDTO>> Handle(GetProductVariationListQuery request, CancellationToken cancellationToken)
        {
            var productVariations = await _productVariationRepository.GetAll();
            return _mapper.Map<List<ProductVariationListDTO>>(productVariations);
        }
    }
}
