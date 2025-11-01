using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCrystal.CrystalHeart.Utilities.Validators;

internal static class StringValidator
{
    internal static string ReadInput(string promptMessage, string invalidInputMessage, List<string>? availableAnswers = null, string invalidChoiceMessage = "Не зовсім корректний вибір", bool ignoreCase = true)
    {
        while (true)
        {
            Console.Write(promptMessage);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(invalidInputMessage);
                continue;
            }

            if (availableAnswers != null)
            {
                bool match = availableAnswers.Contains(input);

                if (!match && ignoreCase)
                {
                    match = availableAnswers.Any(x => string.Equals(x?.ToString(), input?.ToString(), StringComparison.OrdinalIgnoreCase));
                }

                if (!match)
                {
                    Console.WriteLine(invalidChoiceMessage);
                    continue;
                }

                return input;
            }

            return input;
        }
    }
}
