using Domain.Models;
using Engine.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public interface ICalculationService
    {
        decimal CalculateTotalCost(IEnumerable<Item> items, IEnumerable<IPromotion> promotions);
    }
}
