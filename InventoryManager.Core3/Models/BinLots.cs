using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class BinLots
    {
        public BinLots()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Numero de BIN")]
        public string BinNumber { get; set; }

        [Required]
        [Display(Name = "Numero de lote")]
        public string LotNumber { get; set; }

        public virtual Bins BinNumberNavigation { get; set; }
        public virtual Lots LotNumberNavigation { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
