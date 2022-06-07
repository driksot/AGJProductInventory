using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse<CreateCategoryDTO>>
    {
        public CreateCategoryDTO CategoryDTO { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<CreateCategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CreateCategoryDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateCategoryDTO>();
            var validator = new CreateCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = _mapper.Map<Domain.Category>(request.CategoryDTO);

                category = await _categoryRepository.Add(category);

                response.IsSuccess = true;
                response.Data = _mapper.Map<CreateCategoryDTO>(category);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
