using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        public Guid Id { get; set; }

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

        public virtual Products ProductSkuNavigation { get; set; }
    }
}
