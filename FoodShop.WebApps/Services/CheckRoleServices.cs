using System.Linq;
using FoodShop.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.WebApps.Services
{
    public class CheckRoleServices
    {
        private readonly FoodShopDbContext _db;
        private readonly UserSession _session;


        public CheckRoleServices(FoodShopDbContext db, UserSession session)
        {
            _db = db;
            _session = session;
        }

        public async Task<int> GetRoleID()
        {
            if (_session.UserId == null) return 0;

            return await _db.Employees
                .Where(e => e.EmployeeID == _session.UserId)
                .Select(e => e.Role.RoleID)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GetRolePermission(int roleId)
        {
            // 1. Safety check
            if (_session.UserId == null) return false;

            // 2. Cache Optimization: If permissions are already loaded, don't hit the DB again!
            if (_session.RolePermissionPage != null && _session.RolePermissionPage.Any())
            {
                return true;
            }

            // 3. Query the database cleanly
            var permissions = await _db.Role_Permissions
                .Where(rp => rp.RoleID == roleId && rp.Pages != null)
                .Select(rp => rp.Pages.PageName)
                .ToListAsync();

            // 4. Assign to session safely
            _session.RolePermissionPage = permissions;

            return permissions.Any();
        }
    }
}
