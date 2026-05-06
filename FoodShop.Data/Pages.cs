using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Pages
    {
        public int PageID { get; set; }
        public string? PageName { get; set; }
        public string? Descriptions { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public List<Role_Permissions> RolePermissions { get; set; } = new List<Role_Permissions>();
    }
}
