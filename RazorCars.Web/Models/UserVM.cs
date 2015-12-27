using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazorCars.Web.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public AccountVM Account { get; set; }
        public DateTime AccountCreated { get; set; }
    }

    

    public class AccountVM
    {
        public int Id { get; set; }
        public ICollection<PurchaseVM> Purchases { get; set; }
        public ICollection<ReceiptVM> Receipts { get; set; }
    }

    public class PurchaseVM
    {
        public int Id { get; set; }

    }

    public class ReceiptVM
    {
        public int Id { get; set; }
    }

    
}