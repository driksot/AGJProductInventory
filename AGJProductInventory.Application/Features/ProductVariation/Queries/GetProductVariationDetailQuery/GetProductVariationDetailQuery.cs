using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationDetailQuery
{
    public class GetProductVariationDetailQuery : IRequest<ProductVariationDetailDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductVariationDetailQueryHandler : IRequestHandler<GetProductVariationDetailQuery, ProductVariationDetailDTO>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public GetProductVariationDetailQueryHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<ProductVariationDetailDTO> Handle(GetProductVariationDetailQuery request, CancellationToken cancellationToken)
        {
            var productVariation = await _productVariationRepository.Get(request.Id);
            return _mapper.Map<ProductVariationDetailDTO>(productVariation);
        }
    }
}
