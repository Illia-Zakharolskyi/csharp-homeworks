using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class CalculateAvarageNotes : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("welcome to avarage note calculate!/ласкаво просимо до обчислювача середньої оцінки!", '/', "", "-", true);

        // приймаемо данні
        double[] userNotes = UserArrayRead("enter notes separated by a space(введи оцінки розділені пробілом): ", "Invalid input, text can't be empty(не коректний ввід, текст не може бути пустим)", "Text should only contain numbers separated by spaces(текст повинен мати тільки числа розділенні пробілами)");

        // генеруємо результат
        double avarageNote = CalculateAvarage(userNotes);

        // виводимо результат
        Console.WriteLine($"Avarage note(середня оцінка): {avarageNote}");
    }
    private static double CalculateAvarage(double[] notes)
    {
        return notes.Average();
    }
    private static double[] UserArrayRead(string promtMessage, string invalidStringMessage, string invalidNumbersMessage)
    {
        while (true)
        {
            Console.Write(promtMessage);
            string userAnswers = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userAnswers) || userAnswers == string.Empty)
            {
                Console.WriteLine(invalidStringMessage);
                continue;
            }

            string[] splitedAnswer = userAnswers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double[] notes = splitedAnswer
                .Where(element => double.TryParse(element, out _))
                .Select(element => double.Parse(element))
                .ToArray();

            if (notes.Length == 0)
            {
                Console.WriteLine(invalidNumbersMessage);
                continue;
            }

            return notes;
        }
    }
}
