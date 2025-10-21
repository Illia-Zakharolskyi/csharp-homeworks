using System;
using Tasks_01_10_2025.ProgramHeart.Core.Interfaces;
using Tasks_01_10_2025.ProgramHeart.Utilities.Dictionaries;
using Tasks_01_10_2025.ProgramHeart.Utilities.InputHelpers;

namespace Tasks_01_10_2025.Programs;

internal class CurrencyConvertor : IRunnable
{
    public void Run()
    {
        StringHelper.WriteTitle("welcome to currency convertor!/ласкаво просимо до конвертора валют!", '/', "", "-", true);

        // створюємо масив для перевірки вводу та не тільки
        var allowedCurrencies = CurrencyConvertorDict.thisDict;

        // виводимо інформацію для користувача
        CollectionsHelper.PrintCollection(allowedCurrencies.Keys, "Available currencies(доступні валюти):", '-', '-', true, ", ");

        // приймаємо вхідні дані
        decimal userAmount = FloatingPointNumbersHelper.ReadDecimal("enter amount(введи кількість): ", "Invalid input(не коректний ввід)");
        string userFrom = BigWordReturner(StringHelper.ReadString("convert from(конвертувати з): ", "Invalid input, text can't be empty(не корректний текст, він не може бути пустим)", allowedCurrencies.Keys.ToArray(), "Invalid currency, try again(не корректна валюта, попробуй ще)", true));
        string userTo = BigWordReturner(StringHelper.ReadString("convert to(конвертувати в): ", "Invalid input, text can't be empty(не корректний текст, він не може бути пустим)", allowedCurrencies.Keys.ToArray(), "Invalid currency, try again(не корректна валюта, попробуй ще)", true));

        // конвертуємо валюту
        var result = ConvertCurrency(userAmount, userFrom, userTo);

        // виводимо результат
        Console.WriteLine($"{result.amount:F2} {result.From} - {result.Converted:F2} {result.To}");
    }
    private static (decimal Converted, decimal amount, string From, string To) ConvertCurrency(decimal amount, string from, string to)
    {
        // значення валюти по значенню ключа
        // детальніше подивитися в словник ProgramHeart/Utilities/Dictionaries - CurrencyConvertorDict.cs
        decimal convertFrom = CurrencyConvertorDict.thisDict[from];
        decimal convertIn = CurrencyConvertorDict.thisDict[to];

        // логіка в нас така:
        // кількість ділимо на курс валюти по доллару(з якої валюти конвертуємо)
        // потім помножуємо на курс валюти на яку ми конвертуємо
        decimal CurrencyInBase = amount / convertFrom;
        decimal converted = CurrencyInBase * convertIn;

        return (converted, amount, from, to);
    }
    private static string BigWordReturner(string word)
    {
        return word.ToUpper();
    }
}
