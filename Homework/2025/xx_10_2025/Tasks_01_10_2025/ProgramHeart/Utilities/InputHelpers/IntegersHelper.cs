using System;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

internal static class IntegersHelper
{
    internal static int ReadInt(string promtMessage, string invalidInputMessage, int[]? allowedvalues = null, string? invalidChoiceMessage = null)
    {
        while (true)
        {
            Console.Write(promtMessage);
            
            if (!int.TryParse(Console.ReadLine(), out int userInput))
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
