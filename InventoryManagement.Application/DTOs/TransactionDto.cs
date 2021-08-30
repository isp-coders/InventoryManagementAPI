using System;

namespace InventoryManagement.Application.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int PaymentMethod { get; set; }
        public int TransactionCardId { get; set; }
        public TransactionCardDto TransactionCard { get; set; }
    }
}
