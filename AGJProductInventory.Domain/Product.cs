using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsArchived { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
