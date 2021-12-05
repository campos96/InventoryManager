using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class Product
    {
        [Key]
        public string Sku { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}