
using System.Collections.Generic;
using DataModel;

namespace CartService
{
    class Cart
    {
        public decimal CartPrice { get; set; }

        public List<CartItem> cartItems;
        private List<IPromotion> promotions;

        public Cart()
        {
            cartItems = new List<CartItem>();
            promotions = new List<IPromotion>();
        }

        public void AddCartItem(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }

        public void AddPromotion(IPromotion promotion)
        {
            promotions.Add(promotion);
        }

        public double ApplyPromotion()
        {
            double CartPrice = 0;
            List<CartItem> cartItemsInCart = new List<CartItem>(cartItems);
            foreach (var promotion in promotions)
            {
                CartPrice += promotion.ApplyPromotion(cartItemsInCart);
            }

            return CartPrice + GetCartPrice(cartItemsInCart);
        }

        private double GetCartPrice(List<CartItem> cartItems)
        {
            double price = 0;
            foreach (var cartItem in cartItems)
            {
                price += cartItem.Item.Price * cartItem.Quantity;
            }

            return price;
        }

        public double GetPriceofAllCartItems()
        {
            return GetCartPrice(cartItems);
        }
    }
}
