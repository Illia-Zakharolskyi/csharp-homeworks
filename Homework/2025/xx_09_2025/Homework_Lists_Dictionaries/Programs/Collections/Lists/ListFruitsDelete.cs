using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Lists;

internal class ListFruitsDelete : IRunnable
{
    public void Run()
    {
        List<string> allProducts = LoopDelete(_products, _fruits);
        TextProducts(allProducts);
    }
    private static List<string> LoopDelete(List<string> products, List<string> fruits)
    {
        foreach (string fruit in fruits)
        {
            if (products.Contains(fruit))
            {
                products.Remove(fruit);
            }
        }
        return products;
    }
    private static void TextProducts(List<string> products)
    {
        foreach (string product in products)
        {
            Console.WriteLine(product);
        }
    }
    private static readonly List<string> _products = new List<string>
    {
        "Apple", "Banana", "Orange", "Grapes", "Watermelon"
    };
    private static readonly List<string> _fruits = new List<string>
    {
        "Banana"
    };
}
