using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    [Table("vwProductTransations")]
    public partial class VwProductTransations
    {
        [Key]
        public Guid InventoryTransactionId { get; set; }

        [Display(Name = "SKU de producto")]
        public string Sku { get; set; }

        [Display(Name = "Tipo de transaction")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Numero de BIN")]
        public string BinNumber { get; set; }

        [Display(Name = "Numero de lote")]
        public string LotNumber { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
    }
}
