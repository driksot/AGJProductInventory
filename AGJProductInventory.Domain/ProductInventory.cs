using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class ProductInventory : AuditableEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
