using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class BinLot
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string BinNumber { get; set; }

        [Required]
        public string LotNumber { get; set; }

        [ForeignKey("BinNumber")]
        public Bin Bin { get; set; }

        [ForeignKey("LotNumber")]
        public Lot Lot { get; set; }
    }
}