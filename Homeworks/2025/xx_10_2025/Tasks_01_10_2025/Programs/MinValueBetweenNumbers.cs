using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class MinValueBetweenNumbers : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Пошуку Мінімального Числа/!", '/', "", "", true);

        // приймаємо дані
        decimal userNumberA = FloatingPointNumbersHelper.ReadDecimal("Введи перше число: ", "не коректний ввід, спробуй число");
        decimal userNumberB = FloatingPointNumbersHelper.ReadDecimal("Введи друге число: ", "не коректний ввід, спробуй число");

        // шукаємо мінімальне
        decimal minValue = MinValue(userNumberA, userNumberB);

        // виводимо результат
        Console.WriteLine($"Мінімальне число між {userNumberA:F2} та {userNumberB:F2} дорівнює {minValue:F2}");
    }
    private static decimal MinValue(decimal a, decimal b)
    {
        return a < b ? a : b;
    }
}
