using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using Homework_Lists_Dictionaries.ProgramHeart.Utilities.HelpDirectionaries;
using System;
using System.Threading;

namespace Homework_Lists_Dictionaries.EntryPoint.Menus;

internal static class MainMenu
{
    internal static void Display()
    {
        TextForMenu();
        LoopTextMenu(MainDictionary.mainDictionary);
        Console.WriteLine(new string('-', 50));
    }
    private static void TextForMenu()
    {
        string ID = "ID";
        Console.WriteLine($"{ID.PadRight(5)} | Description");
        Console.WriteLine(new string('-', 50));
    }
    private static void LoopTextMenu(Dictionary<int, (string description, IRunnable program)> dictionary)
    {
        foreach (var item in dictionary)
        {
            Console.WriteLine($"{item.Key.ToString().PadRight(5)} | {item.Value.description}");
            Thread.Sleep(50);
        }
    }
}
