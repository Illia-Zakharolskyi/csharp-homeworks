using StrangeTasks_15_10_2025.EntryPoint;
using System;

namespace StrangeTasks_15_10_2025;

internal class Program
{
    internal static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();

            MainMenu.Display();
            MainHandler.StartHanlde();

            Console.ReadKey();
        }
    }
}