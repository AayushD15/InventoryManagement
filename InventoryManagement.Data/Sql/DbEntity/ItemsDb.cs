using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Data.Sql.DbEntity
{
    [Table("Items", Schema = "ce")]
    public class ItemsDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemStock { get; set; }
        public decimal? ItemPrice { get; set; }
        public bool IsDeleted { get; set; }

    }
}
