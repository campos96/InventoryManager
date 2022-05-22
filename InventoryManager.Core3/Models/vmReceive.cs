using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManager.Core3.Models
{
    [NotMapped]
    public class vmReceive
    {
        [Required]
        [Display(Name = "SKU de producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Numero de BIN")]
        public string BinNumber { get; set; }

        [Required]
        [Display(Name = "Numero de lote")]
        public string LotNumber { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Display(Name = "Fecha de expiracion")]
        public DateTime? ExpirationDate { get; set; }
    }
}
