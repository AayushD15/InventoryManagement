using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Data.Master
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }

        public Items Items { get; set; }
        public decimal Quantity { get; set; }

    }
}
