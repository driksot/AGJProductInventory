using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<BaseCommandResponse<ProductDTO>>
    {
        public int Id { get; set; }
        public ProductDTO ProductDTO { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<ProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ProductDTO>();
            var validator = new ProductDTOValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Product update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var product = await _productRepository.Get(request.Id);

                if (request.ProductDTO != null)
                {
                    _mapper.Map(request.ProductDTO, product);
                    await _productRepository.Update(product);
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<ProductDTO>(product);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
