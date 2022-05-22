using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    [Table("vwUserSales")]
    public partial class VwUserSales
    {
        [Key]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Display(Name = "SKU de producto")]
        public string Sku { get; set; }

        [Display(Name = "Precio unitario")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Cantidad total")]
        public int TotalQuantity { get; set; }

        [Display(Name = "Venta Total")]
        public decimal TotalPrice { get; set; }
    }
}
