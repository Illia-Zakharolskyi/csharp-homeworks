using OOPLearning2.Domain.Classes;
using OOPLearning2.UI;
using System;

namespace OOPLearning2;

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