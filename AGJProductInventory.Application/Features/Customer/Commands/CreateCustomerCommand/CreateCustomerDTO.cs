using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerDTO : ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
