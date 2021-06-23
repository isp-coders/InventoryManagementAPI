using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int PaymentMethod { get; set; }
        public int TransactionCardId { get; set; }
        public TransactionCard TransactionCard { get; set; }

    }
}
