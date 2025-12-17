// .Net 9.0
using System;

// Application
using Lesson_10_12_2025.UI.Menus;

// UI
using Lesson_10_12_2025.UI.Dispatchers;

namespace Lesson_10_12_2025.UI.Entries;

internal class Program
{
    internal static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            MenuDispatcher.Run(new MainMenu());
            Console.ReadLine();
        }
    }
}