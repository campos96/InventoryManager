using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManager.Models
{
    public class ProductImage
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "SKU de producto")]
        public string ProductSku { get; set; }

        [Required]
        [Display(Name = "Nombre de archivo")]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "Nombre de archivo en servidor")]
        public string ServerFileName { get; set; }
        
        [Required]
        [Display(Name = "Tipo de archivo")]
        public string FileType { get; set; }

        [Required]
        [Display(Name = "Oculto?")]
        public bool Hidden { get; set; }

        [ForeignKey("ProductSku")]
        public Product Product { get; set; }
    }
}