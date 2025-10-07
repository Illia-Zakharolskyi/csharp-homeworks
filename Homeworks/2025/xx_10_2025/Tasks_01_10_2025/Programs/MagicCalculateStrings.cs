using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class MagicCalculateStrings : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("welcome to magic calculator!/ласкаво просимо до магічного калькулятора!", '/', "", "-", true);

        // створюємо масиви для перевірки вводу та не тільки
        string[] boolTrueAnswers = { "yes", "y", "true", "t", "так", "т", "правда", "п", "1", "+" };
        string[] boolFalseAnswers = { "no", "n", "false", "f", "ні", "н", "неправда", "н", "0", "-" };
        string[] allowedBoolAnswers = boolTrueAnswers.Concat(boolFalseAnswers).ToArray();

        // виводимо інформацію для користувача
        CollectionsHelper.PrintCollection(boolTrueAnswers, "'yes' answers(відповіді на 'так'):", '-', '-', true, ", ");
        CollectionsHelper.PrintCollection(boolFalseAnswers, "'no' answers(відповіді на 'ні'):", null, '-', true, ", ");

        // приймаємо вхідні дані
        string userText = StringHelper.ReadString("enter text(введи текст): ", "Invalid input, text can't be empty(не корректний текст, він не може бути пустим)");
        bool userReverse = BoolReturner(StringHelper.ReadString("reverse text(перевернути текст)? ", "Invalid input(не коректний ввід)", allowedBoolAnswers, "Invalid choice(не коректний ввід)"), boolTrueAnswers);
        bool userToUpper = BoolReturner(StringHelper.ReadString("to upper case(великі літери)? ", "Invalid input(не коректний ввід)", allowedBoolAnswers, "Invalid choice(не коректний ввід)"), boolTrueAnswers);
        int userRepeats = IntegersHelper.ReadInt("enter repeats(введи кількість повторів): ", "Invalid input(не коректний ввід)");

        // генеруємо результат
        string result = StringMagic(userText, userReverse, userToUpper, userRepeats, "|");

        // виводимо результат
        Console.WriteLine($"your text(твій текст): {result}");
    }
    private static string StringMagic(string text, bool reverse, bool toUpper, int repeats, string separator)
    {
        char[] newText = text.ToCharArray();

        if (reverse)
            Array.Reverse(newText);
        if (toUpper)
            newText = newText
                .Select(c => char.ToUpper(c))
                .ToArray();

        return string.Join(separator, Enumerable.Repeat(new string(newText), repeats));
    }
    private static bool BoolReturner(string text, string[] boolTrueAnswers)
    {
        return boolTrueAnswers.Contains(text.ToLower()) ? true : false;
    }
}
