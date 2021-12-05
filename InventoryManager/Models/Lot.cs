using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class Lot
    {
        [Key]
        public string Number { get; set; }

        [Required]
        public string ProductSku { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ReceivedAt { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}