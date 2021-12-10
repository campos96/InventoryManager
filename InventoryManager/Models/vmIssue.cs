using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class vmIssue
    {
        [Required]
        [Display(Name = "SKU de producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

    }
}