using System;
using System.Collections.Generic;

namespace InventoryManagement.Core.Models
{
    public class TransactionCard
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CardCode { get; set; }
        public string OwnerName { get; set; }
        public string Gsm { get; set; }
        public int Currency { get; set; }
        public string Email { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
