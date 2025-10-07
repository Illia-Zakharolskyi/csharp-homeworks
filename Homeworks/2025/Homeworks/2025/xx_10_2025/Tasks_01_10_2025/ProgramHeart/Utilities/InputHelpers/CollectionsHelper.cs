using System;
using System.Net.Http.Headers;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

internal static class CollectionsHelper
{
    internal static void PrintDictionary<TKey, TValue1, TValue2>(Dictionary<TKey, (TValue1, TValue2)> dict, int steps, string? promtMessage = null, char? symbolBefore = null, char? symbolAfter = null)
    {
        if (symbolBefore != null)
            Console.WriteLine(new string(symbolBefore ?? ' ', Console.WindowWidth));

        if (promtMessage != null)
            Console.WriteLine(promtMessage);

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key.ToString().PadRight(steps)} - {item.Value.Item1}");
        }

        if (symbolAfter != null)
            Console.WriteLine(new string(symbolAfter ?? ' ', Console.WindowWidth));
    }
    internal static void PrintCollection<T>(IEnumerable<T> collection, string? promtmessage = null, char? symbolBefore = null, char? symbolAfter = null, bool? inLine = null, string? sepBetweenElements = null)
    {
        if (collection == null || !collection.Any())
            throw new ArgumentException("Collection is null or empty" + "Колекція пуста або нульова", nameof(collection));

        if (symbolBefore != null)
            Console.WriteLine(new string(symbolBefore ?? ' ', Console.WindowWidth));

        if (promtmessage != null)
            Console.WriteLine(promtmessage);

        if (inLine.HasValue && inLine == true)
        {
            Console.WriteLine(string.Join(sepBetweenElements ?? " ", collection));

            if (symbolAfter != null)
                Console.WriteLine(new string(symbolAfter ?? ' ', Console.WindowWidth));

            return;
        }

        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }

        if (symbolAfter != null)
            Console.WriteLine(new string(symbolAfter ?? ' ', Console.WindowWidth));
    }
}
