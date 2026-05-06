using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Foods
    {
        public int FoodID { get; set; }

        public string? FoodName { get; set; }

        public int FoodCategoryID { get; set; }
        public Food_Categories? FoodCategory { get; set; }

        public string? FoodImageID { get; set; }

        public int Qty { get; set; }
        public decimal SellPrice { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public List<Invoice_Details> Invoice_Details { get; set; } = new List<Invoice_Details>();
    }
}
