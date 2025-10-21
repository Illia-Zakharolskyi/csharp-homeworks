using System;
using Tasks_01_10_2025.EntryPoint.Handlers;
using Tasks_01_10_2025.EntryPoint.Menus;

namespace Tasks_01_10_2025;

internal class Program
{
    static void Main()
    {
        // щоб відображався/приймався український алфавіт
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            MainMenu.Display();
            MainHandler.Start();
            Console.ReadKey();
        }
    }
}