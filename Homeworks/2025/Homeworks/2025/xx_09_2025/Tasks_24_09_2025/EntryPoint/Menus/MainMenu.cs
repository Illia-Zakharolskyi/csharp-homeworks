using System;
using System.Threading;
using Tasks_24_09_2025.ProgramHeart.Interfaces;
using Tasks_24_09_2025.ProgramHeart.Utilities.MainDictionaries;

namespace Tasks_24_09_2025.EntryPoint.Menus;

internal static class MainMenu
{
    internal static void Display()
    {
        ThirstText("ID", "Description", '-', 30);
        LoopText(MainDictionary.mainDictionary);
        Console.WriteLine(new string('-', 30));
    }
    private static void ThirstText(string textID, string textDescription, char symbol, int times)
    {
        Console.WriteLine($"{textID.PadRight(5)} | {textDescription}");
        Console.WriteLine(new string(symbol, times));
    }
    private static void LoopText(Dictionary<int, (string description, IRunnable program)> dict)
    {
        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key.ToString().PadRight(5)} | {item.Value.description}");
            Thread.Sleep(100);
        }
    }
}
