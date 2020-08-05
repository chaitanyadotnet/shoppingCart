using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Engine.Promotions;

namespace Engine
{
    public class CalculationService : ICalculationService
    {
        public decimal CalculateTotalCost(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
        {
            var casherCart = new Cart(items.ToList());

            foreach (var promotion in promotions)
            {
                casherCart = promotion.Calculate(casherCart);
            }
            var leftoverItemsCost = casherCart.Items.Any() ? casherCart.Items.Sum(x => x.Product.Price) : default;

            return casherCart.Total + leftoverItemsCost;
        }
    }
}
