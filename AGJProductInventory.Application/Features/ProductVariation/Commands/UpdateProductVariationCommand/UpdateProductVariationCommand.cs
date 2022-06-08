using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand
{
    public class UpdateProductVariationCommand : IRequest<BaseCommandResponse<ICustomerAddressListDTO>>
    {
        public int Id { get; set; }
        public ICustomerAddressListDTO ProductVariationDTO { get; set; }
    }

    public class UpdateProductVariationCommandHandler : IRequestHandler<UpdateProductVariationCommand, BaseCommandResponse<ICustomerAddressListDTO>>
    {
        private readonly IProductVariationRepository _productVariationRepository;
        private readonly IMapper _mapper;

        public UpdateProductVariationCommandHandler(IProductVariationRepository productVariationRepository, IMapper mapper)
        {
            _productVariationRepository = productVariationRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<ICustomerAddressListDTO>> Handle(UpdateProductVariationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ICustomerAddressListDTO>();
            var validator = new UpdateProductVariationDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ProductVariationDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var productVariation = await _productVariationRepository.Get(request.Id);

                _mapper.Map(request.ProductVariationDTO, productVariation);

                await _productVariationRepository.Update(productVariation);

                response.IsSuccess = true;
                response.Data = _mapper.Map<ICustomerAddressListDTO>(productVariation);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
