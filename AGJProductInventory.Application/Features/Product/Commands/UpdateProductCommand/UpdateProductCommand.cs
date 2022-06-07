using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateProductDTO ProductDTO { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
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

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDTOValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDTO);

            if (!validationResult.IsValid) throw new Exception(); // TODO: ValidationException

            var product = await _productRepository.Get(request.Id);

            if (request.ProductDTO != null)
            {
                _mapper.Map(request.ProductDTO, product);
                await _productRepository.Update(product);
            }

            return Unit.Value;
        }
    }
}
