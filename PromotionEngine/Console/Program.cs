using Domain.Models;
using Engine;
using Engine.Promotions;
using System.Collections.Generic;
using System.Linq;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new Product('A', 50);
            var B = new Product('B', 30);
            var C = new Product('C', 20);
            var D = new Product('D', 15);

            ICalculationService calculationService = new CalculationService();
            IList<IPromotion> promotions = new List<IPromotion>
            {
                new BuyMoreSaveMore('A', 3, 130),
                new BuyMoreSaveMore('B', 2, 45),
                new ComboOffer(new List<char>{ 'C','D' },30)
            };

            //Scenario A
            var items = new List<Item>() { new Item(A, 1), new Item(B, 1), new Item(C, 1) };

            var cart = new Cart(items, calculationService.CalculateTotalCost(items, promotions));

            DisplayCart(cart, "Scenario A");

            //Scenario B
            items = new List<Item>() { new Item(A, 5), new Item(B, 5), new Item(C, 1) };

            cart = new Cart(items, calculationService.CalculateTotalCost(items, promotions));

            System.Console.WriteLine("Scenario B");
            cart.Items.ToList().ForEach(x => System.Console.WriteLine($"{x.Product.SKU}   {x.Quantity}"));
            System.Console.WriteLine("--------");
            System.Console.WriteLine(cart.Total);
            System.Console.WriteLine();

            //Scenario C
            items = new List<Item>() { new Item(A, 3), new Item(B, 5), new Item(C, 1), new Item(D, 1) };

            cart = new Cart(items, calculationService.CalculateTotalCost(items, promotions));

            System.Console.WriteLine("Scenario C");
            cart.Items.ToList().ForEach(x => System.Console.WriteLine($"{x.Product.SKU}   {x.Quantity}"));
            System.Console.WriteLine("--------");
            System.Console.WriteLine(cart.Total);
            System.Console.ReadLine();
        }

        private static void DisplayCart(Cart cart, string cartName)
        {
            System.Console.WriteLine(cartName);
            cart.Items.ToList().ForEach(x => System.Console.WriteLine($"{x.Product.SKU}   {x.Quantity}"));
            System.Console.WriteLine("--------");
            System.Console.WriteLine(cart.Total);
            System.Console.WriteLine();
        }
    }
}
