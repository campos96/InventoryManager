using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    [Table("vwProductInventory")]
    public class vwProductInventory
    {
        [Key]
        public Guid BinlotID { get; set; }
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