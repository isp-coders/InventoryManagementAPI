using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RefundAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int? CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<SaleDetailsAndProduct> SaleDetailsAndProducts { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }

        public SalesDetails()
        {
            SaleDetailsAndProducts = new List<SaleDetailsAndProduct>();
            SalePaymentMethods = new List<SalePaymentMethod>();
        }
    }
}
