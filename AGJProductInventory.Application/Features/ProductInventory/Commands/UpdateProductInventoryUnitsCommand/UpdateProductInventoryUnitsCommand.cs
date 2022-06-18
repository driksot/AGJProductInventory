using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand
{
    public class UpdateProductInventoryUnitsCommand : IRequest<BaseCommandResponse<ProductInventoryUpdateDTO>>
    {
        public int Id { get; set; }
        public ProductInventoryUpdateDTO ProductInventoryDTO { get; set; }
    }

    public class UpdateProductInventoryUnitsCommandHandler : IRequestHandler<UpdateProductInventoryUnitsCommand, BaseCommandResponse<ProductInventoryUpdateDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductInventoryUnitsCommandHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<ProductInventoryUpdateDTO>> Handle(UpdateProductInventoryUnitsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ProductInventoryUpdateDTO>();
            var validator = new ProductInventoryUpdateDTOValidator();
            var validationResult = await validator.ValidateAsync(request.ProductInventoryDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Product inventory count update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var inventory = await _productInventoryRepository.UpdateUnitsAvailable(request.Id, request.ProductInventoryDTO.Adjustment);

                response.IsSuccess = true;
                response.Data = _mapper.Map<ProductInventoryUpdateDTO>(inventory);
                response.Time = DateTime.UtcNow;
                response.Message = "Product inventory count update successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
