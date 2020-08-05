using Domain.Models;
using Engine;
using Engine.Promotions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class PromotionEngineTests
    {
        [Fact(DisplayName = "Scenario A tests")]
        public void ScenarioATest()
        {
            //Arrange
            var A = new Product('A', 50);
            var B = new Product('B', 30);
            var C = new Product('C', 20);
            var D = new Product('D', 15);

            ICalculationService _calculationService = new CalculationService();
            IList<IPromotion> promotions = new List<IPromotion>
            {
                new BuyMoreSaveMore('A', 3, 130),
                new BuyMoreSaveMore('B', 2, 45),
                new ComboOffer(new List<char>{ 'C','D' },30)
            };

            //Act
            var items = new List<Item>() { new Item(A, 1), new Item(B, 1), new Item(C, 1) };

            var cart = new Cart(items, _calculationService.CalculateTotalCost(items, promotions));

            //Assert
            Assert.Equal(100, cart.Total);
        }
    }
}
