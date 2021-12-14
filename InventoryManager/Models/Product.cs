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
        [Display(Name = "SKU de producto")]
        public string Sku { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public IEnumerable<vwProductInventory> ProductInventory { get; set; }

        public IEnumerable<vwProductTransations> ProductTransations { get; set; }
    }
}