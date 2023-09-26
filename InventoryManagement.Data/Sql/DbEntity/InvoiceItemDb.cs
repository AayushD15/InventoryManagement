using InventoryManagement.Data.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Data.Sql.DbEntity
{
    [Table("InvoiceItems", Schema = "ce")]
    public class InvoiceItemDb
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual InvoiceDb Invoice { get; set; }
        public virtual Items Items { get; set; }
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
    }
}
