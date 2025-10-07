using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicCountOfFruits : IRunnable
{
    public void Run()
    {
        string name = MostFinder();
        Console.WriteLine($"Most count have {name}, count: {productsValue[name]}");
    }
    private static string MostFinder()
    {
        int theBiggest = 0;
        string name = "";

        foreach (var item in productsValue)
        {
            if (item.Value > theBiggest)
            {
                theBiggest = item.Value;
                name = item.Key;
            }
        }

        return name;
    }
    private static readonly Dictionary<string, int> productsValue = new()
    {
        { "Apples", 15555 },
        { "Not apples", 57766665 },
        { "Watermelóns", 66 },
        { "Some", 67 }
    };
}
