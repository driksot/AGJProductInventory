namespace AGJProductInventory.Application.Common
{
    public interface ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICustomerAddressDTO CustomerAddressDTO { get; set; }
    }
}
