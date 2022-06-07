﻿using AGJProductInventory.Application.Common;
using FluentValidation;

namespace AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            Include(new ICategoryDTOValidator());
        }
    }
}
