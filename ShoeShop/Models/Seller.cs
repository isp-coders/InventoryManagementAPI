using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string SellerCode { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BranchId { get; set; }
        public List<Sale> Sales { get; set; }
        public Role Role { get; set; }
    }
}
