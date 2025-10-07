using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using Homework_Lists_Dictionaries.Programs.Collections.Lists;
using Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

using System;
using System.Threading;

namespace Homework_Lists_Dictionaries.ProgramHeart.Utilities.HelpDirectionaries;

internal static class MainDictionary
{
    // Це головний словник для меню, обробника
    internal static readonly Dictionary<int, (string description, IRunnable program)> mainDictionary = new()
    {
        { 0, ("Exit", new ExitProgram()) },
        { 1, ("Names from list", new ListNames()) },
        { 2, ("Sum of numbers in list", new ListSumOfNumbers()) },
        { 3, ("Delete fruit from products", new ListFruitsDelete()) },
        { 4, ("Even numbers from list", new ListEvenNumbers()) },
        { 5, ("Check element in list", new ListCheckElement()) },
        { 6, ("List of fibonacci numbers", new ListFibonacciNumbers()) },
        { 7, ("Countries and capitals", new DicCountiresCapCity()) },
        { 8, ("Phone book", new DicPhoneBook()) },
        { 9, ("Products and prices", new DicSumOfProducts()) },
        { 10, ("Most popular words in Dictionary", new DicMostPopWords()) },
        { 11, ("Students and their notes", new DicStudentsNotes()) },
        { 12, ("Count of fruits in Dictionary", new DicCountOfFruits()) },
        { 13, ("Books and their year of release", new DicBooksYear()) }
    };
}


internal class ExitProgram : IRunnable
{
    public void Run()
    {
        Console.Clear();

        LoopExit(3, "Exiting", ".", 500);
        Console.WriteLine("Goodbye!");
        Console.WriteLine("Press any key to exit...");

        Console.ReadKey();
        Environment.Exit(0);
    }

    private static void LoopExit(int quantityAdders, string text, string adder, int delay)
    {
        // -1 тому що перший раз в нас вже є один аддер
        for (int i = 0; i < quantityAdders - 1; i++)
        {
            Console.WriteLine($"{text}{adder}");
            adder += adder;

            Thread.Sleep(delay);
            Console.Clear();
        }
    }
}