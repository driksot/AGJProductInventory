using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerListQuery
{
    public class CustomerListDTO : BaseDTO, ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
