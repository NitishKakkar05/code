using System;
using System.Collections.Generic;
using DataModel;

namespace CartService
{
    class PromotionBuyForFixedPrice : IPromotion
    {
        public string SKU1 { get; set; }
        public string SKU2 { get; set; }
        public double Price { get; set; }
        public PromotionBuyForFixedPrice(string itemA, string itemB, double price)
        {
            SKU1 = itemA;
            SKU2 = itemB;
            Price = price;
        }
        public double ApplyPromotion(List<CartItem> cartItems)
        {
            bool containSKU1 = false, containSKU2 = false;
            CartItem cartItemA = null, cartItemB = null;


            foreach (var cartItem in cartItems)
            {
                if (cartItem.Item.ProductId == SKU1)
                {
                    containSKU1 = true;
                    cartItemA = cartItem;
                }
                else if (cartItem.Item.ProductId == SKU2)
                {
                    containSKU2 = true;
                    cartItemB = cartItem;
                }
            }

            if (containSKU1 && containSKU2)
            {
                int commonQty = Math.Min(cartItemA.Quantity, cartItemB.Quantity);
                cartItems.Remove(cartItemA);
                cartItems.Remove(cartItemB);
                return commonQty * Price + (cartItemA.Quantity - commonQty) * cartItemA.Item.Price + (cartItemB.Quantity - commonQty) * cartItemB.Item.Price;
            }
            else if (containSKU1)
            {
                cartItems.Remove(cartItemA);
                return cartItemA.Quantity * cartItemA.Item.Price;
            }
            else if (containSKU2)
            {
                cartItems.Remove(cartItemB);
                return cartItemB.Quantity * cartItemB.Item.Price;
            }

            return 0;
        }
    }
}
