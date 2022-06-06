using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGJProductInventory.Domain
{
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public ProductInventory ProductInventory { get; set; }
        public DateTime SnapshotTime { get; set; }

    }
}
