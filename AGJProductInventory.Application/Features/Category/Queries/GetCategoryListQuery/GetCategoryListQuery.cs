using AGJProductInventory.Application.Contracts.Persistence;
using AGJProductInventory.Application.DTOs;
using AutoMapper;
using MediatR;

namespace AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery
{
    public class GetCategoryListQuery : IRequest<List<CategoryDTO>>
    {
    }

    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }
    }
}
