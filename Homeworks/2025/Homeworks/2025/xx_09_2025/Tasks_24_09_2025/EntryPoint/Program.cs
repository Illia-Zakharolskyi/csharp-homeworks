using System;
using Tasks_24_09_2025.EntryPoint.Handlers;
using Tasks_24_09_2025.EntryPoint.Menus;
using Tasks_24_09_2025.Programs.Data_Types.String;

namespace Tasks_24_09_2025.EntryPoint;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MainMenu.Display();
            MainHandler.Start();
            Console.WriteLine("Click any button to continue...");
            Console.ReadKey(true);
        }
    }
}