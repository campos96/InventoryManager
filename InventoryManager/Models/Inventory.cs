using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string ProductSku { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }

        [Required]
        public int QuantityAllocated { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}