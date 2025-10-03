using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringCharCopied : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to char-checker!");
        Console.Write("Text: ");
        string text = Console.ReadLine();
        Console.Write("Char/s: ");
        string chars = Console.ReadLine();
        var copies = CopyFinder(text, chars);
        foreach (var item in copies)
        {
            Console.WriteLine($"{item.Key} - {item.Value} times");
        }
    }
    private static Dictionary<char, int> CopyFinder(string text, string chars)
    {
        var charsRepeats = new Dictionary<char, int>();

        // не вмію користуватися LINQ, тому до цього додумався
        foreach (char c in chars)
        {
            foreach (char ch in text)
            {
                if (charsRepeats.ContainsKey(c))
                {
                    if (c == ch)
                    {
                        charsRepeats[c]++;
                    }
                }
                else
                {
                    charsRepeats.Add(c, 0);
                }
            }
        }

        return charsRepeats;
    }
}
