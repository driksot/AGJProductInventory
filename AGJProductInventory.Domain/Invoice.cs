using AGJProductInventory.Domain.Common;

namespace AGJProductInventory.Domain
{
    public class Invoice : AuditableEntity
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}
