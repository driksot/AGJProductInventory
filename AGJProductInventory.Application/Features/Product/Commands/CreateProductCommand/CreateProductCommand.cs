using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<BaseCommandResponse<ProductDTO>>
    {
        public ProductDTO ProductDTO { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<ProductDTO>();
            var validator = new ProductDTOValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Product creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var product = await _productRepository.Create(request.ProductDTO);

            response.IsSuccess = true;
            response.Data = _mapper.Map<ProductDTO>(product);
            response.Time = DateTime.UtcNow;
            response.Message = "Product created successfully.";
            response.Errors = null;

            return response;
        }
    }
}
