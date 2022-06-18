using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using MediatR;

namespace AGJProductInventory.Application.Features.ProductVariation.Commands.DeleteProductVariationCommand
{
    public class DeleteProductVariationCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProductVariationCommandHandler : IRequestHandler<DeleteProductVariationCommand, BaseCommandResponse<int>>
    {
        private readonly IProductVariationRepository _productVariationRepository;

        public DeleteProductVariationCommandHandler(IProductVariationRepository productVariationRepository)
        {
            _productVariationRepository = productVariationRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteProductVariationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var productVariation = await _productVariationRepository.Get(request.Id);

            if (productVariation == null)
            {
                response.IsSuccess = false;
                response.Data = 0;
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation deletion failed.";
                response.Errors = null;
            }
            else
            {
                await _productVariationRepository.Delete(productVariation.Id);

                response.IsSuccess = true;
                response.Data = request.Id;
                response.Time = DateTime.UtcNow;
                response.Message = "Product variation deletion successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
