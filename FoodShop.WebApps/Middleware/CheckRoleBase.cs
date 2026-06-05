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
        [Inject] protected CheckRoleServices CheckRole { get; set; } = default;

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

            // 4. Clean and Match Current URI safely
            var currentPage = NavManager.ToBaseRelativePath(NavManager.Uri)
                .Split('?', StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim('/')
                .ToLower();

            // If currentPage is empty, it means they are on the Root/Home page "/"
            if (string.IsNullOrEmpty(currentPage))
            {
                currentPage = "dashboard"; // Or whatever your default home/dashboard path string is
            }

            // Check if the current page exists in the allowed list
            bool canAccess = UserSession.RolePermissionPage != null && UserSession.RolePermissionPage.Any(allowedPage =>
            {
                var cleanAllowed = allowedPage.Trim('/').ToLower();

                // Exact match (e.g., "food" == "food")
                if (cleanAllowed == currentPage) return true;

                // Route Parameter match (e.g., "food/details/12" starts with "food/details/")
                if (currentPage.StartsWith(cleanAllowed + "/")) return true;

                return false;
            });

            if (!canAccess)
            {
                NavManager.NavigateTo("/access-denied");
                return;
            }

            // If all checks pass, allow rendering
            UserSession.PreviousURI = currentPage;
            IsAuthorize = true;
            Console.WriteLine($"{NavManager.Uri}");

            StateHasChanged(); // important for render refresh ui
        }
    }
}
