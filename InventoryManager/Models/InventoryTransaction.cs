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
        public Guid BinLotID { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
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