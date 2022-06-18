using AGJProductInventory.Application.DTOs;
using AGJProductInventory.Domain;
using AutoMapper;

namespace AGJProductInventory.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductVariation, ProductVariationDTO>().ReverseMap();
            CreateMap<CustomerAddress, CustomerAddressDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryDTO>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryUpdateDTO>().ReverseMap();
            CreateMap<ProductInventorySnapshot, ProductInventorySnapshotDTO>().ReverseMap();
        }
    }
}
