using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery
{
    public class CategoryListDTO : BaseDTO, ICategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
