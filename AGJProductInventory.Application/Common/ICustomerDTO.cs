namespace AGJProductInventory.Application.Common
{
    public interface ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
