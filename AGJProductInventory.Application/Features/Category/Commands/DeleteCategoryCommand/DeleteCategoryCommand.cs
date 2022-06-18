using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Contracts.Persistence;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse<int>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var category = await _categoryRepository.Get(request.Id);

            if (category == null)
            {
                response.IsSuccess = false;
                response.Data = 0;
                response.Time = DateTime.UtcNow;
                response.Message = "Category deletion failed.";
                response.Errors = null;
            }
            else
            {
                await _categoryRepository.Delete(category.Id);

                response.IsSuccess = true;
                response.Data = request.Id;
                response.Time = DateTime.UtcNow;
                response.Message = "Category deletion successful.";
                response.Errors = null;
            }

            return response;
        }
    }
}
