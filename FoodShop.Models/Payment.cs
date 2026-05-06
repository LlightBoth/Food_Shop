using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Models
{
    public class Payment
    {
        public string[] PaymentMethod { get; set; } = ["QR", "Transfer", "COD"];
        public string DefaultPayment { get; set; }

        public Payment() {
            DefaultPayment = PaymentMethod?.FirstOrDefault() ?? "";
        }

        
    }

    //public enum PaymentMethod
    //{
    //    CreditCard,
    //    QR,
    //    Transfer
    //}
}
