using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class ProductImage
    {
        [Key]
        public Guid Id { get; set; }

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

        public virtual Product Product { get; set; }
    }
}
