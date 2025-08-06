using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Tasks
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }
    static void Task1()
    {
        Console.WriteLine("Enter some button for clear the screen...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Screen is cleared!");
    }
    static void Task2()
    {
        int counter = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Your clicks: {counter}");
            var key = Console.ReadKey();
            counter++;
            if (key.Key == ConsoleKey.Escape) { break; }
        }
    }
    static void Task3()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("The screen is flickering.");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("The screen is flickering..");
            Thread.Sleep(500);
            Console.Clear();
            Console.Write("The screen is flickering...");
            Thread.Sleep(500);
            if (Console.KeyAvailable)
            {
                Console.ReadKey();
                Console.Clear();
                break;
            }
        }
    }
    static void Task4()
    {
        Console.Clear();
        Console.WriteLine("welcome to my program!");
        Thread.Sleep(1000);
        Console.WriteLine("click some key for start");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Program is start!");
    }
    static void Task5()
    {
        string a = "";
        int b = 0;
        while (true)
        {
            b++;
            a += ".";
            Console.Write($"Downoalding{a}");
            Thread.Sleep(1500);
            Console.Clear();
            if (b == 3)
            {
                Console.Clear();
                Thread.Sleep(100);
                Console.WriteLine("Finish!");
                Console.WriteLine("click some button to exit");
                Console.ReadKey();
                break;
            }
        }
    }
}

