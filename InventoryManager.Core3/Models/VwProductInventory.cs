using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class VwProductInventory
    {
        public string BinNumber { get; set; }
        public string LotNumber { get; set; }
        public string ProductSku { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Guid BinlotId { get; set; }
    }
}
