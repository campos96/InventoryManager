using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class BinLot
    {
        public BinLot()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Numero de BIN")]
        public string BinNumber { get; set; }

        [Required]
        [Display(Name = "Numero de lote")]
        public string LotNumber { get; set; }

        public virtual Bin Bin { get; set; }
        public virtual Lot Lot { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
