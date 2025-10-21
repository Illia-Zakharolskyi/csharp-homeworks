using StrangeTasks_15_10_2025.ProgramHeart.Utilities.Collections.Dictionaries.EntryPointDicts;
using System;

namespace StrangeTasks_15_10_2025.EntryPoint;

internal static class MainMenu
{
    internal static void Display()
    {
        PrintHeader();
        PrintLoopOptions();
        Console.WriteLine(new string('-', 40));
    }
    private static void PrintHeader()
    {
        Console.WriteLine($"{"Номер", -6} | Опис");
        Console.WriteLine(new string('-', 40));
    }
    private static void PrintLoopOptions()
    {
        foreach (var item in MainDicts.entryDict)
        {
            Console.WriteLine($"{item.Key,-6} | {item.Value.description}");
        }
    }
}
