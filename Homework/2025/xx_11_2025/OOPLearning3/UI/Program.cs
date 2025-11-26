using System;

namespace OOPLearning3.UI;

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
            MainHandler.Start();

            Console.ReadKey();
        }
    }
}