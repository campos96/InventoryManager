﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class Lots
    {
        public Lots()
        {
            BinLots = new HashSet<BinLots>();
        }

        [Key]
        [Display(Name = "Numero de lote")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "SKU de producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Fecha de recibo")]
        public DateTime ReceivedAt { get; set; }

        [Display(Name = "Fecha de expiracion")]
        public DateTime? ExpirationDate { get; set; }

        public virtual Products ProductSkuNavigation { get; set; }
        public virtual ICollection<BinLots> BinLots { get; set; }
    }
}
