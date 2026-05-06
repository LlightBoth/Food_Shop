using FoodShop.Data;
using FoodShop.WebApps.Services;
using Microsoft.AspNetCore.Components;


namespace FoodShop.WebApps.Middleware
{
    public class CheckRoleBase : ComponentBase
    {
        [Inject] protected UserSession UserSession { get; set; }
        [Inject] protected CurrentUser CurrentUser { get; set; }
        [Inject] protected NavigationManager NavManager { get; set; }
        [Inject] protected CheckRoleServices CheckRole { get; set; }

        protected bool IsAuthorize = false;

        private bool _initialized = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Render the page first
            if (!firstRender || _initialized) return;

            _initialized = true;

            // Get User ID
            var user_localStorage = await CurrentUser.GetUserIdAsync();

            if (user_localStorage == null)
            {
                NavManager.NavigateTo("/login");
                return;
            }

            // set User ID to local variable (UserSession)
            UserSession.UserId = user_localStorage;
            Console.WriteLine($"User is: {user_localStorage}");

            // Get User Role ID
            var user_role = await CheckRole.GetRoleID();

            if (user_role == 0)
            {
                NavManager.NavigateTo("/access-denied");
                return;
            }

            Console.WriteLine($"User is: {user_role}");

            // Get User Role Permission -> Page Allowed or not
            var hasPermission = await CheckRole.GetRolePermission(user_role);

            if (!hasPermission)
            {
                NavManager.NavigateTo("/access-denied");
                return;
            }

            foreach (var role in UserSession.RolePermissionPage) { Console.Write($"{role.ToString()}, "); }

            // Check Current URI, If Allowed In Or Not
            var currentPage = NavManager.ToBaseRelativePath(NavManager.Uri).ToLower();

            if (UserSession.RolePermissionPage == null || !UserSession.RolePermissionPage.Any(p => p.ToLower() == currentPage))
            {
                NavManager.NavigateTo("/access-denied");
                return;
            }

            Console.WriteLine($"{NavManager.Uri}");

            IsAuthorize = true;

            StateHasChanged(); // 🔥 important
        }
    }
}
