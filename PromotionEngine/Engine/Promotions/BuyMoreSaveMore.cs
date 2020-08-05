using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Promotions
{
    public class BuyMoreSaveMore : IPromotion
    {
        public char PromotedProductSku { get; private set; }
        public int PromotionQuantity { get; private set; }
        public decimal PromotionAmount { get; private set; }

        public BuyMoreSaveMore(char sku, int quantity, decimal promotionAmount)
        {
            PromotedProductSku = sku;
            PromotionQuantity = quantity;
            PromotionAmount = promotionAmount;
        }

        public Cart Calculate(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
