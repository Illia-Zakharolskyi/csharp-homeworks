using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class EasyConcatanation : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Легкого Конкатенатора/!", '/', "", "", true);

        // приймаємо дані
        string userTextOne = StringHelper.ReadString("Введи перший текст: ", "не коректний ввід, спробуй ще");
        string userTextTwo = StringHelper.ReadString("Введи другий текст: ", "не коректний ввід, спробуй ще");

        // виводимо результат
        Console.WriteLine(Concatanate(userTextOne, userTextTwo));
    }
    private static string Concatanate(string oneText, string twoText)
    {
        return string.Join(" ", oneText, twoText);
    }
}
