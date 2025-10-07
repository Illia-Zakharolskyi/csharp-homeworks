using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class IsNumberEven : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Перевірки Числа на Парність/!", '/', "", "", true);

        // приймаємо дані
        int userNumber = IntegersHelper.ReadInt("Введи ціле число: ", "не коректний ввід, спробуй ціле число");

        // виводимо результат
        Console.WriteLine($"Число {userNumber} є {CheckIsEven(userNumber)}.");
    }
    private static string CheckIsEven(int number)
    {
        return number % 2 == 0 ? "парним" : "не парним";
    }
}
