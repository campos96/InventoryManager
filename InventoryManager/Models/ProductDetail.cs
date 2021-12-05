﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class ProductDetail
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string ProductSku { get; set; }

        [Required]
        public string Details { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}