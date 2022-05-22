using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class InventoryTransactions
    {
        public Guid Id { get; set; }
        public Guid BinLotId { get; set; }
        public int TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }

        public virtual BinLots BinLot { get; set; }
        public virtual Users UsernameNavigation { get; set; }
    }
}
