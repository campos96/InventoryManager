using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class Bins
    {
        public Bins()
        {
            BinLots = new HashSet<BinLots>();
        }

        [Key]
        [Required]
        [Display(Name = "Numero de BIN")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Fecha Creado")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<BinLots> BinLots { get; set; }
    }
}
