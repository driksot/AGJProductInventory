using AGJProductInventory.Application.Contracts.Persistence;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);

            if (category == null) throw new Exception(); // TODO: set up NotFoundException

            await _categoryRepository.Delete(category);

            return Unit.Value;
        }
    }
}
