using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery
{
    public class CategoryDetailDTO : BaseDTO, ICategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
