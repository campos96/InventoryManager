using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class InventoryTransaction
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Lote en BIN")]
        public Guid BinLotID { get; set; }

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

        [ForeignKey("BinLotID")]
        public BinLot BinLot { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }
    }

    public enum TransactionType
    {
        Receive, Issue, Transfer, Return
    }
}