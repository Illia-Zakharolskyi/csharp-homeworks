using Homework_Lists_Dictionaries.EntryPoint.Handlers;
using Homework_Lists_Dictionaries.EntryPoint.Menus;
using System;

namespace Homework_Lists_Dictionaries.EntryPoint;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            try
            {
                Console.Clear();
                MainMenu.Display();
                MainHandler.Start();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}