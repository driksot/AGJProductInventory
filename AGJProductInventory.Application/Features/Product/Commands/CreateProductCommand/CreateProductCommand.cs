using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<BaseCommandResponse<CreateProductDTO>>
    {
        public CreateProductDTO ProductDTO { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<CreateProductDTO>>
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

        public async Task<BaseCommandResponse<CreateProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateProductDTO>();
            var validator = new CreateProductDTOValidator(_categoryRepository);
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
            response.Data = _mapper.Map<CreateProductDTO>(product);
            response.Time = DateTime.UtcNow;
            response.Message = "Product created successfully.";
            response.Errors = null;

            return response;
        }
    }
}
