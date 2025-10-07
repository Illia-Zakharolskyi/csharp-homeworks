using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Security.Cryptography;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicCountiresCapCity : IRunnable
{
    public void Run()
    {
        LoopText();
    }
    private static void LoopText()
    {
        foreach (var item in countiresCapCity)
        {
            Console.WriteLine($"Country: {item.Key}, Capital city: {item.Value}");
        }
    }
    private static readonly Dictionary<string, string> countiresCapCity = new()
    {
        { "Ukraine", "Kyiv" },
        { "France", "Paris" },
        { "USA", "Washington" },
        { "Germany", "Berlin" }
    };
}
