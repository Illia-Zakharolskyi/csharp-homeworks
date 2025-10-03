using System;
using Tasks_24_09_2025.ProgramHeart.Interfaces;

namespace Tasks_24_09_2025.Programs.Data_Types.String;

internal class StringWordCopy : IRunnable
{
    public void Run()
    {
        Console.WriteLine("welcome to repeats-word program!");
        string text = Console.ReadLine();
        Dictionary<string, int> words = new Dictionary<string, int>();
        LoopText(words);

    }
    private static Dictionary<string, int> FoundCopy(string text)
    {
        var lowerText = text
            .ToLower()
            .Split(new[] { ' ', '-', ',', '!', '.', '?', ':', ';', '_', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        var wordsCount = new Dictionary<string, int>();

        foreach (var word in lowerText)
        {
            if (wordsCount.ContainsKey(word))
            {
                wordsCount[word]++;
            }
            else
            {
                wordsCount[word] = 1;
            }
        }

        return wordsCount;
    }
    private static void LoopText(Dictionary<string, int> dict)
    {
        Console.WriteLine("Repeats words:");
        foreach (var word in dict)
        {
            if (dict[word.Key] > 1)
            {
                Console.WriteLine($"{word.Key} - {word.Value} times");
            }
        }
    }
}
