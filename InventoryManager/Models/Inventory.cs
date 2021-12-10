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
        [Display(Name = "SKU de Producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Cantidad disponible")]
        public int QuantityAvailable { get; set; }

        [Required]
        [Display(Name = "Cantidad Reservada")]
        public int QuantityAllocated { get; set; }

        [Required]
        [Display(Name = "Ultima actualizacion")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}