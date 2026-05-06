using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Roles
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public string? Descriptions { get; set; } = string.Empty;

        public int? ByEmployeeID { get; set; }
        public Employee? ByEmployee { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;

        public List<Role_Permissions> RolePermissions { get; set; } = new List<Role_Permissions>();
    }
}
