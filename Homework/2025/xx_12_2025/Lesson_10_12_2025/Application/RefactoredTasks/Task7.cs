// .NET.9.0
using System;
using System.Text;

namespace Lesson_10_12_2025.Application.RefactoredTasks;

internal static class Task7
{
    internal static void Execute()
    {
        int[]? degrees = ReadUserDegrees();

        if (degrees == null || degrees.Length == 0)
        {
            Console.WriteLine("Немає введених кутів для конвертації.");
            return;
        }

        double[] radians = ConvertDegreesToRads(degrees);

        PrintResult(radians);
    }
    private static int[]? ReadUserDegrees()
    {
        List<int> degrees = new();

        while (true)
        {
            Console.Write("Введіть кут у градусах (або 'вихід' для завершення): ");

            string? input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "вихід")
            {
                return degrees.ToArray();
            }

            if (int.TryParse(input, out int deg))
            {
                degrees.Add(deg);
            }

            else
            {
                Console.WriteLine("Помилка: введено некоректне значення.");
            }
        }
    }
    private static double[] ConvertDegreesToRads(int[] degrees)
    {
        double[] result = new double[degrees.Length];

        for (int i = 0; i < degrees.Length; i++)
        {
            int d = degrees[i];

            if (d < 0 || d > 360)
            {
                result[i] = double.NaN;
                continue;
            }

            result[i] = d * Math.PI / 180;
        }

        return result;
    }
    internal static void PrintResult(double[] radians)
    {
        StringBuilder sb = new();
        sb.Append("Отримані радіани: ");

        for (int i = 0; i < radians.Length; i++)
        {
            if (!double.IsNaN(radians[i]))
            {
                sb.Append(radians[i]);
            }
            else
            {
                sb.Append("Некоректне значення");
            }

            if (i < radians.Length - 1)
            {
                sb.Append(", ");
            }
        }

        Console.WriteLine(sb.ToString());
    }
}