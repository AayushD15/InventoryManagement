using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Data.Sql.DbEntity
{
    [Table("Invoice", Schema = "ce")]
    public class InvoiceDb
    {
        public InvoiceDb()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public virtual ICollection<InvoiceItemDb> Items { get; set; }
        public bool IsDeleted { get; set; }

    }
}
