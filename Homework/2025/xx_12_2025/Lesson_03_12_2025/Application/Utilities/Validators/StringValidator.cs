using System;

namespace Lesson_03_12_2025.Application.Utilities.Validators;

internal static class StringValidator
{
    internal static string ReadString(string promptMessage, string invalidInputMessage, List<string>? allowedAnswers = null, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promptMessage);
            string? userInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedAnswers != null && !allowedAnswers.Contains(userInput))
            {
                Console.WriteLine(invalidChoiceMessage ?? "Такої віповіді нема");
                continue;
            }

            return userInput;
        }
    }   
}