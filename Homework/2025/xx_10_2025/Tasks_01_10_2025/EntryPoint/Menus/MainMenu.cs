using System;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

namespace Tasks_01_10_2025.EntryPoint.Menus;

internal static class MainMenu
{
    internal static void Display()
    {
        FirstText("ID/айді", "Description/опис", "|");
        Console.WriteLine(new string('-', 50));
        MainText(50, "|");
        Console.WriteLine(new string('-', 50));
    }
    private static void FirstText(string firstText, string secondText, string separator)
    {
        Console.WriteLine($"{new string(firstText).PadRight(5)} {separator} {secondText}");
    }
    private static void MainText(int delay, string separator)
    {
        foreach (var item in MainDict.mainDict)
        {
            Console.WriteLine($"{item.Key.ToString().PadRight(5)} {separator} {item.Value.description}");
            Thread.Sleep(delay);
        }
    }
}
