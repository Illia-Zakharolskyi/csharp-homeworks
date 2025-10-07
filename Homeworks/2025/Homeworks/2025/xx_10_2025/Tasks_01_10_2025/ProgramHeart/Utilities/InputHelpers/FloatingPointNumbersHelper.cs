using System;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

internal static class FloatingPointNumbersHelper
{
    internal static decimal ReadDecimal(string promtMessage, string invalidInputMessage, decimal[]? allowedvalues = null, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promtMessage);
            if (!decimal.TryParse(Console.ReadLine(), out decimal userInput))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (allowedvalues != null && !allowedvalues.Contains(userInput))
            {
                Console.WriteLine(invalidChoiceMessage);
                continue;
            }

            return userInput;
        }
    }
}
