using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Invoices
    {
        public int InvoiceID { get; set; }
        public DateTime? InvoiceDate { get; set; } = DateTime.UtcNow;
        public int SellerID { get; set; }
        public Employee? Seller { get; set; }

        public int? DeliveryID { get; set; }
        public Employee? Delivery { get; set; }

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public InvoiceStatus? Status { get; set; } = InvoiceStatus.Pending;
        public decimal TotalAmount { get; set; }
        public decimal TotalFee { get; set; }
        public string PaymentMethod { get; set; } = "COD";
        public string PaymentImage { get; set; } = "";

        public List<Invoice_Details> InvoiceDetails { get; set; } = new List<Invoice_Details>();

    }

    public enum InvoiceStatus
    {
        Pending,
        On_Deliverd,
        In_Process,
        Completed,
        Cancel
    }
}
