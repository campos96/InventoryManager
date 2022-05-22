using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class ProductDetails
    {
        public Guid Id { get; set; }
        public string ProductSku { get; set; }
        public string Details { get; set; }

        public virtual Products ProductSkuNavigation { get; set; }
    }
}
