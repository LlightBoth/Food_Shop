using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Invoice_Details
    {
        public int InvoiceID { get; set; }
        public Invoices Invoices { get; set; }

        public int FoodID { get; set; }
        public Foods Foods { get; set; }

        public int Qty { get; set; }
        public decimal Price { get; set; }

    }
}
