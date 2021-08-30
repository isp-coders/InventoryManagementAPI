using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class TransactionCardDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CardCode { get; set; }
        public string OwnerName { get; set; }
        public string Gsm { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
