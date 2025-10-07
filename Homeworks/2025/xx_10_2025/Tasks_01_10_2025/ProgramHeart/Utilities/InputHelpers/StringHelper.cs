using System;
using System.Reflection.Metadata.Ecma335;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

internal static class StringHelper
{
    internal static void WriteTitle(string title, char seperatorSym, string decoText, string betweenTexts, bool? inTheMiddle = null)
    {
        string[] splitedBySymbol = title.Split(seperatorSym);

        if (splitedBySymbol.Length != 2 || string.IsNullOrWhiteSpace(splitedBySymbol[0]) || string.IsNullOrWhiteSpace(splitedBySymbol[1]))
            throw new ArgumentException($"Title must contains two non-empty parts separated by '{seperatorSym}'" + $" Назва повинна містити дві не порожні частини розділені '{seperatorSym}'", nameof(title));

        if (inTheMiddle.HasValue && inTheMiddle == true)
        {
            string text = $"{decoText}{splitedBySymbol[0]}{decoText} {betweenTexts} {decoText}{splitedBySymbol[1]}{decoText}";
            int leftPadding = (Console.WindowWidth - text.Length) / 2;
            Console.WriteLine(new string(' ', leftPadding) + text);
            return;
        }

        Console.WriteLine($"{decoText}{splitedBySymbol[0]}{decoText} {betweenTexts} {decoText}{splitedBySymbol[1]}{decoText}");
    }
    internal static string ReadString(string promtMessage, string invalidInputMessage, string[]? allowedAnswers = null, string? invalidChoiceMessage = null, bool ignoreCase = false)
    {
        while (true)
        {
            Console.Write(promtMessage);
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput) || string.Empty == userInput)
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedAnswers != null)
            {
                bool isValid = ignoreCase
                    ? allowedAnswers.Any(a => a.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                    : allowedAnswers.Contains(userInput);

                if (!isValid)
                {
                    Console.WriteLine(invalidChoiceMessage);
                    continue;
                }
            }

            return userInput;
        }
    }
}
