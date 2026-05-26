using System.Text.Json;
using FoodShop.WebApps.Services;
using Microsoft.JSInterop;

namespace FoodShop.WebApps.Services
{
    public class CurrentUser
    {
        private readonly IJSRuntime _js;
        private const string LocalStorageKey = "user_session";

        public UserSession Session { get; set; } = new();

        public event Action? OnChange;

        // Register Javascript
        public CurrentUser(IJSRuntime js)
        {
            _js = js;
        }

        public async Task LoadUserSession()
        {
            // Return a JSON string to C# object.
            var json = await _js.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);
            if (!string.IsNullOrEmpty(json))
            {
                Session = JsonSerializer.Deserialize<UserSession>(json) ?? new();
                NotifyStateChanged();
            }
        }

        public async Task SaveUserSession()
        {
            // Converts a C# object into a JSON string.
            var json = JsonSerializer.Serialize(Session);
            await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
        }

        public async Task ClearUserSession()
        {
            Session = new();
            await _js.InvokeVoidAsync("localStorage.removeItem", LocalStorageKey);
            NotifyStateChanged();
        }

        public bool IsLoggedIn => Session.UserId.HasValue;

        public string GetRoute()
        {
            return Session.IsEmployee ? "/dashboard" : "/";
        }


        // Return User From LocalStorage
        public async Task<int?> GetUserIdAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);

            if (string.IsNullOrEmpty(json))
                return null;

            var session = JsonSerializer.Deserialize<UserSession>(json);
            return session?.UserId;
        }

        public async Task<string?> GetUserUsernameAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);
            if (string.IsNullOrEmpty(json))
                return null;

            var session = JsonSerializer.Deserialize<UserSession>(json);
            return session?.UserName;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}