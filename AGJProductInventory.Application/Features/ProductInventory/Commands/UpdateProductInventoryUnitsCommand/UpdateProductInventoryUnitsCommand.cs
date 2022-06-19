using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.ProductInventory;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand
{
    public class UpdateProductInventoryUnitsCommand : IRequest<BaseCommandResponse<UpdateProductInventoryDTO>>
    {
        public int Id { get; set; }
        public UpdateProductInventoryDTO ProductInventoryDTO { get; set; }
    }

    public class UpdateProductInventoryUnitsCommandHandler : IRequestHandler<UpdateProductInventoryUnitsCommand, BaseCommandResponse<UpdateProductInventoryDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductInventoryUnitsCommandHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<UpdateProductInventoryDTO>> Handle(UpdateProductInventoryUnitsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateProductInventoryDTO>();
            var validator = new UpdateProductInventoryDTOValidator();
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
                response.Data = _mapper.Map<UpdateProductInventoryDTO>(inventory);
                response.Time = DateTime.UtcNow;
                response.Message = "Product inventory count update successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
