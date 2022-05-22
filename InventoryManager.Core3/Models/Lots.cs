using System;
using System.Collections.Generic;

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

        public string Number { get; set; }
        public string ProductSku { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Products ProductSkuNavigation { get; set; }
        public virtual ICollection<BinLots> BinLots { get; set; }
    }
}
