using System;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

internal static class CurrencyConvertorDict
{
    // курс по USD
    internal static readonly Dictionary<string, decimal> thisDict = new()
    {
        { "UAH", 41.05m },
        { "USD", 1.0m },
        { "EUR", 0.85m }
    };
}
