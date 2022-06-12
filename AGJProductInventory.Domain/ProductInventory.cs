using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class ProductInventory : AuditableEntity
    {
        public ProductVariation ProductVariation { get; set; }
        public int ProductVariationId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
