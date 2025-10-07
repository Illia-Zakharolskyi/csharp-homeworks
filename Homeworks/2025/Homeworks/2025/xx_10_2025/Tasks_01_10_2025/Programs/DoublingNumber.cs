using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class DoublingNumber : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Подвоєння Числа/!", '/', "", "", true);

        // приймаемо дані
        decimal userNumber = FloatingPointNumbersHelper.ReadDecimal("Введи число, яке хочеш подвоїти: ", "не коректний ввід, спробуй число");

        // подвоюємо
        decimal result = Doubling(userNumber);

        // виводимо результат
        Console.WriteLine($"Результат подвоєння числа {userNumber:F2} дорівнює {result:F2}");
    }
    private static decimal Doubling(decimal number)
    {
        return number * 2;
    }
}
