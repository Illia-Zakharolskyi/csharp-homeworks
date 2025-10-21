using System;
using System.Security;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;
using Tasks_01_10_2025.ProgramHeart.Utilities.SymbolsAndDigits;
namespace Tasks_01_10_2025.Programs;

internal class PasswordGenerator : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("welcome to password generator!/ласкаво просимо до генератору паролів!", '/', "", "-", true);

        // створюемо масиви для перевірки вводу та не тільки
        var  allowedAlphabets = PasswordGeneratorDict.thisDict.Keys.ToArray();
        string[] boolTrueAnswers = { "yes", "y", "true", "t", "так", "т", "правда", "п", "1", "+" };
        string[] boolFalseAnswers = { "no", "n", "false", "f", "ні", "н", "неправда", "н", "0", "-" };
        string[] allowedBoolAnswers = boolTrueAnswers.Concat(boolFalseAnswers).ToArray();

        // виводимо інформацію для користувача
        CollectionsHelper.PrintDictionary(PasswordGeneratorDict.thisDict, 0, "Available alphabets(доступні алфавіти):", '-', '-');
        CollectionsHelper.PrintCollection(boolTrueAnswers, "'yes' answers(відповіді на 'так'):", null, '-', true, ", ");
        CollectionsHelper.PrintCollection(boolFalseAnswers, "'no' answers(відповіді на 'ні'):", null, '-', true, ", ");

        // приймаємо вхідні дані
        int userAlphabet = IntegersHelper.ReadInt("enter alphabet by number(введи алфавіт по числу): ", "Invalid alphabet, try again(не корректний алфавіт, попробуй ще)", allowedAlphabets, "Invalid alphabet, try again(не корректний алфавіт, попробуй ще)");
        int userLength = IntegersHelper.ReadInt("enter length(введи довжину): ", "Invalid input(не коректний ввід)");
        bool userUseDigits = BoolReturner(StringHelper.ReadString("use digits(використовувати числа)? ", "Invalid input(не коректний ввід)", allowedBoolAnswers, "Invalid choice(не коректний ввід)"), boolTrueAnswers, boolFalseAnswers);
        bool userUseSymbols = BoolReturner(StringHelper.ReadString("use symbols(використовувати символи)? ", "Invalid input(не коректний ввід)", allowedBoolAnswers, "Invalid choice(не коректний ввід)"), boolTrueAnswers, boolFalseAnswers);

        // генеруємо пароль
        string password = PasswordGenerate(userAlphabet, userLength, userUseDigits, userUseSymbols);

        // виводимо результат
        Console.WriteLine($"your password(твій пароль): {password}");
    }
    private static string PasswordGenerate(int alphabetChoice, int length, bool useDigits, bool useSymbols)
    {
        // перевіряємо вхідні дані
        string alphabet = PasswordGeneratorDict.thisDict[alphabetChoice].alphabet;

        char[] cutAlphabet = alphabet.ToCharArray();
        char[] cutDigits = useDigits ? Digits.digits.ToCharArray() : Array.Empty<char>();
        char[] cutSymbols = useSymbols ? Symbols.symbols.ToCharArray() : Array.Empty<char>();

        //пишемо логіку генерації
        Random random = new Random();
        string password = "";
        int loopRepeats = 0;

        while (loopRepeats < length)
        {
            List<char> candidates = new();

            candidates.Add(cutAlphabet[random.Next(0, cutAlphabet.Length - 1)]);
            if (useDigits) candidates.Add(cutDigits[random.Next(cutDigits.Length)]);
            if (useSymbols) candidates.Add(cutSymbols[random.Next(cutSymbols.Length)]);

            password += candidates[random.Next(candidates.Count)];
            loopRepeats++;
            continue;
        }

        return password;
    }
    private static bool BoolReturner(string text, string[] trueBoolAnswers, string[] falseBoolAnswers)
    {
        if (trueBoolAnswers.Contains(text.ToLower()))
            return true;
        else
            return false;
    }
}
