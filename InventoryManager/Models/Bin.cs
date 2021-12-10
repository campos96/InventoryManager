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
        [Required]
        [Display(Name = "Numero de BIN")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Fecha Creado")]
        public DateTime CreatedAt { get; set; }
    }
}