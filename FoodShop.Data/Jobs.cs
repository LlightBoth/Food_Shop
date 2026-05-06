using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Jobs
    {
        public int JobID { get; set; }
        public string? JobName { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
