using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGJProductInventory.Application.Common
{
    public interface IInvoiceDTO
    {
        public ICustomerDTO CustomerDTO { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<IInvoiceLineItemDTO> InvoiceLineItemDTOs { get; set; }
    }
}
