using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Data
{
    public class Role_Permissions
    {
        public int RoleID { get; set; }
        public Roles? Roles { get; set; }

        public int PageID { get; set; }
        public Pages? Pages { get; set; }

    }
}
