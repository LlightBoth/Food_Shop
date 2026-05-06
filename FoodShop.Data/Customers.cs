using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string? CustomerName { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public CustomerStatus Status { get; set; } = CustomerStatus.Active;

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public List<Invoices> Invoices { get; set; } = new List<Invoices>();
    }

    public enum CustomerStatus {
        Active,
        Inactive,
    }
    
}
