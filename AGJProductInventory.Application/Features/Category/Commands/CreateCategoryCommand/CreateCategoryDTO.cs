using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryDTO : ICategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
