using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicSumOfProducts : IRunnable
{
    public void Run()
    {
        double price = PriceCalculate();
        Console.WriteLine($"Price for all products is: {price}");
    }
    private static double PriceCalculate()
    {
        double price = 0;

        foreach (var item in productsPrice)
        {
            price += item.Value;
        }

        return price;
    }
    private static readonly Dictionary<string, double> productsPrice = new()
    {
        { "Apple", 15.45 },
        { "Watermelon", 60.32 },
        { "Orange", 25.98 }
    };
}
