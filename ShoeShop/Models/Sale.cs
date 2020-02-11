﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public List<SaleProduct> SaleProducts { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }
        public Sale()
        {
            SaleProducts = new List<SaleProduct>();
            SalePaymentMethods = new List<SalePaymentMethod>();
        }
    }
}
