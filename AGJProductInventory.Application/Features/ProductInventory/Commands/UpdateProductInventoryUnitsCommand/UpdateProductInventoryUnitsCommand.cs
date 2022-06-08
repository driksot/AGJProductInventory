using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand
{
    public class UpdateProductInventoryUnitsCommand : IRequest<BaseCommandResponse<UpdateProductInventoryUnitsDTO>>
    {
        public int Id { get; set; }
        public UpdateProductInventoryUnitsDTO ProductInventoryDTO { get; set; }
    }

    public class UpdateProductInventoryUnitsCommandHandler : IRequestHandler<UpdateProductInventoryUnitsCommand, BaseCommandResponse<UpdateProductInventoryUnitsDTO>>
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductInventoryUnitsCommandHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper)
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<UpdateProductInventoryUnitsDTO>> Handle(UpdateProductInventoryUnitsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateProductInventoryUnitsDTO>();
            var validator = new UpdateProductInventoryUnitsDTOValidator();
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
                var inventory = await _productInventoryRepository.UpdateProductInventoryUnitsAvailable(request.Id, request.ProductInventoryDTO.Adjustment);

                response.IsSuccess = true;
                response.Data = _mapper.Map<UpdateProductInventoryUnitsDTO>(inventory);
                response.Time = DateTime.UtcNow;
                response.Message = "Product inventory count update successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
