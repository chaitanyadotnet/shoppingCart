using Domain.Models;
using System;

namespace Engine.Promotions
{
    public class Discount : IPromotion
    {
        
        public Cart Calculate(Cart cart)
        {
            //this is a future class to use for % discounts 
            throw new NotImplementedException();
        }
    }
}
