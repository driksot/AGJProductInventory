using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class ProductVariation : AuditableEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
    }
}
