using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            Include(new ICategoryDTOValidator());
        }
    }
}
