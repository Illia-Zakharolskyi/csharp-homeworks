﻿using System;

namespace StrangeTasks_15_10_2025.ProgramHeart.Utilities.Helpers.DataHelpers;

internal static class IntegersHelper
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
