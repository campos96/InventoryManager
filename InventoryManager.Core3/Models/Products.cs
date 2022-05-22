using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            Lots = new HashSet<Lots>();
            ProductDetails = new HashSet<ProductDetails>();
            ProductImages = new HashSet<ProductImages>();
        }

        public string Sku { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Lots> Lots { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
    }
}
