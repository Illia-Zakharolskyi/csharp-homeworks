// .NET.9.0
using System;

namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task2
{
    internal static void Execute()
    {
        Console.Write("Введіть кут у градусах: ");
        
        if (!int.TryParse(Console.ReadLine(), out int deg))
        {
            Console.WriteLine("Помилка: введено некоректне значення.");
            return;
        }

        double? result = DegToRad(deg);

        if (result == null)
        {
            Console.WriteLine("Помилка: кут має бути в межах від 0 до 360 градусів.");
            return;
        }

        Console.WriteLine("У радіанах: " + result);
    }

    static double? DegToRad(int deg)
    {
        if (deg < 0 || deg > 360)
        {
            return null;
        }

        double rad = deg * Math.PI / 180.0;
        return rad;
    }
}