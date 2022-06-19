using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.ProductVariation;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery
{
    public class GetProductVariationListQuery : IRequest<List<ProductVariationDTO>>
    {
        public int ProductId { get; set; }
    }

    public class GetProductVariationListQueryHandler : IRequestHandler<GetProductVariationListQuery, List<ProductVariationDTO>>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public GetProductVariationListQueryHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVariationDTO>> Handle(GetProductVariationListQuery request, CancellationToken cancellationToken)
        {
            var productVariations = await _productVariationRepository.GetAll(request.ProductId);
            return _mapper.Map<List<ProductVariationDTO>>(productVariations);
        }
    }
}
