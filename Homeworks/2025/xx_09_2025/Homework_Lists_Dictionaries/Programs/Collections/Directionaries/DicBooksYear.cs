using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Xml.XPath;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicBooksYear : IRunnable
{
    public void Run()
    {
        Dictionary<string, int> sorted = SortByDescending(booksYear);
        Text(sorted);
    }
    private static Dictionary<string, int> SortByDescending(Dictionary<string, int> dict)
    {
        return dict
            .OrderByDescending(pair => pair.Value)
            .Take(dict.Count)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
    private static void Text(Dictionary<string, int> dict)
    {
        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
    private static readonly Dictionary<string, int> booksYear = new()
    {
        { "Book 1", 1267 },
        { "Book 2", 2025 },
        { "Book 3", 1976 }
    };
}
