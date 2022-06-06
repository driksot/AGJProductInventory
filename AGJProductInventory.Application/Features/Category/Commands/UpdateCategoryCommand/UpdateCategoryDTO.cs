using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryDTO : BaseDTO, ICategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
