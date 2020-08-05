using System;
using System.Linq;

namespace Engine.Promotions
{
    public class BuyMoreSaveMore : IPromotion
    {
        public char PromotedProductSku { get; private set; }
        public int PromotionQuantity { get; private set; }
        public decimal PromotionAmount { get; private set; }

        public BuyMoreSaveMore(char sku, int quantity, decimal promotionAmount)
        {
            if (sku == default || quantity == default || promotionAmount == default)
                throw new ArgumentNullException();

            PromotedProductSku = sku;
            PromotionQuantity = quantity;
            PromotionAmount = promotionAmount;
        }

        public Cart Calculate(Cart cart)
        {
            decimal total = default;
            var items = cart.Items.Where(x => x.Product.SKU == PromotedProductSku).ToList();

            var totalQuantityToProcess = items.Sum(x => x.Quantity);

            if (items != null && totalQuantityToProcess >= PromotionQuantity)
            {
                var numberOfSets = (int)Math.Floor((decimal)totalQuantityToProcess / PromotionQuantity);
                total = numberOfSets * PromotionAmount;

                int processedProductCount = (numberOfSets * PromotionQuantity);

                var unprocessedQuantity = totalQuantityToProcess - processedProductCount;

                total += unprocessedQuantity * items.FirstOrDefault().Product.Price;

                return new Cart(cart.Items.Except(items).ToList(), cart.Total + total);
            }

            return cart;
        }
    }
}
