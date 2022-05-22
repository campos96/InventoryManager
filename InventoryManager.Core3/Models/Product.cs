using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            Lots = new HashSet<Lot>();
            ProductDetails = new HashSet<ProductDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

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

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
