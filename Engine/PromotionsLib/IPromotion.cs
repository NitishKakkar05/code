/// <summary>
/// An interface which should be implemented by all promotions.
/// </summary>

using System.Collections.Generic;
using DataModel;

namespace PromotionsLib
{
    public interface IPromotion
    {
        double ApplyPromotion(List<CartItem> cartItems);
    }
}