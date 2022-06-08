using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Customer.Queries.GetCustomerDetailQuery
{
    public class CustomerDetailDTO : BaseDTO, ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
