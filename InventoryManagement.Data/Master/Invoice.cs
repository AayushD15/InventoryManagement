using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Data.Master
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public bool IsDeleted { get; set; }

    }
}
