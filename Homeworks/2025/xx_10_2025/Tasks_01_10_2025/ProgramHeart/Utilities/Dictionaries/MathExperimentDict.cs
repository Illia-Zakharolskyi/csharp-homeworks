using System;
using System.Numerics;

namespace Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;

internal static class MathExperimentDict
{
    internal static readonly Dictionary<string, Func<decimal, decimal, decimal>> operations = new()
    {
        { "add", (a, b) => a + b }, // addition, додавання +
        { "sub", (a, b) => a - b }, // subtraction, віднімання -
        { "mul", (a, b) => a * b}, // multiplication, множення *
        { "div", (a, b) => a / b } // division, ділення /
    };
    // перевод операцій на арифметичні символи
    internal static readonly Dictionary<string, string> operationSymbols = new()
    {
        { "add", "+" },
        { "sub", "-" },
        { "mul", "*" },
        { "div", "/" }
    };
}
