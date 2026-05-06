

namespace FoodShop.Models
{
    public class CartItem
    {
        public int FoodId { get; set; }

        // Instead of the whole 'Foods' object, just take what the UI needs
        public string FoodName { get; set; } = string.Empty;
        public string? ImagePath { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
