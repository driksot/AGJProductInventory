using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class Customer : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public int AddressId { get; set; }
    }
}
