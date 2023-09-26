using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Data.Master
{
    public class Items
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemStock { get; set; }
        public decimal? ItemPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
