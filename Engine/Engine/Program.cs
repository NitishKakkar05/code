using System;
using DataModel;
using CartService;
using PromotionsLib;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Promotion Engine...");

            Console.WriteLine("Adding Cart Item.");

            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "A", Price = 50 }, Quantity = 5 });
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "B", Price = 30 }, Quantity = 5 });
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "C", Price = 20 }, Quantity = 1 });

            Console.WriteLine("Following Items have been added to cart..\n");
            PrintCartItems(cart);

            Console.WriteLine("\nApplying active promotions...");

            cart.AddPromotion(new PromotionBuyNItems("A", 3, 130));
            cart.AddPromotion(new PromotionBuyNItems("B", 2, 45));
            cart.AddPromotion(new PromotionBuyForFixedPrice("C", "D", 30));

            var priceWithoutPromotions = cart.GetPriceofAllCartItems();
            Console.WriteLine($"\nPrice Without Promotions is -: {priceWithoutPromotions}" );
            var priceAfterPromotions = cart.ApplyPromotion();
            Console.WriteLine($"\nPrice after Promotions is -: {priceAfterPromotions}");
            Console.ReadKey();
        }

        static void PrintCartItems(Cart cart)
        {
            if (cart== null)
            {
                Console.WriteLine("There is no item in cart, Please add items in cart");
                return;
            }
            foreach (var item in cart.cartItems)
            {
                Console.WriteLine($"Item {item.Item.ProductId} quantity {item.Quantity}  and unit price {item.Item.Price} ");
            }
        }
    }
}
