using Domain.Models;
using System;

namespace Engine.Promotions
{
    public class Discount : IPromotion
    {
        public Product Product { get; private set; }
        public decimal DiscountPersentage { get; private set; }

        public Discount(Product product, decimal discountPersentage)
        {
            Product = product;
            DiscountPersentage = discountPersentage;
        }
        public Cart Calculate(Cart cart)
        {
            //this is a future class to use for % discounts 
            throw new NotImplementedException();
        }
    }
}
