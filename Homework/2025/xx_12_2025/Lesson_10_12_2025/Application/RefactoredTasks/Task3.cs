// .NET.9.0
using System;

namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task3
{
    internal static void Execute()
    {
        Console.Write("Перший кут у градусах: ");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Помилка: введено некоректне значення.");
            return;
        }

        Console.Write("Другий кут у градусах: ");
        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Помилка: введено некоректне значення.");
            return;
        }

        double? resultA = DegToRad(a);
        double? resultB = DegToRad(b);

        if (resultA == null || resultB == null)
        {
            Console.WriteLine("Помилка: кут a/b має бути в межах від 0 до 360 градусів.");
            return;
        }

        Console.WriteLine($"Перший кут у радіанах: {resultA}");
        Console.WriteLine($"Другий кут у радіанах: {resultB}");
    }

    static double? DegToRad(int deg)
    {
        if (deg < 0 || deg > 360)
        {
            return null;
        }

        return deg * Math.PI / 180.0;
    }
}