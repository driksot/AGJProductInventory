using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse<CategoryDTO>>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CategoryDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CategoryDTO>();
            var validator = new CategoryDTOValidator();
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

                var category = await _categoryRepository.Create(request.CategoryDTO);

                response.IsSuccess = true;
                response.Data = _mapper.Map<CategoryDTO>(category);
                response.Time = DateTime.UtcNow;
                response.Message = "Category creation successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
