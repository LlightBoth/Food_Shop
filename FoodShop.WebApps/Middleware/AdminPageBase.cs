using FoodShop.WebApps.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FoodShop.WebApps.Middleware
{
    public class AdminPageBase : ComponentBase
    {
        [Inject] protected UserSession UserSession { get; set; }
        [Inject] protected CurrentUser CurrentUser { get; set; }
        [Inject] protected NavigationManager NavManager { get; set; }
        [Inject] protected CheckRoleServices CheckRole { get; set; }

        protected bool IsAuthorize = false;

        protected override async Task OnInitializedAsync()
        {

            var user_localStorage = CurrentUser.GetUserIdAsync();
            // Not logged in
            if (user_localStorage == null)
            {
                NavManager.NavigateTo("/login");
                return;
            }

            // Not admin
            Console.WriteLine("Check Role Admin");
            //if (!await CheckRole.IsAdmin())
            //{
            //    NavManager.NavigateTo("/access-denied");
            //    return;
            //}

            IsAuthorize = true;
        }
    }
}