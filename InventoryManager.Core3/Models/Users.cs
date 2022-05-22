using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InventoryManager.Core3.Models
{
    public partial class Users
    {
        public Users()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
        }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
