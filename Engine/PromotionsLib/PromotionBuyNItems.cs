using System.Collections.Generic;
using System.Linq;
using DataModel;

namespace PromotionsLib
{
    class PromotionBuyNItems : IPromotion
    {
        public string ItemId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public PromotionBuyNItems(string itemId, int itemCount, double price)
        {
            ItemId = itemId;
            Count = itemCount;
            Price = price;
        }
        public double ApplyPromotion(List<CartItem> cartItems)
        {
            var cartItem = cartItems.Where(s => s.Item.ProductId == ItemId).FirstOrDefault();

            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
                return (cartItem.Quantity / Count) * Price + (cartItem.Quantity % Count) * cartItem.Item.Price;
            }

            return 0;
        }
    }
}
