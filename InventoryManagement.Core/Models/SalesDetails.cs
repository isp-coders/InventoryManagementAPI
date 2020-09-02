using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public List<SaleDetailsAndProduct> SaleDetailsAndProducts { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }
        public SalesDetails()
        {
            SaleDetailsAndProducts = new List<SaleDetailsAndProduct>();
            SalePaymentMethods = new List<SalePaymentMethod>();
        }
    }
}
