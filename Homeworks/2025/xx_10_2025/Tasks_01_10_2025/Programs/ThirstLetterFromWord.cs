using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class ThirstLetterFromWord : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("Ласкаво просимо до Витягання Першої Літери зі Слова/!", '/', "", "", true);

        // приймаємо дані
        string userWord = StringHelper.ReadString("Введи слово: ", "не коректний ввід, спробуй ще");

        // виводимо результат
        Console.WriteLine(GetThirstLetter(userWord));
    }
    private static char GetThirstLetter(string word)
    {
        return word[0];
    }
}
