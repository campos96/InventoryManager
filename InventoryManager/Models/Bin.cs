using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class Bin
    {
        [Key]
        public string Number { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}