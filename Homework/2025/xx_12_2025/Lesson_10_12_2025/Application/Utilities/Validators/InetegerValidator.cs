// .Net 9.0
using System;

namespace Lesson_10_12_2025.Application.Utilities.Validators;

internal class InetegerValidator
{
    internal static int ReadInteger(string promptMessage, string invalidInputMessage, List<int>? allowedAnswers = null, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promptMessage);
            string userInput = Console.ReadLine()?.Trim();

            if (!int.TryParse(userInput, out int userInteger))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedAnswers != null && !allowedAnswers.Contains(userInteger))
            {
                Console.WriteLine(invalidChoiceMessage ?? "Такої віповіді нема");
                continue;
            }

            return userInteger;
        }
    }
}
