using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryDTO CategoryDTO { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Category creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Domain.Category>(request.CategoryDTO);

                category = await _categoryRepository.Add(category);

                response.Success = true;
                response.Message = "Category creation successful.";
                response.Id = category.Id;
            }

            return response;
        }
    }
}
