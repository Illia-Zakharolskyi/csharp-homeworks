using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;
using System.Net.Http.Headers;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries;

internal class DicMostPopWords : IRunnable
{
    public void Run()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        Dictionary<string, int> words, top3 = new();

        words = CopyFinder(text);
        top3 = TopMaker(words);

        foreach (var item in top3)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
    private static Dictionary<string, int> CopyFinder(string text)
    {
        string[] splited = text
            .ToLower()
            .Split(new[] { ' ', ',', '.', ':', ';', '-', '!', '?', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> words = new Dictionary<string, int>();

        foreach (var word in splited)
        {
            if (words.ContainsKey(word))
            {
                words[word]++;
            }
            else
            {
                words.Add(word, 1);
            }
        }

        return words;
    }
    private static Dictionary<string, int> TopMaker(Dictionary<string, int> dictionary)
    {
        return dictionary
            .OrderByDescending(pair => pair.Value)
            .Take(3)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
