using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<BaseCommandResponse<CategoryDTO>>
    {
        public int Id { get; set; }
        public CategoryDTO CategoryDTO { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<CategoryDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CategoryDTO>();
            var validator = new CategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CategoryDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Time = DateTime.UtcNow;
                response.Message = "Category update failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var category = await _categoryRepository.Get(request.Id);

                _mapper.Map(request.CategoryDTO, category);

                await _categoryRepository.Update(category);

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
