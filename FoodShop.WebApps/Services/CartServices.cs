using System.Text.Json;
using Microsoft.JSInterop;
using FoodShop.Data;
using FoodShop.Models;

namespace FoodShop.WebApps.Services
{
    public class CartServices
    {
        private readonly IJSRuntime _js;
        private const string LocalStorageKey = "user_cart";

        public List<CartItem> Items { get; private set; } = new();
        public event Action? OnChange;

        // Inject IJSRuntime to use LocalStorage
        public CartServices(IJSRuntime js)
        {
            _js = js;
        }

        // Change the signature to use simple parameters
        public async Task AddToCart(int foodId, string name, string imageId, decimal price, int amount)
        {
            var existingItem = Items.FirstOrDefault(x => x.FoodId == foodId);

            if (existingItem != null)
            {
                existingItem.Quantity += amount;
            }
            else
            {
                Items.Add(new CartItem
                {
                    FoodId = foodId,
                    FoodName = name,
                    ImagePath = imageId,
                    UnitPrice = price,
                    Quantity = amount
                });
            }

            await SaveCartToLocalStorage();
            NotifyStateChanged();
        }
        public async Task RemoveItem(int id)
        {
            var itemToRemove = Items.FirstOrDefault(x => x.FoodId == id);

            if (itemToRemove != null) { 
                Items.Remove(itemToRemove);
                await SaveCartToLocalStorage();
                NotifyStateChanged();  // Tell the Blazor UI to refresh (eg. Nav, Cart page)
            }
        }


        // JSON Local-Storage
        public async Task LoadCart()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);
            if (!string.IsNullOrEmpty(json))
            {
                // Deserialize the JSON string back into our List
                Items = JsonSerializer.Deserialize<List<CartItem>>(json) ?? new();
                NotifyStateChanged();
            }
        }

        public async Task SaveCartToLocalStorage()
        {
            // Convert the List to a JSON string
            var json = JsonSerializer.Serialize(Items);
            await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
        }

        public async Task ClearCart()
        {
            Items.Clear();
            await _js.InvokeVoidAsync("localStorage.removeItem", LocalStorageKey);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}