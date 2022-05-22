using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class ProductImages
    {
        public Guid Id { get; set; }
        public string ProductSku { get; set; }
        public string FileName { get; set; }
        public string ServerFileName { get; set; }
        public string FileType { get; set; }
        public bool Hidden { get; set; }

        public virtual Products ProductSkuNavigation { get; set; }
    }
}
