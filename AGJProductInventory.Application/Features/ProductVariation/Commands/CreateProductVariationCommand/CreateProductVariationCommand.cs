using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand
{
    public class CreateProductVariationCommand : IRequest<BaseCommandResponse<CreateProductVariationDTO>>
    {
        public CreateProductVariationDTO ProductVariationDTO { get; set; }
    }

    public class CreateProductVariationCommandHandler : IRequestHandler<CreateProductVariationCommand, BaseCommandResponse<CreateProductVariationDTO>>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public CreateProductVariationCommandHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CreateProductVariationDTO>> Handle(CreateProductVariationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateProductVariationDTO>();
            var validator = new CreateProductVariationDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ProductVariationDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var productVariation = _mapper.Map<Domain.ProductVariation>(request.ProductVariationDTO);
                productVariation = await _productVariationRepository.CreateProductVariationAndInventory(productVariation);

                response.IsSuccess = true;
                response.Data = _mapper.Map<CreateProductVariationDTO>(productVariation);
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
