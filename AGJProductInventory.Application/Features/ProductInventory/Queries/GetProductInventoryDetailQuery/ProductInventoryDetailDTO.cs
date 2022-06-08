﻿using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.ProductInventory.Queries.GetProductInventoryDetailQuery
{
    public class ProductInventoryDetailDTO : BaseDTO, IProductInventoryDTO
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
    }
}
