using CartService;
using DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionsLib;

namespace UnitTests
{
    [TestClass]
    public class Testing
    {

        [TestMethod]
        public void ValidateAddCartItem()
        {
            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "A", Price = 50 }, Quantity = 5 });
            Assert.AreEqual(cart.cartItems.Count, 1);
        }

        [TestMethod]
        public void ValidateAddPromotions()
        {
            Cart cart = new Cart();
            cart.AddPromotion(new PromotionBuyNItems("A", 3, 130));
            Assert.AreEqual(cart.promotions.Count, 1);
        }

        [TestMethod]
        public void ValidateApplyPromotionBuyNItems()
        {
            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "A", Price = 50 }, Quantity = 3 });
            cart.AddPromotion(new PromotionBuyNItems("A", 3, 130));

            var cartPrice = cart.ApplyPromotion();

            Assert.AreEqual(cartPrice, 130);

        }

        [TestMethod]
        public void ValidateApplyPromotionBuyForFixedPrice()
        {
            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "C", Price = 20 }, Quantity = 1 });
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "D", Price = 15 }, Quantity = 1 });
            cart.AddPromotion(new PromotionBuyForFixedPrice("C", "D", 30));

            var cartPrice = cart.ApplyPromotion();

            Assert.AreEqual(cartPrice, 30);

        }

        [TestMethod]
        public void ValidatePriceWithoutPromotionBuyNItems()
        {
            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "C", Price = 20 }, Quantity = 1 });
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "D", Price = 15 }, Quantity = 1 });

            var cartPrice = cart.GetPriceofAllCartItems();

            Assert.AreEqual(cartPrice, 35);

        }

        [TestMethod]
        public void ValidatePriceWithoutPromotionBuyForFixedPrice()
        {
            Cart cart = new Cart();
            cart.AddCartItem(new CartItem { Item = new Product { ProductId = "A", Price = 50 }, Quantity = 3 });

            var cartPrice = cart.GetPriceofAllCartItems();

            Assert.AreEqual(cartPrice, 150);

        }

    }
}
