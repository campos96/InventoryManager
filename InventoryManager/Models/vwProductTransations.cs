using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace InventoryManager.Models
{
    [Table("vwProductTransations")]
    public class vwProductTransations
    {
        [Key]
        public Guid InventoryTransactionID { get; set; }

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