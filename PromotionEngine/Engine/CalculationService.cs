using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Engine.Promotions;

namespace Engine
{
    public class CalculationService : ICalculationService
    {
        public decimal CalculateTotalCost(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
        {
            throw new NotImplementedException();
        }
    }
}
