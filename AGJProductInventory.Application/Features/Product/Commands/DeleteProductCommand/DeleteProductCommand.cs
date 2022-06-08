using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseCommandResponse<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var product = await _productRepository.Get(request.Id);

            if (product == null)
            {
                response.IsSuccess = false;
                response.Data = 0;
                response.Time = DateTime.UtcNow;
                response.Message = "Product deletion failed.";
                response.Errors = null;
            }
            else
            {
                await _productRepository.Delete(product);

                response.IsSuccess = true;
                response.Data = request.Id;
                response.Time = DateTime.UtcNow;
                response.Message = "Product deletion successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
