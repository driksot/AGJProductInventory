using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;
using AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand;
using AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand;
using AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery;
using AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery;
using AGJProductInventory.Application.Features.ProductVariation.Commands.CreateProductVariationCommand;
using AGJProductInventory.Application.Features.ProductVariation.Commands.UpdateProductVariationCommand;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationDetailQuery;
using AGJProductInventory.Application.Features.ProductVariation.Queries.GetProductVariationListQuery;
using AGJProductInventory.Domain;
using AutoMapper;

namespace AGJProductInventory.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, ICategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Category, CategoryDetailDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, IProductDTO>().ReverseMap();
            CreateMap<Product, ProductListDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<ProductVariation, IProductVariationDTO>().ReverseMap();
            CreateMap<ProductVariation, ProductVariationListDTO>().ReverseMap();
            CreateMap<ProductVariation, ProductVariationDetailDTO>().ReverseMap();
            CreateMap<ProductVariation, CreateProductVariationDTO>().ReverseMap();
            CreateMap<ProductVariation, UpdateProductVariationDTO>().ReverseMap();
        }
    }
}
