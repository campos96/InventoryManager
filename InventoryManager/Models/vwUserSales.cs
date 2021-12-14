using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    [Table("vwUserSales")]
    public class vwUserSales
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