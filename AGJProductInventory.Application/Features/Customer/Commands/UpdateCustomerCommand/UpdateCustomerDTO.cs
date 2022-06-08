using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerDTO : ICustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerAddressId { get; set; }
    }
}
