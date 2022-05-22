using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public enum TransactionType
    {
        Receive, Issue, Transfer, Return
    }

    public partial class InventoryTransaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Lote en BIN")]
        public Guid BinLotId { get; set; }

        [Required]
        [Display(Name = "Tipo de transaccion")]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        public virtual BinLot BinLot { get; set; }
        public virtual User User { get; set; }
    }
}
