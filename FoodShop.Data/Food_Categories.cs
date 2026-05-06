using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Food_Categories
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public List<Foods> Foods { get; set; } = new List<Foods>();
    }
}
