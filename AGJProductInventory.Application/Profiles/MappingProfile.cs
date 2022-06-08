using AGJProductInventory.Application.Common;
using AGJProductInventory.Application.Features.Category.Commands.CreateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Commands.UpdateCategoryCommand;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoriesListQuery;
using AGJProductInventory.Application.Features.Category.Queries.GetCategoryDetailQuery;
using AGJProductInventory.Application.Features.Customer.Commands.CreateCustomerCommand;
using AGJProductInventory.Application.Features.Customer.Commands.UpdateCustomerCommand;
using AGJProductInventory.Application.Features.Customer.Queries.GetCustomerDetailQuery;
using AGJProductInventory.Application.Features.Customer.Queries.GetCustomerListQuery;
using AGJProductInventory.Application.Features.CustomerAddress.Commands.CreateCustomerAddressCommand;
using AGJProductInventory.Application.Features.CustomerAddress.Commands.UpdateCustomerAddressCommand;
using AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressDetailQuery;
using AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressListQuery;
using AGJProductInventory.Application.Features.Product.Commands.CreateProductCommand;
using AGJProductInventory.Application.Features.Product.Commands.UpdateProductCommand;
using AGJProductInventory.Application.Features.Product.Queries.GetProductDetailQuery;
using AGJProductInventory.Application.Features.Product.Queries.GetProductListQuery;
using AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryDetailQuery;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryListQuery;
using AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventorySnapshotQuery;
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

            CreateMap<CustomerAddress, ICustomerAddressDTO>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressListDTO>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressDetailDTO>().ReverseMap();
            CreateMap<CustomerAddress, UpdateCustomerAddressDTO>().ReverseMap();
            CreateMap<CustomerAddress, CreateCustomerAddressDTO>().ReverseMap();

            CreateMap<Customer, ICustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerListDTO>().ReverseMap();
            CreateMap<Customer, CustomerDetailDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();

            CreateMap<ProductInventory, IProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryListDTO>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryDetailDTO>().ReverseMap();
            CreateMap<ProductInventory, UpdateProductInventoryUnitsDTO>().ReverseMap();

            CreateMap<ProductInventorySnapshot, IProductInventorySnapshotDTO>().ReverseMap();
            CreateMap<ProductInventorySnapshot, ProductInventorySnapshotListDTO>().ReverseMap();
        }
    }
}
