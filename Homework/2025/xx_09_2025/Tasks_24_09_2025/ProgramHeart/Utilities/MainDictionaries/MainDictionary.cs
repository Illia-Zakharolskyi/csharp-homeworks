using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasks_24_09_2025.ProgramHeart.Interfaces;
using Tasks_24_09_2025.Programs.Data_Types.String;

namespace Tasks_24_09_2025.ProgramHeart.Utilities.MainDictionaries;

internal static class MainDictionary
{
    // Це головний словник для меню, обробника
    internal static readonly Dictionary<int, (string description, IRunnable program)> mainDictionary = new()
    {
        { 0, ("Exit", new ExitProgram()) },
        { 1, ("text -> ASCII", new StringConvertToASCII()) },
        { 2, ("text -> txet", new StringReverse()) },
        { 3, ("text & chars -> count of chars in text", new StringCharCopied()) },
        { 4, ("text -> caiser cipher", new StringCaiserCipher()) },
        { 5, ("text -> have it one word?", new StringWordFinder()) },
        { 6, ("mini game guess-the-word", new StringGuessWord()) },
        { 7, ("text -> every second char from first become big", new StringRepChar()) },
        { 8, ("text -> it's polindrome?", new StringIsPalindrome()) }
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