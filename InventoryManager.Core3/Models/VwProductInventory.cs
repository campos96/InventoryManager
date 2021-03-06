using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    [Table("vwProductInventory")]
    public partial class VwProductInventory
    {
        [Key]
        public Guid BinlotId { get; set; }
        public string ProductSku { get; set; }

        [Display(Name = "Numero de BIN")]
        public string BinNumber { get; set; }

        [Display(Name = "Numero de lote")]
        public string LotNumber { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Display(Name = "Fecha de recibo")]
        public DateTime ReceivedAt { get; set; }

        [Display(Name = "Fecha de expiracion")]
        public DateTime? ExpirationDate { get; set; }
    }
}
