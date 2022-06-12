using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductInventory.Commands.UpdateProductInventoryUnitsCommand
{
    public class UpdateProductInventoryUnitsDTO : IProductInventoryDTO
    {
        public int ProductVariationId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
        public int Adjustment { get; set; }
    }
}
