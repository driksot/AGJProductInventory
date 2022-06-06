using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;
using AGJProductInventory.Domain;
using AutoMapper;

namespace AGJProductInventory.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, ICategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Category, CategoryDetailDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}
