using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
    }
}
