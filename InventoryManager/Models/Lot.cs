using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class Lot
    {
        [Key]
        [Display(Name = "Numero de lote")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "SKU de producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Fecha de recibo")]
        public DateTime ReceivedAt { get; set; }

        [Display(Name = "Fecha de expiracion")]
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}