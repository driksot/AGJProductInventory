using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand
{
    public class CreateProductVariationCommand : IRequest<BaseCommandResponse<ProductVariationDTO>>
    {
        public ProductVariationDTO ProductVariationDTO { get; set; }
    }

    public class CreateProductVariationCommandHandler : IRequestHandler<CreateProductVariationCommand, BaseCommandResponse<ProductVariationDTO>>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public CreateProductVariationCommandHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<ProductVariationDTO>> Handle(CreateProductVariationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ProductVariationDTO>();
            var validator = new ProductVariationDTOValidator();
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
                var productVariation = await _productVariationRepository.Create(request.ProductVariationDTO);

                response.IsSuccess = true;
                response.Data = _mapper.Map<ProductVariationDTO>(productVariation);
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
