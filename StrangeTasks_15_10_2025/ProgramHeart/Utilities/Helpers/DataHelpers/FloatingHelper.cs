using System;

namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

internal static class FloatingHelper
{
    internal static double ReadDouble(string promptMessage, string invalidInputMessage, List<double>? allowedAnswers = null, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promptMessage);
            string userInput = Console.ReadLine()?.Trim();

            if (!double.TryParse(userInput, out double userDouble))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedAnswers != null && !allowedAnswers.Contains(userDouble))
            {
                Console.WriteLine(invalidChoiceMessage ?? "Такої віповіді нема");
                continue;
            }

            return userDouble;
        }
    }
}
