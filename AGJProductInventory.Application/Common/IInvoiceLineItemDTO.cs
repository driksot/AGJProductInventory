namespace AGJProductInventory.Application.Common
{
    public interface IInvoiceLineItemDTO
    {
        public int Quantity { get; set; }
        public IProductDTO ProductDTO { get; set; }
    }
}
