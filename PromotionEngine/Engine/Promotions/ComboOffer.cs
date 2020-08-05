using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Promotions
{
    public class ComboOffer : IPromotion
    {
        public IEnumerable<char> ComboSku { get; private set; }
        public decimal FlatPrice { get; private set; }

        public ComboOffer(IEnumerable<char> comboSku, decimal flatAmount)
        {
            ComboSku = comboSku;
            FlatPrice = flatAmount;
        }

        public Cart Calculate(Cart cart)
        {
            decimal total = default;

            var items = cart.Items.Where(x => ComboSku.Any(c => c == x.Product.SKU)).ToList();

            var numberOfCombos = ComboSku.Select(x => items.Count(i => i.Product.SKU == x)).Min();

            if (numberOfCombos > 0)
            {
                total = FlatPrice * numberOfCombos;

                var calculatedItems = new List<Item>();

                foreach (var sku in ComboSku)
                {
                    calculatedItems.AddRange(items.Where(x => x.Product.SKU == sku).Take(numberOfCombos));
                }

                var uncalculatedItems = items.Except(calculatedItems);

                total += uncalculatedItems.Any() ? uncalculatedItems.Sum(x => x.Product.Price) : default;

                return new Cart(cart.Items.Except(items).ToList(), cart.Total + total);
            }
            return cart;

        }
    }
}
