using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Application.DTOs.Category;
using AGJProductInventory.Application.DTOs.Customer;
using AGJProductInventory.Application.DTOs.Product;
using AGJProductInventory.Application.DTOs.ProductInventory;
using AGJProductInventory.Application.DTOs.ProductVariation;
using AGJProductInventory.Domain;
using AutoMapper;

namespace AGJProductInventory.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<ProductVariation, ProductVariationDTO>().ReverseMap();
            CreateMap<ProductVariation, CreateProductVariationDTO>().ReverseMap();

            CreateMap<CustomerAddress, CustomerAddressDTO>().ReverseMap();
            CreateMap<CustomerAddress, CreateCustomerAddressDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();

            CreateMap<ProductInventory, ProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventory, UpdateProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventory, CreateProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventorySnapshot, ProductInventorySnapshotDTO>().ReverseMap();
        }
    }
}
