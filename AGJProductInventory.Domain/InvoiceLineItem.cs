﻿namespace AGJProductInventory.Domain
{
    public class InvoiceLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
