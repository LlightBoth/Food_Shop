namespace FoodShop.WebApps.Services
{
    public class UserSession
    {
        public int? UserId { get; set; } = null;
        public string UserName { get; set; } = "";
        public string PreviousURI { get; set; } = "";
        public bool IsEmployee { get; set; } = false;
        public List<String>? RolePermissionPage { get; set; } = null; // optional
    }
}
