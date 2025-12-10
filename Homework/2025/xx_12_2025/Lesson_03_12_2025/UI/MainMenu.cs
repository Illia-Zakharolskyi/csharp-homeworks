// .NET9.0
using Lesson_03_12_2025.Application.Helpers.Dictionaries;
using System;

namespace Lesson_03_12_2025.UI;

internal static class MainMenu
{
    internal static void Display(Dictionary<int, (string description, Action avtion)> actions)
    {
        Console.WriteLine($"{"Номер",-6} | {"Опис"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in actions)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
