using OOPLearning.Application.Helpers.Dictionaries;
using System;

namespace OOPLearning.UI;

internal static class MainMenu
{
    internal static void Display()
    {
        Console.WriteLine($"{"Номер",-6} | {"Опис"}");
        Console.WriteLine(new string('-', 40));

        foreach (var item in MainDicts.availableActions)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }

        Console.WriteLine(new string('-', 40));
    }
}
