using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class VwProductTransations
    {
        public string Sku { get; set; }
        public int TransactionType { get; set; }
        public string BinNumber { get; set; }
        public string LotNumber { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public Guid InventoryTransactionId { get; set; }
    }
}
