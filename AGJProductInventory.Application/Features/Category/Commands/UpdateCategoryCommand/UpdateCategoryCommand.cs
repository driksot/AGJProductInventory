using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDTO CategoryDTO { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryDTO);

            if (!validationResult.IsValid) throw new Exception(); // TODO: create validation exception

            var category = await _categoryRepository.Get(request.CategoryDTO.Id);

            _mapper.Map(request.CategoryDTO, category);

            await _categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
