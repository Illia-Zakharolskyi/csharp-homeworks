using System;

namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

internal static class StringHelper
{
    internal static string ReadString(string promptMessage, string invalidInputMessage, List<string>? allowedAnswers = null, bool ignoreCaseForAllowedAnswers = true, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promptMessage);
            string userText = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(userText))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedAnswers != null)
            {
                bool isFound = ignoreCaseForAllowedAnswers
                    ? allowedAnswers.Any(c => c.Equals(userText, StringComparison.OrdinalIgnoreCase))
                    : allowedAnswers.Contains(userText);

                if (!isFound)
                {
                    Console.WriteLine(invalidChoiceMessage ?? "Не коректний вибір, спробуй ще");
                    continue;
                }
            }

            return userText;
        }
    }
}
